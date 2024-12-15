using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть спосіб введення цін товарів:");
        Console.WriteLine("1. Вручну");
        Console.WriteLine("2. За допомогою випадкової генерації");

        int choice = int.Parse(Console.ReadLine());

        int[] numbers;

        if (choice == 1)
        {
            Console.WriteLine("Введіть числа через пробіл:");
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введіть кількість чисел для генерації:");
            int count = int.Parse(Console.ReadLine());
            Random random = new Random();
            numbers = new int[count];

            Console.WriteLine($"Згенерований масив чисел ({count} чисел):");
            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(1, 1001);
                Console.Write(numbers[i] + " "); //вивід згенерованого масиву
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Хибний вибір.");
            return;
        }

        //сортування масиву за спаданням 
        ShakerSort(numbers);

        //Console.WriteLine("відсортований масив за спаданням:");
        //foreach (var num in numbers)
        //{
        //    Console.Write(num + " ");
        //}
        //Console.WriteLine();

        //видалення кожного п'ятого числа 
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if ((i + 1) % 5 != 0) //перевірка на кожне п'яте число
            {
                sum += numbers[i];
                Console.Write(numbers[i] + "+"); //масив готовий до додавання
            }
        }
        //виведення
        Console.WriteLine($"Вартість товарів: {sum}");
        Console.ReadKey();
    }

    //шейкерне сортування
    static void ShakerSort(int[] arr)
    {
        bool swapped = true;
        int start = 0;
        int end = arr.Length - 1;

        while(swapped) 
        {
            swapped = false;

            //прохід вправо
            for (int i = start; i < end; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    swapped = true;
                }
            }

            if (!swapped)
                break;

            swapped = false;
            end--;

            //прохід вліво
            for (int i = end - 1; i >= start; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    swapped = true;
                }
            }

            start++;
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
