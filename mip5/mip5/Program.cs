using System;
using System.Collections.Generic;

namespace NodeCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            //вхідні дані для вузлів збору інформації (вузли 1-8)
            var basicNodes = new (double lambda, double t, double c)[]
            {
                (10.0 / 22, 0.5, 20),
                (7.0 / 22, 0.8, 25),
                (8.0 / 22, 0.6, 18),
                (6.0 / 22, 1.2, 22),
                (9.0 / 22, 0.7, 30),
                (5.0 / 22, 1.5, 26),
                (6.0 / 22, 1.0, 24),
                (10.0 / 22, 0.4, 32)
            };

            //розрахунок для вузлів 1-8
            
            for (int i = 0; i < basicNodes.Length; i++)
            {
                var (lambda, t, c) = basicNodes[i];

                // формула для часу очікування T = (λ * t) / (1/t - λ)
                double waitingTime = (lambda * t) / (1 / t - lambda);

                //формула для загальних витрат C = λ * c
                double totalCost = lambda * c * 22;

                //вивід результату для кожного вузла
                Console.WriteLine($"Вузол {i + 1}: Час очікування = {waitingTime:F2}, Загальні витрати = {totalCost:F2}");
            }

            
            //вхідні дані для вузлів 9-14
            var complexNodes = new (int k, double gamma, List<(double lambda, double t, double c)> parameters)[]
            {
                (2, 1.3, new List<(double lambda, double t, double c)> { (10.0 / 22, 0.4, 28), (8.0 / 22, 0.8, 20) }),
                (2, 1.3, new List<(double lambda, double t, double c)> { (7.0 / 22, 0.6, 18), (9.0 / 22, 0.4, 28) }),
                (2, 1.1, new List<(double lambda, double t, double c)> { (6.0 / 22, 0.5, 24), (6.0 / 22, 0.5, 30) }),
                (2, 1.2, new List<(double lambda, double t, double c)> { (5.0 / 22, 0.7, 25), (10.0 / 22, 0.9, 22) }),
                (4, 3.2, new List<(double lambda, double t, double c)> { (10.0 / 22, 0.8, 25), (7.0 / 22, 0.5, 30), (8.0 / 22, 0.6, 26), (6.0 / 22, 0.4, 32) }),
                (4, 4.0, new List<(double lambda, double t, double c)> { (9.0 / 22, 0.5, 28), (5.0 / 22, 0.7, 22), (6.0 / 22, 0.6, 24), (10.0 / 22, 0.6, 24) })
            };

            //розрахунок для вузлів 9-14
            for (int i = 0; i < complexNodes.Length; i++)
            {
                var (k, gamma, parameters) = complexNodes[i];

                //обчислення значення R = ∑ (λ * t) / γ
                double R = 0;
                foreach (var (lambda, t, _) in parameters)
                {
                    double currentTerm = (lambda * t) / gamma;
                    //Console.WriteLine($"Додаємо до R: ({lambda} * {t}) / {gamma} = {currentTerm}");
                    R += currentTerm;
                }

                //обчислення часу очікування T = ∑ (λ * t^2) / (2 * (1 - R))
                double waitingTime = 0;
                foreach (var (lambda, t, _) in parameters)
                {
                    waitingTime += (lambda * Math.Pow(t, 2)) / (2 * (1 - R));
                }

                //обчислення загальних витрат C = ∑ (λ * c) / γ
                double totalCost = 0;
                foreach (var (lambda, _, c) in parameters)
                {
                    totalCost += (lambda * c * 22) / gamma;
                }

                //вивід результату для кожного складного вузла
                Console.WriteLine($"Вузол {i + 9}: Час очікування = {waitingTime:F2}, Загальні витрати = {totalCost:F2}");
            }
        }
    }
}