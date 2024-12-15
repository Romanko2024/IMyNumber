using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть бінарне число number1 (16+4 біт): ");
        string binaryNumber1 = Console.ReadLine();
        Console.Write("Введіть бінарне число number2 (8+4 біт): ");
        string binaryNumber2 = Console.ReadLine();

        //виведення початкових значень
        //Console.WriteLine("Початкові значення:");
        //Console.WriteLine("number1: " + binaryNumber1);
        //Console.WriteLine("number2: " + binaryNumber2);

        //розділення чисел на mantissa та exponent
        string mantissa1 = binaryNumber1.Substring(0, 16);
        string exponent1 = binaryNumber1.Substring(16);
        string mantissa2 = binaryNumber2.Substring(0, 8);
        string exponent2 = binaryNumber2.Substring(8);

        //перетворення другої мантиси в 16-бітний формат
        mantissa2 = PadMantissa(mantissa2, 16);

        //вив проміжкового значення
        //Console.WriteLine("Після перетворення другої мантиси:");
        //Console.WriteLine("mantissa2: " + mantissa2);

        //зміна знаку mantissa2
        mantissa2 = TwosComplement(mantissa2);

        ////виведення проміжкового значення
        //Console.WriteLine("Після зміни знаку другого числа:");
        //Console.WriteLine("mantissa2: " + mantissa2);

        //---

        //вирівнювання мантис
        if (exponent1 != exponent2) //+
        {
            int exponent1Value = Convert.ToInt32(exponent1, 2);
            int exponent2Value = Convert.ToInt32(exponent2, 2);
            int diff = Math.Abs(exponent1Value - exponent2Value);
            if (exponent1Value < exponent2Value)
            {
                mantissa1 = ShiftRightWithPadding(mantissa1, diff);
            }
            else
            {
                mantissa2 = ShiftRightWithPadding(mantissa2, diff);
            }
        }

        //виведення проміжкових значень
        //Console.WriteLine("Після зрівняння експонент:");
        //Console.WriteLine("mantissa1: " + mantissa1);
        //Console.WriteLine("mantissa2: " + mantissa2);

        //додавання мантис
        string result = AddBinaryNumbers(mantissa1, mantissa2);

        //виведення результату разом з більшою експонентою
        string biggerExponent = (Convert.ToInt32(exponent1, 2) > Convert.ToInt32(exponent2, 2)) ? exponent1 : exponent2;

        Console.WriteLine("Результат: " + result + biggerExponent );
    }

    static string PadMantissa(string mantissa, int length) //+
    {
        char padChar = '0';
        return mantissa.PadRight(length, padChar);
    }

    static string TwosComplement(string binaryNumber) //+
    {
        string inverted = "";
        foreach (char bit in binaryNumber)
        {
            inverted += (bit == '0') ? '1' : '0';
        }

        int carry = 1;
        string complement = "";
        for (int i = inverted.Length - 1; i >= 0; i--)
        {
            int sum = (inverted[i] - '0') + carry;
            complement = (sum % 2) + complement;
            carry = sum / 2;
        }

        return complement.PadLeft(binaryNumber.Length, complement[0]);
    }

    
    static string ShiftRightWithPadding(string binaryNumber, int shift) //+
{
    char signBit = binaryNumber[0];
    for (int i = 0; i < shift; i++)
    {
        if (signBit == '1')
        {
            binaryNumber = binaryNumber.Insert(0, "1");
        }
        else
        {
            binaryNumber = binaryNumber.Insert(0, "0");
        }
        binaryNumber = binaryNumber.Remove(binaryNumber.Length - 1);
    }
    return binaryNumber;
}

    //---
    static string AddBinaryNumbers(string binary1, string binary2) //+
    {
        string result = "";
        int carry = 0;

        for (int i = binary1.Length - 1; i >= 0; i--)
        {
            int sum = (binary1[i] - '0') + (binary2[i] - '0') + carry;
            result = (sum % 2) + result;
            carry = sum / 2;
        }

        if (carry == 1)
        {
            result = "1" + result;
        }

        return result;
    }
}
