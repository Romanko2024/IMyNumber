using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //кількість номіналів банкнот
        int n = int.Parse(Console.ReadLine());
        //масив номіналів банкнот
        int[] denominations = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //сума
        int s = int.Parse(Console.ReadLine());

        //масив для зберігання мінімальної кількості банкнот для кожної суми від 0 до S
        int[] minCoins = new int[s + 1];
        //задаємо всі суми недосяжними
        Array.Fill(minCoins, int.MaxValue);
        //крім суми 0
        minCoins[0] = 0;

        //перебираємо кожен номінал банкноти
        foreach (int coin in denominations)
        {
            //для кожної суми (j) від поточного до S
            for (int j = coin; j <= s; j++)
            {
                //якщо сума (j - coin) є досяжною
                //minCoins[j - coin] - сума j  яку можна використати з поточною банкнотою для поточної j
                if (minCoins[j - coin] != int.MaxValue)
                {
                    //якщо ця сума з банкнотою зменшує загальну кількість то використовуємо її 
                    minCoins[j] = Math.Min(minCoins[j], minCoins[j - coin] + 1);
                }
            }
        }

        if (minCoins[s] == int.MaxValue)
        {
            Console.WriteLine("No solution");
        }
        else
        {
            Console.WriteLine(minCoins[s]);
        }
    }
}
