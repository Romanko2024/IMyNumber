using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array;

        Console.WriteLine("Оберіть спосіб введення масиву:");
        Console.WriteLine("1. Ручне введення в одному рядку через пробіл");
        Console.WriteLine("2. Ручне введення, кожен елемент вводиться окремим рядком");
        Console.WriteLine("3. Випадкова генерація");

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                array = ReadArrSingleLine(); //виклик методу для ручного введення масиву в одному рядку
                break;
            case 2:
                array = ReadArrSeparateLines(); //виклик методу для ручного введення масиву, де кожен елемент вводиться окремим рядком
                break;
            case 3:
                Console.Write("Введіть кількість елементів: ");
                int count = int.Parse(Console.ReadLine());
                array = GenerateRandomArray(count); //виклик методу для генерації випадкового масиву
                break;
            default:
                Console.WriteLine("Неправильний вибір. Завершення програми.");
                return;
        }

        Console.WriteLine("Введений масив:");
        PrintArray(array); //виведення введеного масиву на екран

        array = RemoveEvenIndexElements(array); //виклик видалення елементів з парними індексами

        Console.WriteLine("Масив після видалення елементів з парними індексами:");
        PrintArray(array); //виведення оновленого масиву на екран
    }

    //метод зчитування однорядкового вводу
    //static int[] ReadArrSingleLine()
    //{
    //    Console.WriteLine("Введіть елементи масиву через пробіл:");

    //    string[] input = Console.ReadLine().Split(' '); //розділення введених елементів за пробілами
    //    var List = new List<int>(); //список для збереження коректних значень

    //    foreach (string item in input)
    //    {
    //        if (int.TryParse(item, out int number)) //перевірка, чи введене значення є int
    //        {
    //            List.Add(number); //значення коректне -> додати до списку
    //        }
    //        else
    //        {
    //            Console.WriteLine($"Помилка: '{item}' не є цілим числом. Цей елемент буде проігноровано.");
    //        }
    //    }

    //    int[] array = List.ToArray(); //конвертуємосписок у масив

    //    return array;
    //}


    ////метод зчитування окреморядкового вводу
    //static int[] ReadArrSeparateLines()
    //{
    //    Console.WriteLine("Введіть елементи масиву (кожен окремим рядком):");
    //    Console.WriteLine("Для завершення введення введіть '='");

    //    //створення динамічного(за розміром) списку для елементів формату int
    //    var list = new List<int>();

    //    string input;
    //    while ((input = Console.ReadLine()) != "=")
    //    {
    //        if (int.TryParse(input, out int num))
    //        {
    //            list.Add(num); //додавання числа до масиву, якщо його можна перетворити в int
    //        }
    //        else
    //        {
    //            Console.WriteLine("Неправильний формат числа. Спробуйте ще раз.");
    //        }
    //    }

    //    return list.ToArray();
    //}

    //
    //
    //
    //
    //
    static int[] ReadArrSingleLine()
    {
        Console.WriteLine("Введіть елементи масиву через пробіл:");

        string[] input = Console.ReadLine().Split(' '); //розділення введених даних за пробілами
        int[] array = new int[input.Length];
        int validCount = 0; // лічильник коректних значень

        for (int i = 0; i < input.Length; i++)
        {
            if (IsValidInt(input[i])) // перевірка, чи введене значення є int
            {
                array[validCount] = int.Parse(input[i]); //значення коректне -> додати до масиву
                validCount++; // збільшення лічильника коректних значень
            }
            else
            {
                Console.WriteLine($"Помилка: '{input[i]}' не є цілим числом. Цей елемент буде проігноровано.");
            }
        }

        // Створення нового масиву, який містить тільки коректні значення
        int[] result = new int[validCount];
        for (int i = 0; i < validCount; i++)
        {
            result[i] = array[i]; // копіювання коректних значень у новий масив
        }

        return result;
    }

    static int[] ReadArrSeparateLines()
    {
        Console.WriteLine("Введіть розмір масиву:");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size]; // створення масиву з заданим користувачем розміром
        int count = 0; // лічильник коректних значень

        Console.WriteLine("Введіть елементи масиву (кожен окремим рядком):");

        string input;
        while (count < size)
        {
            input = Console.ReadLine();
            if (IsValidInt(input)) // перевірка, чи введене значення є int
            {
                array[count] = int.Parse(input); // додавання числа до масиву, якщо його можна перетворити в int
                count++; // збільшення лічильника коректних значень
            }
            else
            {
                Console.WriteLine("Неправильний формат числа. Спробуйте ще раз.");
            }
        }

        return array;
    }

    //перевіряє чи введене значення є цілим числом
    static bool IsValidInt(string value)
    {
        foreach (char c in value)
        {
            if (!char.IsDigit(c) && c != '-') //перевірка чи введені значення містить лише цифри + мінус
            {
                return false;
            }
        }
        return true;
    }

    
    //
    //
    //
    //
    //

    static int[] GenerateRandomArray(int count)
    {
        var rnd = new Random();
        int[] array = new int[count];

        for (int i = 0; i < count; i++)
        {
            array[i] = rnd.Next(-100, 101); //генерація випадкового числа від -100 до 100
        }

        return array;
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " "); //виведення елементыв масиву нчерез пробіл
        }
        Console.WriteLine();
    }

    static int[] RemoveEvenIndexElements(int[] array)
    {
        int newSize = 0; //ініціалізація змінної для визн. нового розміру
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 != 0) //if індекс непарний елемент залишається
            {
                newSize++; //збільшення розміру нового масиву
            }
        }

        ////потрібне лише при видаленні НЕПАРНИХ індексів
        //if (newSize == 0)
        //{
        //    Console.WriteLine("Немає елементів з непарним індексом.");
        //    return new int[0];
        //}

        int[] newArray = new int[newSize]; //створення нового масиву

        int j = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 != 0) //лише елементи з непарним індексом
            {
                newArray[j] = array[i]; //додавання елементу до нового масиву
                j++;
            }
        }

        return newArray; //повернення оновленого масиву
    }
}
