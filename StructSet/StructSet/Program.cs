using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //кількість запитів n 
        int n = int.Parse(Console.ReadLine());
        //HashSet для зберігання унікальних елементів
        HashSet<int> set = new HashSet<int>();
        //цикл для кожного запиту
        while (n-- > 0)
        {
            //зчитуємо запит та розбиваємо його на команду і число
            var input = Console.ReadLine().Split();
            switch (input[0]) //за типом команди
            {
                case "ADD": //якщо команда "ADD"
                    set.Add(int.Parse(input[1])); //додаємо число в множину
                    break;

                case "PRESENT": //якщо команда "PRESENT"
                    Console.WriteLine(set.Contains(int.Parse(input[1])) ? "YES" : "NO"); //чи є число в множині "YES" / "NO"
                    break;

                case "COUNT": //якщо команда "COUNT"
                    Console.WriteLine(set.Count); //вивід кількості елементів у множині
                    break;
            }
        }
    }
}