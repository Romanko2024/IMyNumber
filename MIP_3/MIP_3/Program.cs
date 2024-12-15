class Program
{
    static void Main()
    {
        //вхідні дані (момент надходження, час відповіді)
        int[,] tasks = {
            {0, 7},  // J1/u1
            {5, 9},  // J2/u2
            {8, 4},  // J3/u3
            {12, 6}, // J4/u4
            {15, 5}, // J5/u5
            {20, 4}  // J6/u6
        };

        //кільк. рядків у масиві
        int numTasks = tasks.GetLength(0);
        //масив збереж. часу на об
        int[] complTime = new int[numTasks];

        //знаходимо часи завершення задач
        for (int i = 0; i < numTasks; i++)
        {
            complTime[i] = tasks[i, 0] + tasks[i, 1];
            Console.WriteLine($"Завдання J{i + 1} завершено в час: {complTime[i]}");
        }
        //сортуємо часи завершення задач
        Array.Sort(complTime);

        Console.WriteLine("Відсортовані часи завершення задач:");
        for (int i = 0; i < numTasks; i++)
        {
            Console.WriteLine($"Завдання (відсортовано) {i + 1} завершено в час: {complTime[i]}");
        }

        //рахуємо інтервали між завершенням задач
        int[] intervals = new int[numTasks - 1];
        for (int i = 0; i < numTasks - 1; i++)
        {
            intervals[i] = complTime[i + 1] - complTime[i];
            Console.WriteLine($"Інтервал між J{i + 1} і J{i + 2}: {intervals[i]} мс");
        }

        //знаходимо середнє значення інтервалів
        double averageInterval = intervals.Average();
        Console.WriteLine($"Середнє значення інтервалів: {averageInterval} мс");

        //знаходимо продуктивність
        double productivity = 1 / averageInterval;
        Console.WriteLine($"Продуктивність системи: {productivity}");
    }
}
