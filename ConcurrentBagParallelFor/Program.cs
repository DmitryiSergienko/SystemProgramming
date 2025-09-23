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
        const int COUNT = 1_000_000;

        int[] array = new int[COUNT];
        ConcurrentBag<int> cb = new ConcurrentBag<int>();

        for (int i = 0; i < COUNT; i++)
        {
            array[i] = rand.Next(1, 1001);
            cb.Add(array[i]);
        }

        var stopwatchArray = Stopwatch.StartNew();
        Task arrayTask = Task.Run(() =>
        {
            int localMinArray = SearchMinLocalMinimumArray(array);

            if (localMinArray > 0)
            {
                Console.WriteLine($"Индекс минимального локального минимума для массива: {localMinArray} со значением: {array[localMinArray]}");
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
            int localMinCB = SearchMinLoacalMinimumCB(cb);
            if (localMinCB > 0)
            {
                Console.WriteLine($"Индекс минимального локального минимума для списка: {localMinCB} со значением: {cb.ToArray()[localMinCB]}");
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
    public static int SearchMinLocalMinimumArray(int[] arr)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
            {
                dictionary.Add(i, arr[i]);
            }
        }

        if (dictionary.Count > 0)
        {
            var min = dictionary.MinBy(i => i.Value);
            return min.Key;
        }
        return -1;
    }
    public static int SearchMinLoacalMinimumCB(ConcurrentBag<int> cb)
    {
        var list = cb.ToList();
        if (list.Count < 3) return -1;
        var dictionary = new ConcurrentDictionary<int, int>();
        
        var range = Enumerable.Range(1, list.Count - 2);
        Parallel.ForEach(range, i =>
        {
            if (list[i] < list[i - 1] && list[i] < list[i + 1])
            {
                dictionary.TryAdd(i, list[i]);
            }
        });

        if (dictionary.Count > 0)
        {
            var min = dictionary.MinBy(i => i.Value);
            return min.Key;
        }
        return -1;
    }
}