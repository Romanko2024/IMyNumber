using System;

class Program
{
    // Функція для обчислення біноміального коефіцієнта
    static long BinomialCoefficient(int n, int k)
    {
        if (k > n) return 0;
        if (k == 0 || k == n) return 1;

        long result = 1;
        for (int i = 0; i < k; i++)
        {
            result *= (n - i);
            result /= (i + 1);
        }
        return result;
    }

    static void Main()
    {
        int n = 2000; // Загальна кількість випробувань
        int k = 3;    // Кількість успіхів (поява події)
        double p = 0.001; // Ймовірність появи події в одному випробуванні

        // Обчислення біноміального коефіцієнта
        long binomCoeff = BinomialCoefficient(n, k);

        // Обчислення ймовірності
        double probability = binomCoeff * Math.Pow(p, k) * Math.Pow(1 - p, n - k);

        // Виведення результату з округленням до 6 знаків після коми
        Console.WriteLine("Ймовірність появи події 3 рази в 2000 випробуваннях: " + Math.Round(probability, 6));
    }
}