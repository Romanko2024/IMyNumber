using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(x, 4) - Math.Cos(Math.Asin(x));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}