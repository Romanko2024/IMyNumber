using System;

class Program
{
    static void Main()
    {
        // зчит вводу
        long N = long.Parse(Console.ReadLine());

        // проходимо по всіх x до N
        for (long x = 1; x * x <= N; x++)
        {
            long y2 = N - x * x; // y^2 = N - x^2
            long y = (long)Math.Sqrt(y2);

            // перевіряємо, чи y ціле, і чи більше нуля
            if (y * y == y2 && y > 0)
            {
                Console.WriteLine($"{x} {y}");
            }
        }
    }
}
