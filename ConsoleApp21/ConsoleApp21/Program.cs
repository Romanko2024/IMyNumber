using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //випадкове число, що буде викликатися
        Random rand = new Random();
        //ліст обчислених часів переходу
        List<int> transitionTimes = new List<int>();
        //кількість симуляцій
        int simulations = 10;

        Console.WriteLine("Результати моделювання:");

        //виконати стількі скільки симуляцій
        for (int i = 0; i < simulations; i++)
        {
            int time = SimulateTransition(rand); //час на перехід
            transitionTimes.Add(time); //додаємо у список
            Console.WriteLine($"Запуск {i + 1}: Час переходу = {time} секунд");
        }

        // Знайти мінімальний, максимальний та середній час переходу
        int minTime = transitionTimes.Min();
        int maxTime = transitionTimes.Max();
        double avgTime = transitionTimes.Average();

        Console.WriteLine("\nРезультати аналізу:");
        Console.WriteLine($"Мінімальний час переходу: {minTime} секунд");
        Console.WriteLine($"Максимальний час переходу: {maxTime} секунд");
        Console.WriteLine($"Середній час переходу: {avgTime:F2} секунд");
    }

    //моделювання переходу з "очікування" до "виконання роботи"
    static int SimulateTransition(Random rand)
    {
        int time = 0; //зберігає час витрачений на перехід
        bool isWorking = false;

        //доки не відбудеться перехід до стану "виконання роботи"
        while (!isWorking)
        {
            time += rand.Next(1, 5); //випадковий приріст часу
            isWorking = rand.NextDouble() < 0.3; //перехід якщо менше 0.3
        }

        return time;
    }
}