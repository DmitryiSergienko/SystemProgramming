using System.Collections.Concurrent;

class ConcurrentBagDemo
{
    // Demonstrates:
    //      ConcurrentBag<T>.Add()
    //      ConcurrentBag<T>.IsEmpty
    //      ConcurrentBag<T>.TryTake()
    //      ConcurrentBag<T>.TryPeek()
    static void Main()
    {
        int a = 0;
        while (true)
        {
            a++;
            // Add to ConcurrentBag concurrently
            ConcurrentBag<int> cb = new ConcurrentBag<int>();
            List<int> list = new List<int>();
            List<Task> bagAddTasks = new List<Task>();
            for (int i = 0; i < 1000000; i++)
            {
                var numberToAdd = i;
                bagAddTasks.Add(Task.Run(() => { cb.Add(numberToAdd); list.Add(numberToAdd); }));
            }

            // Wait for all tasks to complete
            Task.WaitAll(bagAddTasks.ToArray());

            Console.WriteLine($"Элеметов в cb: {cb.Count}");
            Console.WriteLine($"Элеметов в list: {list.Count}");
            //Console.WriteLine(String.Join(", ", list));

            // Consume the items in the bag
            List<Task> bagConsumeTasks = new List<Task>();
            int itemsInBag = 0;
            while (!cb.IsEmpty)
            {
                bagConsumeTasks.Add(Task.Run(() =>
                {
                    int item;
                    if (cb.TryTake(out item))
                    {
                        //Console.WriteLine(item);
                        Interlocked.Increment(ref itemsInBag);
                    }
                }));
            }
            Task.WaitAll(bagConsumeTasks.ToArray());

            //Console.WriteLine($"There were {itemsInBag} items in the bag");

            // Checks the bag for an item
            // The bag should be empty and this should not print anything
            int unexpectedItem;
            if (cb.TryPeek(out unexpectedItem))
                Console.WriteLine("Found an item in the bag when it should be empty");
            if(list.Count == 1000000) break;
        }
        Console.WriteLine($"Всего: {a}");
    }
}