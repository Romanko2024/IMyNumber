using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Asin(x + Math.Pow(x, 2));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
