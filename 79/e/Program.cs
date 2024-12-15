using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Tan(x) - Math.Pow(5 - x, 4);

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
