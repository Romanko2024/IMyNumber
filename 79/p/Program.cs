using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Sqrt(Math.Sin(x) + Math.Abs(Math.Pow(x, 2) + x));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
