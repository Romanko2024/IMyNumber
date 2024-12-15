using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input;
        List<int> results = new List<int>();
        //зчит з консолі
        while ((input = Console.ReadLine()) != null && input != "") //null-кінець вводу
        {
            //розділ рядка на два числа
            string[] numbers = input.Split(' ');
            int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);
            //сумуємомо і додаємо до результ.
            results.Add(a + b);
        }

        // виведення кожного результату
        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
    }
}
