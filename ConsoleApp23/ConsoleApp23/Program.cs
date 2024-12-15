using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int Id { get; set; }
    public double ProcessingTime { get; set; }  // t_ij
    public double ProcessingCost { get; set; }  // C_ij
    public double AggregationCoefficient { get; set; }  // γ_j
    public double ProblemIntensity { get; set; }  // λ_i
    public int Type { get; set; }  // Тип вузла (1, 2 або 3)

    // Конструктор для ініціалізації даних вузла
    public Node(int id, double processingTime, double processingCost, double aggregationCoefficient, double problemIntensity, int type)
    {
        Id = id;
        ProcessingTime = processingTime;
        ProcessingCost = processingCost;
        AggregationCoefficient = aggregationCoefficient;
        ProblemIntensity = problemIntensity / 22; // Ділимо інтенсивність на 22
        Type = type;
    }

    // Метод для розрахунку часу затримки для вузлів першого типу
    public double CalculateDelayTimeType1()
    {
        return (ProblemIntensity * ProcessingTime) / (1 - ProcessingTime * ProblemIntensity);
    }

    // Метод для розрахунку часу затримки для вузлів другого і третього типів з урахуванням зв'язків
    public double CalculateDelayTimeType2And3(IEnumerable<Node> linkedFirstTypeNodes)
    {
        double sumLambdaTijSquared = linkedFirstTypeNodes.Sum(node => node.ProblemIntensity * Math.Pow(node.ProcessingTime, 2));
        double Rj = linkedFirstTypeNodes.Sum(node => (node.ProblemIntensity * node.ProcessingTime) / AggregationCoefficient);

        // Перевірка, щоб уникнути від'ємного часу
        if (Rj >= 1)
        {
            Console.WriteLine($"Увага: Вузол {Id} має перевантаження (R_j = {Rj:F2}). Час очікування встановлено як дуже велике значення.");
            return double.PositiveInfinity;  // або інше велике значення для позначення перевантаження
        }

        return (linkedFirstTypeNodes.Count() / (2 * (1 - Rj))) * sumLambdaTijSquared;
    }

    // Метод для розрахунку витрат
    public double CalculateProcessingCost()
    {
        return (ProblemIntensity * ProcessingCost) / AggregationCoefficient;
    }
}

public class Program
{
    public static void Main()
    {
        // Вузли з Таблиці 1 та коефіцієнти агрегації з варіанта 11
        List<Node> nodes = new List<Node>
        {
            // Вузли першого типу (збирання інформації)
            //номер вузла|час обробки|витрати на обробку|коеф агрегації|частота|тип вузла|
            new Node(1, 0.5, 20, 1, 10, 1),
            new Node(2, 0.8, 25, 1, 12, 1),
            new Node(3, 0.6, 18, 1, 15, 1),
            new Node(4, 1.2, 22, 1, 8, 1),
            new Node(5, 0.7, 30, 1, 5, 1),
            new Node(6, 1.5, 26, 1, 10, 1),
            new Node(7, 1.0, 24, 1, 15, 1),
            new Node(8, 0.4, 32, 1, 25, 1),

            // Вузли другого типу (обробки інформації)
            new Node(9, 0.4, 28, 1.3, 20, 2),
            new Node(10, 0.6, 18, 1.3, 18, 2),
            new Node(11, 0.5, 24, 1.1, 15, 2),
            new Node(12, 0.7, 25, 1.2, 22, 2),

            // Вузли третього типу (прийняття рішень)
            new Node(13, 0.8, 25, 3.2, 30, 3),
            new Node(14, 0.5, 28, 4.0, 35, 3)
        };

        // Визначення зв'язків між вузлами
        Dictionary<int, List<int>> nodeConnections = new Dictionary<int, List<int>>
        {
            { 9, new List<int> { 1, 3 } },
            { 10, new List<int> { 2, 5 } },
            { 11, new List<int> { 4, 7 } },
            { 12, new List<int> { 6, 8 } },
            { 13, new List<int> { 1, 2, 3, 4 } },
            { 14, new List<int> { 5, 6, 7, 8 } }
        };

        Console.WriteLine("Розрахункові характеристики вузлів системи управління:");
        Console.WriteLine("№ вузла | Тип вузла | Час очікування (днів) | Витрати (у.о.)");

        foreach (var node in nodes)
        {
            double delayTime;
            double processingCost = node.CalculateProcessingCost();

            if (node.Type == 1)
            {
                // Час очікування для вузлів першого типу
                delayTime = node.CalculateDelayTimeType1();
            }
            else
            {
                // Час очікування для вузлів другого і третього типів з урахуванням зв'язків
                var linkedFirstTypeNodes = nodes.Where(n => nodeConnections[node.Id].Contains(n.Id));
                delayTime = node.CalculateDelayTimeType2And3(linkedFirstTypeNodes);
            }

            Console.WriteLine($"{node.Id} | {node.Type} | {delayTime:F2} | {processingCost:F2}");
        }
    }
}