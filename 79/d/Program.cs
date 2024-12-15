using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(x - Math.Pow(x, 2) + Math.Pow(x, 5), 1.0 / 3.0);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
