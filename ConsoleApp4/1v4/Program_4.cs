using System;
using System.Text;
using System.Diagnostics;

class Program_4
{
    static void Main()
    {
        double memoryUsed = GC.GetTotalMemory(true);

        int n = int.Parse(Console.ReadLine());

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        StringBuilder result = new StringBuilder();

        for (int i = n; i >= 1; i--)
        {
            result.Insert(0, i + " ");
            //Console.WriteLine(result); // Виведення проміжного стану рядка
        }

        Console.WriteLine(result.ToString());

        stopwatch.Stop();
        Console.WriteLine($"Час виконання: {stopwatch.Elapsed}");

        memoryUsed = GC.GetTotalMemory(true) - memoryUsed;
        Console.WriteLine($"Використана пам'ять: {memoryUsed} байт");
    }
}
