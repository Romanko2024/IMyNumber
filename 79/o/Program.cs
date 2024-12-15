using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = 1 + x * Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Sin(x), 3);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
