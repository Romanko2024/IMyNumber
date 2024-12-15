using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // структура для зберігання символу та його ймовірності
    class Symbol
    {
        public char Character { get; set; }
        public double Probability { get; set; }
        public string Code { get; set; } = "";
    }

    // метод для алгоритму Шеннона-Фано
    static void ShannonFano(List<Symbol> symbols)
    {
        ShannonFanoRecursive(symbols, 0, symbols.Count - 1);
    }

    static void ShannonFanoRecursive(List<Symbol> symbols, int start, int end)
    {
        if (start >= end)
            return;

        double totalProb = symbols.Skip(start).Take(end - start + 1).Sum(s => s.Probability);
        double halfProb = 0;
        int splitIndex = start;

        // знайти точку розділу
        for (int i = start; i <= end; i++)
        {
            halfProb += symbols[i].Probability;
            if (halfProb >= totalProb / 2)
            {
                splitIndex = i;
                break;
            }
        }

        // присвоєння бітів 0 і 1
        for (int i = start; i <= splitIndex; i++)
            symbols[i].Code += "0";

        for (int i = splitIndex + 1; i <= end; i++)
            symbols[i].Code += "1";

        // рекурсивний поділ
        ShannonFanoRecursive(symbols, start, splitIndex);
        ShannonFanoRecursive(symbols, splitIndex + 1, end);
    }

    // для алгоритму Хаффмена
    class HuffmanNode
    {
        public Symbol Symbol { get; set; }
        public double Probability { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
    }

    static HuffmanNode BuildHuffmanTree(List<Symbol> symbols)
    {
        List<HuffmanNode> nodes = symbols.Select(s => new HuffmanNode { Symbol = s, Probability = s.Probability }).ToList();

        while (nodes.Count > 1)
        {
            nodes = nodes.OrderBy(n => n.Probability).ToList();
            HuffmanNode left = nodes[0];
            HuffmanNode right = nodes[1];

            HuffmanNode newNode = new HuffmanNode
            {
                Probability = left.Probability + right.Probability,
                Left = left,
                Right = right
            };

            nodes.Remove(left);
            nodes.Remove(right);
            nodes.Add(newNode);
        }

        return nodes[0];
    }

    static void AssignHuffmanCodes(HuffmanNode node, string code)
    {
        if (node == null)
            return;

        if (node.Symbol != null)
        {
            node.Symbol.Code = code;
        }

        AssignHuffmanCodes(node.Left, code + "0");
        AssignHuffmanCodes(node.Right, code + "1");
    }

    // метод для обчислення середньої довжини коду
    static double CalculateAverageCodeLength(List<Symbol> symbols)
    {
        return symbols.Sum(s => s.Probability * s.Code.Length);
    }

    static void Main(string[] args)
    {
        // ініціалізація символів та їх ймовірностей
        List<Symbol> symbols = new List<Symbol>
        {
            new Symbol { Character = 'A', Probability = 0.26 },
            new Symbol { Character = 'B', Probability = 0.14 },
            new Symbol { Character = 'C', Probability = 0.05 },
            new Symbol { Character = 'D', Probability = 0.10 },
            new Symbol { Character = 'E', Probability = 0.07 },
            new Symbol { Character = 'F', Probability = 0.11 },
            new Symbol { Character = 'G', Probability = 0.02 },
            new Symbol { Character = 'H', Probability = 0.20 },
            new Symbol { Character = 'I', Probability = 0.05 },
        };

        // алгоритм Шеннона-Фано
        var shannonFanoSymbols = symbols.OrderByDescending(s => s.Probability).ToList();
        ShannonFano(shannonFanoSymbols);
        Console.WriteLine("Коди Шеннона-Фано:");
        foreach (var symbol in shannonFanoSymbols)
        {
            Console.WriteLine($"Символ: {symbol.Character}, Код: {symbol.Code}");
        }
        double avgLengthShannonFano = CalculateAverageCodeLength(shannonFanoSymbols);
        Console.WriteLine($"Середня довжина коду Шеннона-Фано: {avgLengthShannonFano}");

        // алгоритм Хаффмена
        var huffmanSymbols = symbols.OrderByDescending(s => s.Probability).ToList();
        HuffmanNode huffmanTree = BuildHuffmanTree(huffmanSymbols);
        AssignHuffmanCodes(huffmanTree, "");
        Console.WriteLine("\nКоди Хаффмена:");
        foreach (var symbol in huffmanSymbols)
        {
            Console.WriteLine($"Символ: {symbol.Character}, Код: {symbol.Code}");
        }
        double avgLengthHuffman = CalculateAverageCodeLength(huffmanSymbols);
        Console.WriteLine($"Середня довжина коду Хаффмена: {avgLengthHuffman}");

        // порівняння ефективності
        Console.WriteLine($"\nРізниця в середній довжині коду: {Math.Abs(avgLengthShannonFano - avgLengthHuffman)}");
    }
}
