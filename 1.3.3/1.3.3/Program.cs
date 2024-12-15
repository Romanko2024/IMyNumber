using System;

class Program
{
    static void Main()
    {
        // нмовні ймовірності
        double p11 = 0.16;  // p(x1 / x1)
        double p12 = 0.84;  // p(x2 / x1)
        double p21 = 0.52;  // p(x1 / x2)
        double p22 = 0.48;  // p(x2 / x2)

        // тривалості символів
        double tau1 = 7.6;
        double tau2 = 2.1;

        // розв'язуємо систему рівнянь для знаходження стаціонарних ймовірностей
        double[] stationaryProbabilities = FindStationaryProbabilities(p11, p12, p21, p22);
        double pX1 = stationaryProbabilities[0];
        double pX2 = stationaryProbabilities[1];

        // обчислюємо ентропію H(X)
        double entropy = CalculateEntropy(pX1, pX2, p11, p12, p21, p22);
        Console.WriteLine($"Ентропія H(X) = {entropy}");

        // обчислюємо середню тривалість символів
        double averageDuration = pX1 * tau1 + pX2 * tau2;

        // обчислюємо продуктивність R(X)
        double productivity = entropy / averageDuration;
        Console.WriteLine($"Продуктивність R(X) = {productivity}");

        // обчислюємо максимальну продуктивність R_max
        double R_max = Math.Log(2, 2) / averageDuration; 

        // обчислюємо надмірність D(X)
        double redundancy = 1 - (productivity / R_max);
        Console.WriteLine($"Надмірність D(X) = {redundancy}");
    }

    // знаходження стаціонарних ймовірностей
    static double[] FindStationaryProbabilities(double p11, double p12, double p21, double p22)
    {
        // системa рівнянь
        double pX1 = (p21) / (p12 + p21);
        double pX2 = 1 - pX1;

        return new double[] { pX1, pX2 };
    }

    // функція для обчислення ентропії H(X)
    static double CalculateEntropy(double pX1, double pX2, double p11, double p12, double p21, double p22)
    {
        double entropy = 0;

        if (p11 > 0)
            entropy -= pX1 * p11 * Math.Log(p11, 2);
        if (p12 > 0)
            entropy -= pX1 * p12 * Math.Log(p12, 2);
        if (p21 > 0)
            entropy -= pX2 * p21 * Math.Log(p21, 2);
        if (p22 > 0)
            entropy -= pX2 * p22 * Math.Log(p22, 2);

        return entropy;
    }
}
