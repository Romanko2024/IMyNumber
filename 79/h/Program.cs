using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Sqrt(Math.Abs(Math.Pow(x, 3) - 1)) - 7 * Math.Cos(Math.Pow((Math.Pow(x, 4) + x), 1.0 / 3));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
