using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = (25 * Math.Pow(x, 5)) - Math.Sqrt(Math.Pow(x, 2) + x);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
