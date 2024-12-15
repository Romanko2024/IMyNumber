using System;

class Program
{
    static void Main()
    {
        // ймовірності появи символів
        double[] probabilities = { 0.26, 0.14, 0.5, 0.1 };
        // тривалості символів
        double[] durations = { 3.7, 2.1, 1.2, 1.5 };
        int M = probabilities.Length; // кількість символів в алфавіті

        // обчислюємо ентропію H(X)
        double entropy = Entropy(probabilities);
        Console.WriteLine($"Ентропія H(X) = {entropy}");

        // обчислюємо середню тривалість символів
        double averageDuration = AverageDuration(probabilities, durations);

        // обчислюємо продуктивність R(X)
        double productivity = entropy / averageDuration;
        Console.WriteLine($"Продуктивність R(X) = {productivity}");

        // обчислюємо максимальну продуктивність R_max
        double R_max = MaxProductivity(M, durations);

        // надмірність D(X)
        double redundancy = 1 - (productivity / R_max);
        Console.WriteLine($"Надмірність D(X) = {redundancy}");
    }

    // функція обчислення ентропії H(X)
    static double Entropy(double[] probabilities)
    {
        double entropy = 0;
        foreach (double p in probabilities)
        {
            if (p > 0)
            {
                entropy -= p * Math.Log(p, 2);
            }
        }
        return entropy;
    }

    // обчислення середньої тривалості символів
    static double AverageDuration(double[] probabilities, double[] durations)
    {
        double avgDuration = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            avgDuration += probabilities[i] * durations[i];
        }
        return avgDuration;
    }

    // обчислення максимальної продуктивності R_max
    static double MaxProductivity(int M, double[] durations)
    {
        double averageDurationMax = 0;
        foreach (double duration in durations)
        {
            averageDurationMax += duration;
        }
        averageDurationMax /= M;

        double maxEntropy = Math.Log(M, 2); // макс ентропія для M символів
        return maxEntropy / averageDurationMax;
    }
}