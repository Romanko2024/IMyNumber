using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = x + 1 / (Math.Pow(x, 3) - x) - 2;

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}