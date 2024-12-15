using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //словник для зберігання рахунків клієнтів
        var accounts = new Dictionary<string, int>();

        while (n-- > 0) //доки є запити
        {
            var input = Console.ReadLine().Split(); //зчит та розбивка на частини
            if (input[0] == "1") // якщо це запит типу 1 (додавання суми)
            {
                int amount = int.Parse(input[2]); //зчитуємо суму, яку потрібно додати
                //записуємо ключ зі значенням+ сума, якщо ключ є - додаємо суму до значення
                accounts[input[1]] = accounts.GetValueOrDefault(input[1], 0) + amount;
            }
            else //якщо це не запит типу 1 (типу 2 (перевірка балансу))
            {
                //перевірка існування ключа
                Console.WriteLine(accounts.ContainsKey(input[1]) ? accounts[input[1]].ToString() : "ERROR");
            }
        }
    }
}