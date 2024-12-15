using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Program
    {
        static void DoBlock_1()
        {
            Console.WriteLine("Завдання 1");
            int n = int.Parse(Console.ReadLine());
            int firstElement = int.Parse(Console.ReadLine());
            int count = 1;
            for (int i = 0; i < n-1; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (element % firstElement == 0)
                {
                    count++;
                }
            }
            Console.WriteLine("Кількість елементів, кратних першому елементу: {0}", count);
        }

        static void DoBlock_2()
        {
            Console.WriteLine("Завдання 2");
            double sum = 0;
            int counter = 0;
            while (true)
            {
                int element = int.Parse(Console.ReadLine());
                if (element == 0)
                {
                    break;
                }
                sum += element;
                counter++;
            }
            double average = sum / counter;
            Console.WriteLine("Середнє арифметичне: {0}", average);
        }

        static void DoBlock_3()
        {
            Console.WriteLine("Завдання 3");
            int i = 1;
            int n = int.Parse(Console.ReadLine());
            do
            { 
                int element = int.Parse(Console.ReadLine());
                if (element < 0)
                {
                    Console.WriteLine("Номер першого від’ємного числа: {0}", i);
                    break;
                }
                
                if (n-1 == 0)
                {
                    Console.WriteLine("Жодне число не є від’ємним");
                    break;
                }
                
                
                i++;
                n--;
            } while (n >= 0);
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Для виконання блоку 1 (варіант ...) введіть 1");
                Console.WriteLine("Для виконання блоку 2 (варіант ...) введіть 2");
                Console.WriteLine("Для виконання блоку 3 (варіант ...) введіть 3");
                Console.WriteLine("Для виходу з програми введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Виконую блок 1");
                        DoBlock_1();
                        break;
                    case 2:
                        Console.WriteLine("Виконую блок 2");
                        DoBlock_2();
                        break;
                    case 3:
                        Console.WriteLine("Виконую блок 3");
                        DoBlock_3();
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіть, будь ласка, вибір із 1, 2, 3, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
    }
}
