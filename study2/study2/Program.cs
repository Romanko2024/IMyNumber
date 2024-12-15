using System;

class Program_3
{
    static void Main()
    {
        Console.WriteLine("");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("");
        double y = Convert.ToDouble(Console.ReadLine());

        

       
    }

    static bool IsPointInsideArea(double x, double y)
    {
        bool isInsideSemicircle = x >= -1 && x <= 0 && x * x + y * y <= 1;

        bool isInsideTriangle = y >= -1 + x && y <= 1 - x && x >= 0 && x <= 1 - y;

        return isInsideSemicircle || isInsideTriangle;

        bool isInside = IsPointInsideArea(x, y);

        if (isInside)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
