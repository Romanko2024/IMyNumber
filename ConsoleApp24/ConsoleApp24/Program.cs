using System;
using System.Linq;

class ATM
{
    static void Main()
    {
        //зчит кількості номіналів
        int N = int.Parse(Console.ReadLine());
        //зчит в array номіналів банкнот
        int[] denominations = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //зчит необхідної суми
        int Sum = int.Parse(Console.ReadLine());

        //сорт номінали у порядку спадання
        Array.Sort(denominations);
        Array.Reverse(denominations);

        int count = 0;
        int remainder = Sum;

        foreach (int denom in denominations)
        {
            //кількість банкнот поточного номіналу, які можна використати
            int numNotes = remainder / denom;
            //додаємо їх кількість в суму кількостей
            count += numNotes;
            //обновляємо залишок
            remainder -= numNotes * denom;

            //завершаємо кщо залишок 0
            if (remainder == 0)
            {
                Console.WriteLine(count);
                return;
            }
        }
        Console.WriteLine("No solution");
    }
}
