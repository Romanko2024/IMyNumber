using System;

class Program
{
    static void Main(string[] args)
    {
        // Введіть вашу послідовність цілих чисел. Наприклад, це може бути масив.
        int[] sequence = { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

        int firstElement = sequence[0]; // Отримуємо перший елемент послідовності.
        int count = 0; // Лічильник кількості елементів, кратних першому елементу.

        // Проходимо по послідовності і перевіряємо кожен елемент на кратність першому елементу.
        for (int i = 1; i < sequence.Length; i++)
        {
            if (sequence[i] % firstElement == 0)
            {
                count++;
            }
        }

        Console.WriteLine("Кількість елементів, кратних першому елементу: " + count);
    }
}
