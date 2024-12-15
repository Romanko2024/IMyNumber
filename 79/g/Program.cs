using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(Math.Pow(x, 3) + Math.Pow(x, 4), 1.0 / 5) + Math.Cos(Math.Atan(Math.Pow(x, 2)));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}