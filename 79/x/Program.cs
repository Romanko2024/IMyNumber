using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Asin(Math.Abs(x + 1));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
