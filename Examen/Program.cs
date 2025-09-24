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
using System.Collections.Immutable;

internal class Program
{
    private static void Main(string[] args)
    {
        Examen examen = new Examen();
        examen.Setup();
        Console.WriteLine("TEST - " + examen.DebugPrint());

        BenchmarkRunner.Run<Examen>();
    }
}

public class Examen
{
    List<string> _logs = [];
    bool write = true;
    bool write1 = true;
    bool write2 = true;
    bool write3 = true;
    bool write4 = true;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        var filePath = "web_access.log";
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

        // Диапазон дат: с 1 января 2025 по сегодня (10 апреля 2025)
        var startDate = new DateTime(2025, 1, 1);
        var endDate = new DateTime(2025, 4, 10);
        var totalDays = (endDate - startDate).Days + 1;

        using (var writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < 1000; i++)
            {
                // Случайный IP из документационных диапазонов
                string ip = $"203.0.113.{random.Next(1, 255)}";

                // Случайная дата
                var randomDate = startDate.AddDays(random.Next(0, totalDays))
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
        Console.WriteLine($"===========| \x1b[38;2;64;224;208mCreated file '{filePath}' with 1000 log entries!\x1b[0m |===========");
        Console.WriteLine($"\t   +------------------------------------------------------+");
        Console.WriteLine(" ");
        Console.WriteLine("\x1b[38;2;64;224;208mWorking dir: " + Directory.GetCurrentDirectory() + "\x1b[0m");
        Console.WriteLine(" ");

        _logs = [.. File.ReadLines(filePath)];        
    }

    [Benchmark]
    public double ArrayFor()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        var avg = dictionary.Values.Average();
        if (write) Console.WriteLine("\x1b[38;2;64;224;208mTEST - " + avg + "\x1b[0m");
        write = false;
        return avg;
    }
    [Benchmark]
    public double ArrayFor1()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        var avg = dictionary.Values.Average();
        if (write1) Console.WriteLine("\x1b[38;2;64;224;208mTEST - " + avg + "\x1b[0m");
        write1 = false;
        return avg;
    }
    [Benchmark]
    public double ArrayFor2()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        var avg = dictionary.Values.Average();
        if (write2) Console.WriteLine("\x1b[38;2;64;224;208mTEST - " + avg + "\x1b[0m");
        write2 = false;
        return avg;
    }
    [Benchmark]
    public double ArrayFor3()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        var avg = dictionary.Values.Average();
        if (write3) Console.WriteLine("\x1b[38;2;64;224;208mTEST - " + avg + "\x1b[0m");
        write3 = false;
        return avg;
    }
    [Benchmark]
    public double ArrayFor4()
    {
        Dictionary<string, int> dictionary = [];
        foreach (var log in _logs)
        {
            string[] elementLog = log.Split(' ');
            string dataTime = elementLog[3].Substring(1, 11);
            int bytes = int.Parse(elementLog[9]);

            dictionary[dataTime] = dictionary.GetValueOrDefault(dataTime) + bytes;
        }

        var avg = dictionary.Values.Average();
        if (write4) Console.WriteLine("\x1b[38;2;64;224;208mTEST - " + avg + "\x1b[0m");
        write4 = false;
        return avg;
    }

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