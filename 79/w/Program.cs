using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = 1 + 1 / x + 1 / Math.Pow(x, 2);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}

