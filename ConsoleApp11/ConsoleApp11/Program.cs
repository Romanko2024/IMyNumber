using System;

class Program
{
    static void Main(string[] args)
    {
        //введення першого числа
        Console.WriteLine("Введіть перше двійкове число:");
        string firstNumber = Console.ReadLine();

        //введення другого числа
        Console.WriteLine("Введіть друге двійкове число:");
        string secondNumber = Console.ReadLine();

        bool isNegative = (firstNumber.Contains("-") && !secondNumber.Contains("-")) || (!firstNumber.Contains("-") && secondNumber.Contains("-"));

        //видалення мінусів, якщо вони є
        firstNumber = firstNumber.Replace("-", "");
        secondNumber = secondNumber.Replace("-", "");

        //визначення типу чисел
        bool isFixedPoint = firstNumber.Contains(".") || secondNumber.Contains(".");

        //множення чисел
        string result;
        if (isFixedPoint)
        {
            result = MultiplyBinaryNumbersFixedPoint(firstNumber, secondNumber);
            //додавання знака "-"
            if (isNegative)
            {
                result = "-" + result;
            }
        }
        else
        {
            result = MultiplyBinaryNumbers(firstNumber, secondNumber);
            //додавання знака "-"
            if (isNegative)
            {
                result = "-" + result;
            }
        }

        // Виведення результату
        Console.WriteLine("Результат множення:");
        Console.WriteLine(result);

        // Перетворення результату в 8-бітний формат (необов'язково)
        if (!isFixedPoint)
        {
            Console.WriteLine("Результат в 8-бітному форматі:");
            Console.WriteLine(To8BitFormat(result));
        }

        else
        {
            Console.WriteLine("Результат у 8-бітному форматі:");
            string eightBitFormat = To8BitFormatFixedPoint(result);
            Console.WriteLine(eightBitFormat);
        }

    }

    static string MultiplyBinaryNumbers(string firstNumber, string secondNumber)
    {
        //масив для зберігання проміжних результатів
        int[] intermediateResults = new int[16];

        //перебір розрядів другого числа
        for (int i = secondNumber.Length - 1; i >= 0; i--)
        {
            int innerCarry = 0; // Переноска

            //перебір розрядів першого числа
            for (int j = firstNumber.Length - 1; j >= 0; j--)
            {
                int product = (firstNumber[j] - '0') * (secondNumber[i] - '0') + innerCarry;
                intermediateResults[i + j + 1] += product % 2;
                innerCarry = product / 2;
            }

            //зберігання переноски
            intermediateResults[i] = innerCarry;
        }

        //додавання проміжних результатів і зсув вправо
        int outerCarry = 0;
        string result = "";
        for (int i = 15; i >= 0; i--)
        {
            int sum = intermediateResults[i] + outerCarry;
            result = (sum % 2) + result;
            outerCarry = sum / 2;
        }

        return result;
    }

    static string MultiplyBinaryNumbersFixedPoint(string firstNumber, string secondNumber)
    {
        //отримання цілих та дробових частин чисел
        string[] firstParts = firstNumber.Split('.');
        string[] secondParts = secondNumber.Split('.');

        //перевірка довжини цілих та дробових частин
        if (firstParts.Length != 2 || secondParts.Length != 2)
        {
            Console.WriteLine("Введені числа не є двійковими числами з фіксованою комою.");
            return "";
        }

        //множення цілих частин
        string wholeProduct = MultiplyBinaryNumbers(firstParts[0], secondParts[0]);

        //множення дробових частин
        string fractionalProduct = MultiplyBinaryNumbers(firstParts[1], secondParts[1]);

        //додавання цілої та дробової частин
        string result = wholeProduct + (firstParts[1].Length == 0 ? "" : ".") + fractionalProduct;

        //зсув коми
        int shift = firstParts[1].Length + secondParts[1].Length;
        if (shift > 0)
        {
            result = result.PadRight(result.Length + shift, '0');
        }
        else if (shift < 0)
        {
            result = result.PadLeft(result.Length - shift, '0');
        }

        return result;
    }

    static string To8BitFormat(string binaryNumber)
    {
        
        if (binaryNumber.Length > 8)
        {
            return binaryNumber.Substring(binaryNumber.Length - 8);
        }

        while (binaryNumber.Length < 8)
        {
            binaryNumber = "0" + binaryNumber;
        }

        return binaryNumber;
    }

    static string To8BitFormatFixedPoint(string binaryNumber)
    {
        
        //видалення зайвих нулів з обох сторін числа
        binaryNumber = binaryNumber.Trim('0');

        //розділення на цілу та дробову частину
        string[] parts = binaryNumber.Split('.');

        //скорочення дробової частини
        if (parts.Length == 2)
        {
            parts[1] = parts[1].TrimEnd('0');
        }

        //злиття цілої та дробової частин
        string result = string.Join(".", parts);

        //перевірка на необхідність скорочення цілої частини
        if (result.StartsWith("."))
        {
            result = "0" + result;
        }
        //додавання нулів зліва, якщо довжина менша за 8+кома
        while (result.Length < 9)
        {
            result = "0" + result;
        }

        return result;
    }

}