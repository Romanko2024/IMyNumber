using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("**Оберіть опцію:**");
        Console.WriteLine("1. Десятковий дріб у бінарний");
        Console.WriteLine("2. Бінарне число в Two's complement");

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
                Console.WriteLine("Невідома опція!");
                break;
        }
    }

    static void DecimalToBinary()
    {
        Console.WriteLine("Введіть десятковий дріб (наприклад: 0,25):");
        double decimalNumber = double.Parse(Console.ReadLine());

        // Перетворення в цілу та дробову частини
        int integerPart = (int)decimalNumber;
        double fractionalPart = decimalNumber - integerPart;

        // Перетворення цілої частини в двійкове число без бібліотечних методів
        string integerBinary = IntegerToBinary(integerPart);

        // Перетворення дробової частини в двійкове число
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

        // Об'єднання цілої та дробової частин
        string binaryNumber = integerBinary + "." + fractionalBinary;

        Console.WriteLine($"Бінарне число: {binaryNumber}");
    }

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
        Console.WriteLine("Введіть бінарне число:");
        string binaryNumber = Console.ReadLine();

        //перевірка на -
        bool isNegative = binaryNumber.Contains("-");
        binaryNumber = binaryNumber.Replace("-", "");

        if (isNegative)
        {
            //доповнення числа до 16 біт зліва нулями
            while (binaryNumber.Length < 16)
            {
                binaryNumber = "0" + binaryNumber;
            }

            //обернення бітів
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

            //якщо є надлишок, додати його до найбільшого розряду
            if (carry == 1)
            {
                twosComplement = "1" + twosComplement;
            }

            Console.WriteLine($"Two's complement: {twosComplement}");
        }
        else
        {
            Console.WriteLine($"16-бітне представлення введеного числа: {binaryNumber.PadLeft(16, '0')}");
        }
    }
}


