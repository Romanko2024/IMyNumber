using System;

class Program_2
{
    private static void Main()
    {
        Console.Write("");
        double x = Convert.ToDouble(Console.ReadLine());

        double result = Convert.ToDouble(Math.Sin(x) + Math.Pow(x, 3) + 1 / (Math.Pow(x, 2) + 1));

        Console.WriteLine(result);
    }
}
