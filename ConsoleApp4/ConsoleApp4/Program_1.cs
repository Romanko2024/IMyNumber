using System;
using System.Diagnostics;

class Program_1
{
    static void Main()
    {
        double memoryUsed = GC.GetTotalMemory(true);

        int n = int.Parse(Console.ReadLine());

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string result = "";

        for (int i = 1; i <= n; i++)
        {
            result += i + " ";
            //Console.WriteLine(result); // Виведення проміжного стану рядка
        }

        Console.WriteLine(result);

        stopwatch.Stop();
        Console.WriteLine($"Час виконання: {stopwatch.Elapsed}");

        memoryUsed = GC.GetTotalMemory(true) - memoryUsed;
        Console.WriteLine($"Використана пам'ять: {memoryUsed} байт");
    }
}
