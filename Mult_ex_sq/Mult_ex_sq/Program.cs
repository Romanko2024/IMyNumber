using System;

class Program
{
    // підрахунок суми цифр числа
    static int SumOfDigits(long num)
    {
        int sum = 0;
        while (num > 0) //поки в числі є цифри
        {
            sum += (int)(num % 10); //додає до себе останню цифру числа
            num /= 10; //прибирає у числа останню цифру
        }
        return sum;
    }

    static void Main()
    {
        // зчит вводу
        string[] input = Console.ReadLine().Split();
        long a = long.Parse(input[0]);
        long b = long.Parse(input[1]);
        int K = int.Parse(input[2]);

        // змінна кількості чисел, що підходять
        int count = 0;

        // усі точні квадрати в діапазоні [a, b](цілі корені)
        long start = (long)Math.Ceiling(Math.Sqrt(a));  // перший корінь у діапазоні (округляє до більшого цілого)
        long end = (long)Math.Floor(Math.Sqrt(b));      // останній корінь у діапазоні (до меншого цілого)

        for (long i = start; i <= end; i++)
        {
            long square = i * i;  // точний квадрат

            // чи сума цифр числа кратна К
            if (SumOfDigits(square) % K == 0)
            {
                count++;
            }
        }
        // виведення результату
        Console.WriteLine(count);
    }
}