using System;

class Program
{
    static void Main(string[] args)
    {
        string[] input1 = Console.ReadLine().Split(' ');
        double a = double.Parse(input1[0]);
        double b = double.Parse(input1[1]);
        double c = double.Parse(input1[2]);

        string[] input2 = Console.ReadLine().Split();
        double h = double.Parse(input2[0]);
        double l = double.Parse(input2[1]);

        double area = 2 * (a * c + b * c) + (a * b);
        area *= 0.85;

        double rolls = Math.Ceiling(area / (h * l / 1000000) * 1.1);

        Console.WriteLine((int)rolls);
    }
}