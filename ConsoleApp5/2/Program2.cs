using System;
using System.Linq;

class Program2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть спосіб заповнення масиву:");
        Console.WriteLine("1. Випадково");
        Console.WriteLine("2. Вручну, кожен елемент у окремому рядку");
        Console.WriteLine("3. Вручну, всі елементи у одному рядку");

        int choice = Convert.ToInt32(Console.ReadLine());
        int[] array = null;

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введіть розмір масиву:");
                int sizeRandom = Convert.ToInt32(Console.ReadLine());
                array = Enumerable.Range(0, sizeRandom).Select(i => new Random().Next(-100, 101)).ToArray();
                PrintArray(array);
                break;

            case 2:
                Console.WriteLine("Введіть розмір масиву:");
                int sizeManual = Convert.ToInt32(Console.ReadLine());

                array = Enumerable.Range(0, sizeManual)
                                  .Select(_ => Convert.ToInt32(Console.ReadLine()))
                                  .ToArray();
                break;

            case 3:
                Console.WriteLine("Введіть числа, розділені пробілами або табуляціями:");
                string input = Console.ReadLine();
                array = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).ToArray();
                break;

            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }

        if (array != null)
        {
            array = ReplaceNegativeWithAbsolute(array);
            PrintArray(array);
            FindTwoMin(array);
        }

        Console.ReadLine();
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Елементи масиву:");
        Console.WriteLine(string.Join(" ", arr));
    }

    static int[] ReplaceNegativeWithAbsolute(int[] arr)
    {
        return arr.Select(x => x < 0 ? Math.Abs(x) : x).ToArray();
    }

    static void FindTwoMin(int[] arr)
    {
        if (arr.Length < 2)
        {
            Console.WriteLine("Масив має недостатньо елементів");
            return;
        }

        int min1 = int.MaxValue, min2 = int.MaxValue;

        foreach (int num in arr)
        {
            if (num <= min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
            {
                min2 = num;
            }
        }

        Console.WriteLine($"Два мінімальних числа: {min1} {min2}");
    }

}
