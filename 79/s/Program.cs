using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = 7 * Math.Atan(Math.Pow(x, 2));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
