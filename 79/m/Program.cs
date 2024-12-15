using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(Math.Pow(Math.E, x) + Math.Tan(x), 1.0 / 3.0) + 1.0 / x;

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
