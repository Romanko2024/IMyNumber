using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть максимальний знаменник n:");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            PrintAllFracs(n);
        }
        else
        {
            Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
        }
    }

    static void PrintAllFracs(int n)
    {
        for (int denominator = 2; denominator <= n; denominator++)
        {
            for (int numerator = 1; numerator < denominator; numerator++)
            {
                if (IsFracIrreducible(numerator, denominator))
                {
                    Console.WriteLine($"{numerator}/{denominator}");
                }
            }
        }
    }

    static bool IsFracIrreducible(int numerator, int denominator)
    {
        int gcd = CalcGreatestCommonDivisor(numerator, denominator);
        return gcd == 1;
    }

    static int CalcGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}