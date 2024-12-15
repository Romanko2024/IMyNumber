using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(2, -x) * Math.Sqrt(x + Math.Pow(Math.Abs(x), 1.0 / 4.0));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
