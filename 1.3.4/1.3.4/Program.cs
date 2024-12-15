using System;

class Program
{
    static void Main()
    {
        // ймовірності для Y
        double[] pY = { 0.257, 0.504, 0.239 };
        double[,] pYGivenX = {
            { 0.17, 0.33, 0.50 },  // p(y_i | x1)
            { 0.27, 0.53, 0.20 }   // p(y_i | x2)
        };

        // обчислення p(x1) за допомогою формули
        double[] pX1_values = new double[3];
        for (int i = 0; i < 3; i++)
        {
            double numerator = pY[i] - pYGivenX[1, i];
            double denominator = pYGivenX[0, i] - pYGivenX[1, i];
            pX1_values[i] = numerator / denominator;
        }

        // система рівнянь узгоджена, беремо середнє значення p(x1)
        double pX1 = (pX1_values[0] + pX1_values[1] + pX1_values[2]) / 3.0;
        double pX2 = 1.0 - pX1;

        Console.WriteLine($"p(x1) = {pX1}");
        Console.WriteLine($"p(x2) = {pX2}");

        // функція для обчислення ентропії
        double Entropy(double[] probabilities)
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

        // ентропія H(Y)
        double HY = Entropy(pY);
        

        // ентропія H(Y | X)
        double HYGivenX = 0;
        double[] pX = { pX1, pX2 };
        for (int x = 0; x < 2; x++)
        {
            double entropyGivenX = 0;
            for (int y = 0; y < 3; y++)
            {
                if (pYGivenX[x, y] > 0)
                {
                    entropyGivenX -= pYGivenX[x, y] * Math.Log(pYGivenX[x, y], 2);
                }
            }
            HYGivenX += pX[x] * entropyGivenX;
        }

        // взаємна інформація I(X, Y)
        double IXY = HY - HYGivenX;
        Console.WriteLine($"I(X, Y) = {IXY}");

        // Ентропія H(X, Y)
        double HXY = 0;
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                double jointProbability = pX[x] * pYGivenX[x, y];
                if (jointProbability > 0)
                {
                    HXY -= jointProbability * Math.Log(jointProbability, 2);
                }
            }
        }
        Console.WriteLine($"H(X, Y) = {HXY}");

        // ентропія H(X)
        double HX = Entropy(pX);
        

        // надмірність джерел
        double redundancyX = 1 - (HX / Math.Log(2, 2)); 
        double redundancyY = 1 - (HY / Math.Log(3, 2)); 

        Console.WriteLine($"Надмірність джерела X: {redundancyX}");
        Console.WriteLine($"Надмірність джерела Y: {redundancyY}");
    }
}

