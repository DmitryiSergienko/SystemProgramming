/*
    pt4.pdf
    Array18-32 по списку
    Выполнить задание с обычным циклом (массивом) и СoncurrentBag с ParallelFor
    Сравнить их по времени (размер массива регулируйте сами, но большой)
    Измерение времени пока через класс StopWatch

    Array32◦
    Дан массив размера N. Найти номер его первого локального минимума 
    (локальный минимум — это элемент, который меньше любого из своих соседей).
*/
using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Random rand = new Random();
        const int COUNT = 100_000_000;

        int[] array = new int[COUNT];
        ConcurrentBag<int> cb = new ConcurrentBag<int>();

        var stopwatchArray = Stopwatch.StartNew();
        Task arrayTask = Task.Run(() =>
        {
            for (int i = 0; i < COUNT; i++)
            {
                array[i] = rand.Next(1, 101);
            }

            int localMinArray = SearchFirstLocalMinimum(array);
            if (localMinArray > 0)
            {
                Console.WriteLine($"Индекс первого локального минимума для массива: {localMinArray} - {array[localMinArray]}");
            }
            else
            {
                Console.WriteLine("Локальный минимум для массива отсутствует");
            }
        });
        arrayTask.Wait();
        stopwatchArray.Stop();
        
        var stopwatchCB = Stopwatch.StartNew();
        Task cbTask = Task.Run(() =>
        {
            var range = Enumerable.Range(0, COUNT);
            Parallel.ForEach(range, i =>
            {
                cb.Add(rand.Next(1, 101));
            });

            int localMinCB = SearchFirstLocalMinimum(cb.ToArray());
            if (localMinCB > 0)
            {
                Console.WriteLine($"Индекс первого локального минимума для списка: {localMinCB} - {cb.ToArray()[localMinCB]}");
            }
            else
            {
                Console.WriteLine("Локальный минимум для списка отсутствует");
            }
        });
        cbTask.Wait();
        stopwatchCB.Stop();

        //Console.WriteLine("\nЭлементы массива:\n" + string.Join(" ", array));
        //Console.WriteLine("\nЭлементы списка:\n" + string.Join(" ", cb));

        Console.WriteLine($"\nВремя на выполнение алгоритма с массивом: {stopwatchArray.ElapsedMilliseconds} мс");
        Console.WriteLine($"Время на выполнение алгоритма со списком: {stopwatchCB.ElapsedMilliseconds} мс");        
    }
    public static int SearchFirstLocalMinimum(int[] arr)
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
            {
                return i;
            }
        }
        return -1;
    }
}