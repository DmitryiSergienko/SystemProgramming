/*
    pt4.pdf
    Array18-32 по списку
    Выполнить задание с обычным циклом (массивом) и СoncurrentBag с ParallelFor
    Сравнить их по времени (размер массива регулируйте сами, но большой)
    Измерение времени пока через класс StopWatch

    Array32◦
    Дан массив размера N. Найти номер его первого локального минимума (локальный минимум — это элемент, который меньше любого из
    своих соседей).*/
using System.Collections.Concurrent;

Random rand = new Random();
const int COUNT = 100;

int[] array = new int[COUNT];
ConcurrentBag<int> cb = new ConcurrentBag<int>();

for (int i = 0; i < COUNT; i++)
{
    array[i] = rand.Next(1, 101);
    cb.Add(array[i]);
}

Console.WriteLine(String.Join(" ", cb));