using System;
using System.Text;

class Program //Варіант7. Замінити всі від’ємні числа на їхні модулі, після чого знайти серед усіх елементів масиву два мінімальних.
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
                array = FillArrayRandom(sizeRandom);
                PrintArray(array);
                break;

            case 2:
                Console.WriteLine("Введіть розмір масиву:");
                int sizeManual = Convert.ToInt32(Console.ReadLine());
                array = FillArraySeparateLines(sizeManual);
                break;

            case 3:
                array = FillArraySingleLine();
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

    static int[] FillArrayRandom(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(-100, 101); 
        }

        return arr;
    }

    static int[] FillArraySeparateLines(int size)
    {
        int[] arr = new int[size];

        Console.WriteLine($"Введіть {size} чисел, кожне у окремому рядку:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        return arr;
    }

    static int[] FillArraySingleLine()
    {
        Console.WriteLine("Введіть числа, розділені пробілами або табуляціями:");
        string input = Console.ReadLine();
        string[] numbers = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            arr[i] = Convert.ToInt32(numbers[i]);
        }

        return arr;
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Елементи масиву:");
        StringBuilder sb = new StringBuilder(); 
        foreach (int num in arr)
        {
            sb.Append(num + " ");
        }
        Console.WriteLine(sb.ToString());
    }

    static int[] ReplaceNegativeWithAbsolute(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                arr[i] = Math.Abs(arr[i]);
            }
        }

        return arr;
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