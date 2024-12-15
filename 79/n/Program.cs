using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(Math.Abs(x + 1), 1.0 / 4.0) + 1.0 / Math.Pow(x, 2);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
