using System;

class Program
{
    static void Main()
    {
        // спільні ймовірності p(x_i, y_j)
        double[,] jointProbabilities = {
            { 0.22, 0.09, 0.18 }, // p(x1, y1), p(x1, y2), p(x1, y3)
            { 0.18, 0.11, 0.22 }  // p(x2, y1), p(x2, y2), p(x2, y3)
        };

        int M = 2; // кількість символів у алфавіті X
        int N = 3; // кількість символів у алфавіті Y

        // обчислюємо маргінальні ймовірності p(x_i) і p(y_j)
        double[] pX = new double[M];
        double[] pY = new double[N];

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                pX[i] += jointProbabilities[i, j];
                pY[j] += jointProbabilities[i, j];
            }
        }

        // обчислюємо ентропію H(X, Y)
        double jointEntropy = 0;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (jointProbabilities[i, j] > 0)
                {
                    jointEntropy -= jointProbabilities[i, j] * Math.Log(jointProbabilities[i, j], 2);
                }
            }
        }
        Console.WriteLine($"Ентропія системи H(X, Y) = {jointEntropy}");

        // обчислюємо ентропію H(X)
        double entropyX = Entropy(pX);
        Console.WriteLine($"Ентропія H(X) = {entropyX}");

        // обчислюємо ентропію H(Y)
        double entropyY = Entropy(pY);
        Console.WriteLine($"Ентропія H(Y) = {entropyY}");

        // обчислюємо надмірність для X і Y
        double redundancyX = 1 - (entropyX / Math.Log(M, 2));
        double redundancyY = 1 - (entropyY / Math.Log(N, 2));

        Console.WriteLine($"Надмірність джерела X = {redundancyX}");
        Console.WriteLine($"Надмірність джерела Y = {redundancyY}");

        // перевіряємо незалежність джерел
        bool independent = true;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                double productOfMarginals = pX[i] * pY[j];
                if (Math.Abs(jointProbabilities[i, j] - productOfMarginals) > 1e-6)
                {
                    independent = false;
                    break;
                }
            }
        }

        if (independent)
        {
            Console.WriteLine("Джерела є статистично незалежними.");
        }
        else
        {
            Console.WriteLine("Джерела не є статистично незалежними.");
        }
    }

    // функція для обчислення ентропії
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
}