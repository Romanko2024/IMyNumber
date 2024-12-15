using System;

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Math.Cos(Math.Atan(x));

        Console.WriteLine($"{result}");
        Console.ReadLine();
    }
}
