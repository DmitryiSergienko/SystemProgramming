using ScottPlot;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string csvPath = @"..\..\..\..\Examen\bin\Release\net9.0\BenchmarkDotNet.Artifacts\results\Examen-report.csv";
        string pngPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "benchmark_results.png");

        if (!File.Exists(csvPath))
        {
            Console.WriteLine("❌ Сначала запустите бенчмарк в папке Examen");
            return;
        }

        try
        {
            var lines = File.ReadAllLines(csvPath);
            var data = lines
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(line =>
                {
                    var parts = line.Split(';');
                    if (parts.Length < 49) return null;

                    string method = parts[0].Trim('"');
                    string meanStrRaw = parts[45].Trim('"');

                    double microseconds = 0.0;

                    if (meanStrRaw.Contains("μs"))
                    {
                        string clean = meanStrRaw.Replace(" μs", "").Replace(",", "");
                        if (!double.TryParse(clean, NumberStyles.Float, CultureInfo.InvariantCulture, out double us))
                            return null;
                        microseconds = us;
                    }
                    else if (meanStrRaw.Contains("ms"))
                    {
                        string clean = meanStrRaw.Replace(" ms", "").Replace(",", "");
                        if (!double.TryParse(clean, NumberStyles.Float, CultureInfo.InvariantCulture, out double ms))
                            return null;
                        microseconds = ms * 1000.0;
                    }
                    else
                    {
                        return null;
                    }

                    return new { Method = method, Mean = microseconds };
                })
                .Where(x => x != null)
                .OrderBy(x => x.Mean)
                .ToArray();

            if (data.Length == 0)
            {
                Console.WriteLine("❌ Не удалось извлечь данные из CSV");
                return;
            }

            var methods = data.Select(d => d.Method).ToArray();
            var means = data.Select(d => d.Mean).ToArray();
            var positions = Enumerable.Range(0, means.Length).Select(i => (double)i).ToArray();

            var plot = new Plot();
            plot.Add.Bars(positions, means);

            plot.Title("Сравнение производительности методов");
            plot.XLabel("Метод");
            plot.YLabel("Время выполнения (микросекунды)");

            // Настройка подписей по оси X с поворотом
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions, methods);
            plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.LowerCenter;

            plot.Axes.SetLimitsX(-0.5, means.Length - 0.5);

            plot.SavePng(pngPath, 1200, 800);
            Console.WriteLine($"✅ График сохранён: {Path.GetFullPath(pngPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Ошибка: {ex.Message}");
        }
    }
}