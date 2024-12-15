using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть блок завдань:");
        Console.WriteLine("1. Знайти суму від’ємних елементів матриці.");
        Console.WriteLine("2. Обміняти місцями елементи першого рядка і головної діагоналі.");
        Console.WriteLine("3. Упорядкувати всі рядки з парними номерами за неспаданням, а всі рядки з непарними номерами за незростанням.");
        Console.WriteLine("4. Упорядкувати стовпчики за неспаданням мінімального елемента.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Block1();
                break;
            case 2:
                Block2();
                break;
            case 3:
                Block3();
                break;
            case 4:
                Block4();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }
    static int[,] ReadMatrix()
    {
        Console.WriteLine("Введіть розмірність матриці (рядки стовпці через пробіл):");
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        int[,] matrix = new int[rows, cols];
        Console.WriteLine("1. Ввести матрицю вручну");
        Console.WriteLine("2. Згенерувати випадкову матрицю");

        int choice;
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Невірний ввід, оберіть 1 або 2.");
            }
            else
            {
                break;
            }
        }
        if (choice == 2)
        {
            matrix = GenerateRandomMatrix(rows, cols);
            PrintGenMatrix(matrix); //вивід згенерованої матриці
            return matrix;
        }

        else
        {
            Console.WriteLine("Введіть елементи матриці через пробіл порядково:");
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            return matrix;
        }
    }

    //Знайти суму від’ємних елементів матриці.
    static void Block1()
    {
        int[,] matrix = ReadMatrix();
        int sum = 0;

        foreach (int num in matrix)
        {
            if (num < 0)
                sum += num;
        }

        Console.WriteLine($"Сума від'ємних елементів: {sum}");
        Console.ReadLine();
    }

    //Обміняти місцями елементи першого рядка і головної діагоналі.
    static void Block2()
    {
        int[,] matrix = ReadMatrix();
        int size = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        if (size != cols)
        {
            Console.WriteLine("Некоректна розмірність матриці. Для цього завдання матриця має бути квадратною");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < size; i++)
        {
            int temp = matrix[0, i];
            matrix[0, i] = matrix[i, i]; //головний рядок matrix[0, i]; основна діагональ matrix[i, i];
            matrix[i, i] = temp;
        }

        PrintMatrix(matrix);
    }

    //Упорядкувати всі рядки з парними номерами за неспаданням, а всі рядки з непарними номерами за незростанням.
    static void Block3()
    {
        int[,] matrix = ReadMatrix();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        //перебір рядків
        for (int i = 0; i < rows; i++)
        {
            bool isEven = (i % 2 == 0); 

            //зростання/спадання
            if (isEven)
            {
                //зростання
                for (int j = 0; j < cols - 1; j++)
                {
                    for (int k = j + 1; k < cols; k++)
                    {
                        if (matrix[i, j] < matrix[i, k])
                        {
                            //обмін
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
            else
            {
                //спадання
                for (int j = 0; j < cols - 1; j++)
                {
                    for (int k = j + 1; k < cols; k++)
                    {
                        if (matrix[i, j] > matrix[i, k])
                        {
                            //обмін
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
        }

        PrintMatrix(matrix);
    }

    //Упорядкувати стовпчики за неспаданням мінімального елемента.
    static void Block4()
    {
        int[,] matrix = ReadMatrix();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        //мін. елемент кожного стовпця
        int[] minElements = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            minElements[j] = matrix[0, j];
            for (int i = 1; i < rows; i++)
            {
                //якщо ел. у стовпчику j менший за поточний мін. ел. minElements[j], то значення minElements[j] = поточний елемент.
                if (matrix[i, j] < minElements[j])
                    minElements[j] = matrix[i, j];
            }
        }

        //масив індексів стовпців для сортування
        int[] columnIndex = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            columnIndex[j] = j;
        }

        //сортування стовпців за мін. елементами (Сортування вставками масивів minElements і columnIndex за зростанням значень minElements)
        for (int i = 1; i < cols; i++)
        {
            int key = minElements[i];
            int keyIndex = columnIndex[i];
            int j = i - 1;

            while (j >= 0 && minElements[j] > key)
            {
                minElements[j + 1] = minElements[j];
                columnIndex[j + 1] = columnIndex[j];
                j = j - 1;
            }

            minElements[j + 1] = key;
            columnIndex[j + 1] = keyIndex;
        }

        //збираємо вже відсортовану матрицю
        int[,] sortedMatrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                //отримує значення з рядка і початкової матриці та стовпчика, що = columnIndex[j]
                sortedMatrix[i, j] = matrix[i, columnIndex[j]];
            }
        }

        //виводимо відсортовану матрицю
        PrintMatrix(sortedMatrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("Матриця після перетворення:");
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0,6}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }

    static void PrintGenMatrix(int[,] matrix)
    {
        Console.WriteLine("Згенерована матриця:");
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0,6}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        //Console.ReadLine();
    }

    static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(-100, 101); 
            }
        }
        
        return matrix;
    }
}

