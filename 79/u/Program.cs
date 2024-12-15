using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(Math.Exp(x) - Math.Sin(x), 1.0 / 3.0);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
