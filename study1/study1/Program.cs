using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть довжину ребра куба: ");
        double length = Convert.ToDouble(Console.ReadLine());

        double surfaceArea = 6 * Math.Pow(length, 2);

        Console.WriteLine($"Повна площа куба дорівнює {surfaceArea}");
    }
}
