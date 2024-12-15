using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть натуральне число n:");
        int n = int.Parse(Console.ReadLine());
        //вимірювання початкової пам'яті
        long startMemory = GC.GetTotalMemory(true);

        //створення зубчастого масиву
        int[][] jaggedArray = new int[n][];

        //заповнення зубчастого масиву
        for (int i = 0; i < n; i++)
        {
            //знаходж. суми для і
            int sumOfDigits = DigitSum(i);
            bool duplicateFound = false;

            //чи вже існує рядок з такою самою сумою
            for (int j = 0; j < i; j++)
            {
                if (DigitSum(j) == sumOfDigits)
                {
                    //створюємо посилання на існуючий рядок
                    jaggedArray[i] = jaggedArray[j];
                    duplicateFound = true;
                    break;
                }
            }

            if (!duplicateFound)
            {
                //ініц. рядка у масиві
                jaggedArray[i] = new int[n];
                int count = 0;

                //перевірка та ввід кратних в рядок
                for (int j = 1; j <= n; j++)
                {
                    if (sumOfDigits != 0 && j % sumOfDigits == 0)
                    {
                        jaggedArray[i][count] = j;
                        count++;
                    }
                }
            }
        }

        //виведення зубчастого масиву (якщо його розмір менше арбітрарно вибраного числа)
        if (jaggedArray.Length < 129)
        {
            for (int i = 0; i < n; i++)
            {
                if (jaggedArray[i] != null)
                {
                    Console.Write($"Рядок {i}: ");
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        if (jaggedArray[i][j] != 0)
                        {
                            Console.Write(jaggedArray[i][j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Масив завеликий для виведення.");
        }

        //вимірювання кінцевої пам'яті та виведення різниці
        long endMemory = GC.GetTotalMemory(true);
        double usedMemory = (endMemory - startMemory) / (1024.0 * 1024.0); // конвертація у мегабайти
        Console.WriteLine($"Використана пам'ять: {usedMemory} МБ");
    }

    //функція для обчислення суми цифр числа
    static int DigitSum(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            // останнє число номеру додається до суми
            sum += number % 10;
            // останнє число прибирається
            number /= 10;
        }
        return sum;
    }
}
