using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Pow(2, x) * x * Math.Cos(x) + 1;


        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
