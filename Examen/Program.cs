/*
C# использование последовательных и параллельных методов и измерить 
производительность с помощью BenchmarkDotNet в консольном приложении:

    1) обычный массив Array, последовательные циклы (без потоков)
    2) Parallel.For (each) (без потоков)
    3) PLINQ (asParallel)
    4) Task.Factory по кол-ву ядер (<>)

Сравнить последовательную и параллельную обработку лог-файлов:
3. Определить средний объем информации загруженной ежедневно
*/

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<Examen>();
    }
}

public class Examen
{
    [Params(1_000_000)]
    public int _countLogs;

    // Диапазон дат: с 1 января 2025 по сегодня (25 сентября 2025)
    DateTime _startDate = new DateTime(2025, 1, 1);
    DateTime _endDate = new DateTime(2025, 9, 25);

    public List<string> _logs = [];
    private string _currentFilePath = "";

    [GlobalSetup]
    public void Setup()
    {
        _currentFilePath = $"web_access_{Guid.NewGuid()}.log";
        var random = new Random(101);
        var pages = new[]
        {
            "/home", "/about", "/contact", "/products", "/login", "/profile",
            "/cart", "/settings", "/help", "/blog", "/faq"
        };

        var userAgents = new[]
        {
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 14_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.4 Safari/605.1.15",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 17_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.4 Mobile/15E148 Safari/604.1",
            "Mozilla/5.0 (Linux; Android 14) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Mobile Safari/537.36",
            "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:124.0) Gecko/20100101 Firefox/124.0"
        };

        var totalDays = (_endDate - _startDate).Days + 1;

        using (var writer = new StreamWriter(_currentFilePath))
        {
            for (int i = 0; i < _countLogs; i++)
            {
                // Случайный IP из документационных диапазонов
                string ip = $"203.0.113.{random.Next(1, 255)}";

                // Случайная дата
                var randomDate = _startDate.AddDays(random.Next(0, totalDays))
                                       .AddHours(random.Next(0, 24))
                                       .AddMinutes(random.Next(0, 60))
                                       .AddSeconds(random.Next(0, 60));

                var enUS = new System.Globalization.CultureInfo("en-US");
                string dateStr = randomDate.ToString("dd/MMM/yyyy:HH:mm:ss", enUS) + " +0300";

                // Случайная страница
                string page = pages[random.Next(pages.Length)];
                if (page == "/product" || random.NextDouble() > 0.7)
                    page += $"?id={random.Next(1, 1000)}";

                // Случайный объём: 500–10000 байт
                int bytes = random.Next(500, 10001);

                string userAgent = userAgents[random.Next(userAgents.Length)];

                string logLine = $"{ip} - - [{dateStr}] \"GET {page} HTTP/1.1\" 200 {bytes} \"{userAgent}\"";
                writer.WriteLine(logLine);
            }
        }

        Console.WriteLine($"\t   +------------------------------------------------------+");
        Console.WriteLine($"===========| \x1b[38;2;64;224;208mCreated file '{_currentFilePath}' with 1000 log entries!\x1b[0m |===========");
        Console.WriteLine($"\t   +------------------------------------------------------+");
        Console.WriteLine(" ");
        Console.WriteLine("\x1b[38;2;64;224;208mWorking dir: " + Directory.GetCurrentDirectory() + "\x1b[0m");
        Console.WriteLine(" ");

        _logs = [.. File.ReadLines(_currentFilePath)];        
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        try
        {
            if (!string.IsNullOrEmpty(_currentFilePath) && File.Exists(_currentFilePath))
            {
                File.Delete(_currentFilePath);
            }
        }
        catch
        {
            // Игнорируем ошибки (например, файл уже удалён или заблокирован)
        }
    }

