using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // читання вхідних даних
        int N = int.Parse(Console.ReadLine());
        int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // масив для зберігання мінімальної кількості енергії для кожної платформи
        int[] dp = new int[N];
        // масив для зберігання шляху
        int[] path = new int[N];

        // ініціалізуємо перші значення
        dp[0] = 0;  // Першу платформу досягаємо без витрат
        dp[1] = Math.Abs(heights[1] - heights[0]);  // Витрати на перехід з першої на другу платформу
        path[1] = 0;

        // основний цикл для заповнення dp
        for (int i = 2; i < N; i++)
        {
            // мінімальна енергія для досягнення платформи i
            int step1 = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
            int step2 = dp[i - 2] + 3 * Math.Abs(heights[i] - heights[i - 2]);

            if (step1 < step2)
            {
                dp[i] = step1;
                path[i] = i - 1;
            }
            else
            {
                dp[i] = step2;
                path[i] = i - 2;
            }
        }

        // виведення мінімальної кількості енергії
        Console.WriteLine(dp[N - 1]);

        // відновлення шляху
        List<int> resultPath = new List<int>();
        for (int i = N - 1; i != 0; i = path[i])
        {
            resultPath.Add(i + 1);
        }
        resultPath.Add(1);
        resultPath.Reverse();

        // виведення кількості платформ
        Console.WriteLine(resultPath.Count);

        // виведення послідовності платформ
        Console.WriteLine(string.Join(" ", resultPath));
    }
}
