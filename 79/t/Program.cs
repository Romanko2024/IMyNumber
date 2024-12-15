using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = (5 * Math.Pow(x, 3)) * Math.Pow((1 / Math.Pow(x, 2) + 1 / Math.Pow(x, 3)), 1.0 / 5);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}

