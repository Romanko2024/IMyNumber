using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] sides = input.Split(' ');

        double a = Convert.ToDouble(sides[0]);
        double b = Convert.ToDouble(sides[1]);
        double c = Convert.ToDouble(sides[2]);

        string triangleType = DetermineTriangleType(a, b, c);
        Console.WriteLine(triangleType);
    }

    static string DetermineTriangleType(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return "incorrect data.";
        }
        else if (a + b <= c || a + c <= b || b + c <= a)
        {
            return "Triangle does not exist.";
        }
        else if (a == b && b == c)
        {
            return "Equilateral triangle.";
        }
        else if (a == b || a == c || b == c)
        {
            return "Isosceles triangle.";
        }
        else
        {
            return "Sided triangle.";
        }
    }
}