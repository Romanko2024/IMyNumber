using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Sqrt(x + Math.Pow(Math.Abs(x), 1.0 / 4)) + Math.Abs(x);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
