using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Sin(Math.Pow(x, 3)) + Math.Pow(x, 4) + Math.Pow(Math.Pow(x, 2) + Math.Pow(x, 3), 1.0 / 5);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
