using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Десятковий дріб у бінарний");
        Console.WriteLine("2. Прямий код у зворотній код");

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                DecimalToBinary();
                break;
            case 2:
                BinaryToTwosComplement();
                break;
            default:
                Console.WriteLine("Неправильний вибір");
                break;
        }
    }

    static void DecimalToBinary()
    {
        Console.WriteLine("Введіть десятковий дріб (наприклад: 0,25):");
        double decimalNumber = double.Parse(Console.ReadLine());

        //розділення цілої і дробової частини числа
        int integerPart = (int)decimalNumber;
        double fractionalPart = decimalNumber - integerPart;

        string integerBinary = IntegerToBinary(integerPart);

        //перетворення дробової частини в двійкове число
        string fractionalBinary = "";
        for (int i = 0; i < 16; i++)
        {
            fractionalPart *= 2;
            int bit = (int)fractionalPart;
            fractionalBinary += bit.ToString();
            fractionalPart -= bit;

            if (fractionalPart == 0)
            {
                break;
            }
        }

        //об'єднання цілої та дробової частин
        string binaryNumber = integerBinary + "." + fractionalBinary;

        Console.WriteLine($"Число у бінарному вигляді: {binaryNumber}");
    }

    //перетворення цілої частини
    static string IntegerToBinary(int number)
    {
        if (number == 0)
            return "0";

        string binary = "";
        while (number > 0)
        {
            int remainder = number % 2;
            binary = remainder.ToString() + binary;
            number /= 2;
        }
        return binary;
    }

    static void BinaryToTwosComplement()
    {
        Console.WriteLine("Введіть бінарне число у вигляді прямого коду:");
        string binaryNumber = Console.ReadLine();

        //перевірка на наявність знака "-" та видалення його для подальшої обробки
        bool isNegative = binaryNumber.Contains("-");
        binaryNumber = binaryNumber.Replace("-", "");

        if (isNegative)
        {
            //доповнення числа до 16 біт зліва нулями
            while (binaryNumber.Length < 16)
            {
                binaryNumber = "0" + binaryNumber;
            }

            //інвертація бітів
            string invertedNumber = "";
            foreach (char bit in binaryNumber)
            {
                if (bit == '0')
                {
                    invertedNumber += '1';
                }
                else
                {
                    invertedNumber += '0';
                }
            }

            //додавання одиниці до інвертованого числа
            int carry = 1;
            string twosComplement = "";
            for (int i = invertedNumber.Length - 1; i >= 0; i--)
            {
                int bit = (invertedNumber[i] - '0') + carry;
                twosComplement = (bit % 2) + twosComplement;
                carry = bit / 2;
            }

            //if надлишок до найбільшого розряду
            if (carry == 1)
            {
                twosComplement = "1" + twosComplement;
            }

            Console.WriteLine($"Число у вигляді зворотнього коду: {twosComplement}");
        }
        else
        {
            Console.WriteLine($"Число у вигляді зворотнього коду: {binaryNumber.PadLeft(16, '0')}");
        }
    }
}