    //////////////////////////////////////////// 1. Базовые последовательные методы \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double ArrayFor()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            if (elementLog.Length < 10) continue;
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);
            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        if (dictionary.Count == 0) return 0.0;
        return dictionary.Values.Average();
    }

    [Benchmark]
    public double ArrayFor_Indexed()
    {
        var dict = new Dictionary<string, int>();
        var logs = _logs;
        for (int i = 0; i < logs.Count; i++)
        {
            var parts = logs[i].Split(' ');
            if (parts.Length < 10 || !parts[3].StartsWith("[")) continue;
            try
            {
                string key = parts[3].Substring(1, 11);
                int bytes = int.Parse(parts[9]);
                dict[key] = dict.GetValueOrDefault(key) + bytes;
            }
            catch { }
        }
        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double ArrayFor_NoExceptions()
    {
        var dict = new Dictionary<string, int>();
        foreach (var log in _logs)
        {
            var parts = log.Split(' ');
            if (parts.Length < 10) continue;

            // Проверка даты
            if (!parts[3].StartsWith("[") || parts[3].Length < 13) continue;
            string dateKey = parts[3].Substring(1, 11);

            // Безопасный парсинг байтов
            if (!int.TryParse(parts[9], out int bytes)) continue;

            dict[dateKey] = dict.GetValueOrDefault(dateKey) + bytes;
        }

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double ArrayFor_DictionaryWithCapacity()
    {
        // Оценка: максимум дней в диапазоне (268 дней с 1 янв по 25 сен)
        var dict = new Dictionary<string, int>(300);
        foreach (var log in _logs)
        {
            var parts = log.Split(' ');
            if (parts.Length < 10 || !parts[3].StartsWith("[")) continue;
            try
            {
                string key = parts[3].Substring(1, 11);
                int bytes = int.Parse(parts[9]);
                dict[key] = dict.GetValueOrDefault(key) + bytes;
            }
            catch { }
        }
        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double Sequential_LINQ()
    {
        var result = _logs
            .Select(log =>
            {
                var parts = log.Split(' ');
                if (parts.Length < 10 || !parts[3].StartsWith("["))
                    return (dateKey: (string?)null, bytes: 0);
                try
                {
                    // ⬇️ ЯВНО УКАЗЫВАЕМ ИМЕНА ВО ВСЕХ ВЕТКАХ
                    return (dateKey: parts[3].Substring(1, 11), bytes: int.Parse(parts[9]));
                }
                catch
                {
                    return (dateKey: (string?)null, bytes: 0);
                }
            })
            .Where(x => x.dateKey != null)
            .GroupBy(x => x.dateKey!, x => x.bytes)
            .ToDictionary(g => g.Key, g => g.Sum());

        return result.Count == 0 ? 0.0 : result.Values.Average();
    }

    ////////////////////////////// 2. Оптимизированные последовательные методы (Span / unsafe) \\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double SpanBased_Parser()
    {
        var dict = new Dictionary<string, int>();
        foreach (var log in _logs)
        {
            ReadOnlySpan<char> span = log.AsSpan();
            // Найдём 4-е поле (дата в скобках)
            int spaceCount = 0;
            int dateStart = -1, dateEnd = -1;

            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == ' ')
                {
                    spaceCount++;
                    if (spaceCount == 3 && dateStart == -1)
                    {
                        dateStart = i + 1; // после 3-го пробела
                    }
                    else if (spaceCount == 4 && dateEnd == -1)
                    {
                        dateEnd = i;
                        break;
                    }
                }
            }

            if (dateStart == -1 || dateEnd == -1 || dateEnd - dateStart < 12) continue;

            // Дата: [25/Sep/2025:...
            if (span[dateStart] != '[') continue;
            var dateKeySpan = span.Slice(dateStart + 1, 11); // "25/Sep/2025"
            var dateKey = dateKeySpan.ToString();

            // Найдём 10-е поле (байты) — пропустим 9 пробелов
            spaceCount = 0;
            int byteStart = -1;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == ' ')
                {
                    spaceCount++;
                    if (spaceCount == 9)
                    {
                        byteStart = i + 1;
                        break;
                    }
                }
            }

            if (byteStart == -1) continue;
            int byteEnd = span.Slice(byteStart).IndexOf(' ');
            if (byteEnd == -1) byteEnd = span.Length - byteStart;
            var byteSpan = span.Slice(byteStart, byteEnd);

            if (!int.TryParse(byteSpan, out int bytes)) continue;

            dict[dateKey] = dict.GetValueOrDefault(dateKey) + bytes;
        }

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double SpanBased_WithCapacity()
    {
        // Вычисляем максимальное количество уникальных дней на основе диапазона
        int totalDays = (_endDate - _startDate).Days + 1;
        int capacity = Math.Max(1, totalDays); // Защита от некорректных диапазонов

        var dict = new Dictionary<string, int>(capacity);

        foreach (var log in _logs)
        {
            ReadOnlySpan<char> span = log.AsSpan();
            int spaceCount = 0;
            int dateStart = -1, dateEnd = -1;

            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == ' ')
                {
                    spaceCount++;
                    if (spaceCount == 3 && dateStart == -1)
                    {
                        dateStart = i + 1;
                    }
                    else if (spaceCount == 4 && dateEnd == -1)
                    {
                        dateEnd = i;
                        break;
                    }
                }
            }

            if (dateStart == -1 || dateEnd == -1 || dateEnd - dateStart < 12) continue;
            if (span[dateStart] != '[') continue;

            var dateKeySpan = span.Slice(dateStart + 1, 11); // "25/Sep/2025"
            var dateKey = dateKeySpan.ToString();

            spaceCount = 0;
            int byteStart = -1;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == ' ')
                {
                    spaceCount++;
                    if (spaceCount == 9)
                    {
                        byteStart = i + 1;
                        break;
                    }
                }
            }

            if (byteStart == -1) continue;
            int byteEnd = span.Slice(byteStart).IndexOf(' ');
            if (byteEnd == -1) byteEnd = span.Length - byteStart;
            var byteSpan = span.Slice(byteStart, byteEnd);

            if (!int.TryParse(byteSpan, out int bytes)) continue;

            dict[dateKey] = dict.GetValueOrDefault(dateKey) + bytes;
        }

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public unsafe double Unsafe_MemoryParsing()
    {
        var dict = new Dictionary<string, int>();
        foreach (var log in _logs)
        {
            fixed (char* ptr = log)
            {
                char* p = ptr;
                int spaces = 0;
                char* dateStart = null;
                char* byteStart = null;

                while (*p != '\0')
                {
                    if (*p == ' ')
                    {
                        spaces++;
                        if (spaces == 3) dateStart = p + 1;
                        else if (spaces == 9) byteStart = p + 1;
                    }
                    p++;
                }

                if (dateStart == null || byteStart == null) continue;

                // Извлекаем дату (11 символов после '[')
                if (*dateStart != '[') continue;
                string dateKey = new string(dateStart + 1, 0, 11);

                // Извлекаем байты до следующего пробела
                char* end = byteStart;
                while (*end != ' ' && *end != '\0') end++;
                int len = (int)(end - byteStart);
                if (len <= 0) continue;

                string byteStr = new string(byteStart, 0, len);
                if (!int.TryParse(byteStr, out int bytes)) continue;

                dict[dateKey] = dict.GetValueOrDefault(dateKey) + bytes;
            }
        }
        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    ////////////////////////////////////////////// 3. Parallel.* \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double ParallelFor()
    {
        var dictionary = new ConcurrentDictionary<string, int>();
        var logsArray = _logs.ToArray();

        Parallel.For(0, logsArray.Length, i =>
        {
            var log = logsArray[i];
            var parts = log.Split(' ');

            if (parts.Length < 10 || !parts[3].StartsWith("["))
                return;

            try
            {
                string dateKey = parts[3].Substring(1, 11);
                int bytes = int.Parse(parts[9]);

                // Безопасно обновляем значение в ConcurrentDictionary
                dictionary.AddOrUpdate(dateKey, bytes, (key, existing) => existing + bytes);
            }
            catch
            {
                // Игнорируем ошибки парсинга (битые строки)
            }
        });

        // Защита от пустого словаря
        return dictionary.Count == 0 ? 0.0 : dictionary.Values.Average();
    }

    [Benchmark]
    public double ParallelForEach()
    {
        var dict = new ConcurrentDictionary<string, int>();
        Parallel.ForEach(_logs, log =>
        {
            var parts = log.Split(' ');
            if (parts.Length < 10 || !parts[3].StartsWith("[")) return;
            try
            {
                string key = parts[3].Substring(1, 11);
                int bytes = int.Parse(parts[9]);
                dict.AddOrUpdate(key, bytes, (_, v) => v + bytes);
            }
            catch { }
        });
        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double Custom_Partitioner()
    {
        var dict = new ConcurrentDictionary<string, int>();
        var partitioner = Partitioner.Create(_logs, true);

        Parallel.ForEach(partitioner, log =>
        {
            var p = log.Split(' ');
            if (p.Length < 10 || !p[3].StartsWith("[")) return;
            try
            {
                string k = p[3].Substring(1, 11);
                int b = int.Parse(p[9]);
                dict.AddOrUpdate(k, b, (_, v) => v + b);
            }
            catch { }
        });

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public async Task<double> ParallelForEachAsync()
    {
        var dict = new ConcurrentDictionary<string, int>();

        await Parallel.ForEachAsync(_logs, (log, cancellationToken) =>
        {
            var parts = log.Split(' ');
            if (parts.Length >= 10 &&
                parts[3].StartsWith("[") &&
                parts[3].Length >= 13 &&
                int.TryParse(parts[9], out int bytes))
            {
                string dateKey = parts[3].Substring(1, 11);
                dict.AddOrUpdate(dateKey, bytes, (_, existing) => existing + bytes);
            }
            return default; // синхронный ValueTask
        });

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }
    
    //////////////////////////////////////////////// 4. PLINQ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double PLINQ()
    {
        var result = _logs.AsParallel().Select(log =>
        {
            var parts = log.Split(' ');

            if (parts.Length < 10 || !parts[3].StartsWith("["))
                return (dateKey: (string?)null, bytes: 0);

            try
            {
                string dateKey = parts[3].Substring(1, 11);
                int bytes = int.Parse(parts[9]);
                return (dateKey, bytes);
            }
            catch
            {
                return (null, 0);
            }
        })
        .Where(x => x.dateKey != null) // отбрасываем ошибки
        .GroupBy(x => x.dateKey!, x => x.bytes) // группируем по дню
        .ToDictionary(g => g.Key, g => g.Sum()); // суммируем байты за день

        return result.Count == 0 ? 0.0 : result.Values.Average();
    }

    [Benchmark]
    public double PLINQ_FixedDegree()
    {
        var result = _logs
            .AsParallel()
            .WithDegreeOfParallelism(Environment.ProcessorCount)
            .Select(log =>
            {
                var parts = log.Split(' ');
                if (parts.Length < 10 || !parts[3].StartsWith("["))
                    return (dateKey: (string?)null, bytes: 0);

                if (parts[3].Length < 13) return (null, 0);

                string dateKey = parts[3].Substring(1, 11);
                if (!int.TryParse(parts[9], out int bytes))
                    return (null, 0);

                return (dateKey, bytes);
            })
            .Where(x => x.dateKey != null)
            .GroupBy(x => x.dateKey!, x => x.bytes)
            .ToDictionary(g => g.Key, g => g.Sum());

        return result.Count == 0 ? 0.0 : result.Values.Average();
    }

    /////////////////////////////////////////// 5. Task-ориентированные \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double TaskFactory()
    {
        var logs = _logs;
        int coreCount = Environment.ProcessorCount; // количество ядер
        int total = logs.Count;
        int chunkSize = total / coreCount;
        if (chunkSize == 0) chunkSize = 1; // на случай, если логов < ядер

        var tasks = new Task<Dictionary<string, int>>[coreCount];

        for (int i = 0; i < coreCount; i++)
        {
            int start = i * chunkSize;
            int end = (i == coreCount - 1) ? total : Math.Min(start + chunkSize, total);

            // Захватываем локальные переменные
            tasks[i] = Task.Factory.StartNew(() =>
            {
                var localDict = new Dictionary<string, int>();
                for (int j = start; j < end; j++)
                {
                    var parts = logs[j].Split(' ');
                    if (parts.Length < 10 || !parts[3].StartsWith("["))
                        continue;

                    try
                    {
                        string dateKey = parts[3].Substring(1, 11);
                        int bytes = int.Parse(parts[9]);
                        localDict[dateKey] = localDict.GetValueOrDefault(dateKey) + bytes;
                    }
                    catch
                    {
                        // Игнорируем ошибки парсинга
                    }
                }
                return localDict;
            });
        }

        // Ждём завершения всех задач
        Task.WaitAll(tasks);

        // Объединяем результаты из всех потоков
        var finalDict = new Dictionary<string, int>();
        foreach (var task in tasks)
        {
            foreach (var kvp in task.Result)
            {
                finalDict[kvp.Key] = finalDict.GetValueOrDefault(kvp.Key) + kvp.Value;
            }
        }

        return finalDict.Count == 0 ? 0.0 : finalDict.Values.Average();
    }

    [Benchmark]
    public async Task<double> TaskWhenAll_Chunks()
    {
        var logs = _logs;
        int coreCount = Environment.ProcessorCount;
        int total = logs.Count;
        int chunkSize = Math.Max(1, total / coreCount);

        var tasks = new List<Task<Dictionary<string, int>>>();

        for (int i = 0; i < coreCount; i++)
        {
            int start = i * chunkSize;
            int end = (i == coreCount - 1) ? total : Math.Min(start + chunkSize, total);
            tasks.Add(Task.Run(() =>
            {
                var local = new Dictionary<string, int>();
                for (int j = start; j < end; j++)
                {
                    var p = logs[j].Split(' ');
                    if (p.Length < 10 || !p[3].StartsWith("[")) continue;
                    try
                    {
                        string k = p[3].Substring(1, 11);
                        int b = int.Parse(p[9]);
                        local[k] = local.GetValueOrDefault(k) + b;
                    }
                    catch { }
                }
                return local;
            }));
        }

        var results = await Task.WhenAll(tasks);
        var final = new Dictionary<string, int>();
        foreach (var dict in results)
            foreach (var kvp in dict)
                final[kvp.Key] = final.GetValueOrDefault(kvp.Key) + kvp.Value;

        return final.Count == 0 ? 0.0 : final.Values.Average();
    }

    /////////////////////////////////////////// 6. Низкоуровневые потоки \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public double Thread_Raw()
    {
        var logs = _logs;
        int coreCount = Environment.ProcessorCount;
        int total = logs.Count;
        int chunkSize = Math.Max(1, total / coreCount);

        var results = new Dictionary<string, int>[coreCount];
        var threads = new Thread[coreCount];

        for (int i = 0; i < coreCount; i++)
        {
            int idx = i;
            int start = idx * chunkSize;
            int end = (idx == coreCount - 1) ? total : Math.Min(start + chunkSize, total);

            threads[idx] = new Thread(() =>
            {
                var local = new Dictionary<string, int>();
                for (int j = start; j < end; j++)
                {
                    var p = logs[j].Split(' ');
                    if (p.Length < 10 || !p[3].StartsWith("[")) continue;
                    try
                    {
                        string k = p[3].Substring(1, 11);
                        int b = int.Parse(p[9]);
                        local[k] = local.GetValueOrDefault(k) + b;
                    }
                    catch { }
                }
                results[idx] = local;
            });
            threads[idx].Start();
        }

        foreach (var t in threads) t.Join();

        var final = new Dictionary<string, int>();
        foreach (var dict in results.Where(d => d != null))
            foreach (var kvp in dict)
                final[kvp.Key] = final.GetValueOrDefault(kvp.Key) + kvp.Value;

        return final.Count == 0 ? 0.0 : final.Values.Average();
    }

    //////////////////////////////////////// 7. Асинхронные потоковые модели \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Benchmark]
    public async Task<double> Channels_Parallel()
    {
        var channel = Channel.CreateUnbounded<string>();
        var writer = channel.Writer;

        // Producer
        _ = Task.Run(async () =>
        {
            foreach (var log in _logs) await writer.WriteAsync(log);
            writer.Complete();
        });

        // Consumers
        int coreCount = Environment.ProcessorCount;
        var consumers = new Task<Dictionary<string, int>>[coreCount];
        for (int i = 0; i < coreCount; i++)
        {
            consumers[i] = Task.Run(async () =>
            {
                var local = new Dictionary<string, int>();
                var reader = channel.Reader;
                while (await reader.WaitToReadAsync())
                {
                    while (reader.TryRead(out var log))
                    {
                        var p = log.Split(' ');
                        if (p.Length < 10 || !p[3].StartsWith("[")) continue;
                        try
                        {
                            string k = p[3].Substring(1, 11);
                            int b = int.Parse(p[9]);
                            local[k] = local.GetValueOrDefault(k) + b;
                        }
                        catch { }
                    }
                }
                return local;
            });
        }

        var results = await Task.WhenAll(consumers);
        var final = new Dictionary<string, int>();
        foreach (var dict in results)
            foreach (var kvp in dict)
                final[kvp.Key] = final.GetValueOrDefault(kvp.Key) + kvp.Value;

        return final.Count == 0 ? 0.0 : final.Values.Average();
    }

    [Benchmark]
    public async Task<double> Dataflow_Block()
    {
        var dict = new ConcurrentDictionary<string, int>();

        var transform = new TransformBlock<string, (string key, int bytes)>(log =>
        {
            var p = log.Split(' ');
            if (p.Length < 10 || !p[3].StartsWith("["))
                return (key: "", bytes: -1);
            try
            {
                return (key: p[3].Substring(1, 11), bytes: int.Parse(p[9]));
            }
            catch
            {
                return (key: "", bytes: -1);
            }
        });

        var action = new ActionBlock<(string key, int bytes)>(item =>
        {
            if (item.bytes >= 0)
                dict.AddOrUpdate(item.key, item.bytes, (_, v) => v + item.bytes);
        });

        transform.LinkTo(action, new DataflowLinkOptions { PropagateCompletion = true });

        foreach (var log in _logs)
            await transform.SendAsync(log);

        transform.Complete();
        await action.Completion;

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    [Benchmark]
    public double RxNET_Observable() //Не параллельный метод
    {
        var result = new Subject<double>();
        var dict = new ConcurrentDictionary<string, int>();

        _logs
            .ToObservable()
            .Select(log =>
            {
                var p = log.Split(' ');
                if (p.Length < 10 || !p[3].StartsWith("[")) return ("", -1);
                try { return (p[3].Substring(1, 11), int.Parse(p[9])); }
                catch { return ("", -1); }
            })
            .Where(x => x.Item2 >= 0)
            .Subscribe(x => dict.AddOrUpdate(x.Item1, x.Item2, (_, v) => v + x.Item2));

        return dict.Count == 0 ? 0.0 : dict.Values.Average();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public double DebugPrint()
    {
        var dictionary = new Dictionary<string, int>();

        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            if (elementLog.Length < 10) continue;

            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        //var sorted = dictionary.OrderBy(pair => pair.Key);
        //foreach (var kvp in sorted)
        //{
        //    Console.WriteLine(kvp.Key + " - " + kvp.Value);
        //}

        return dictionary.Values.Average();
    }
}