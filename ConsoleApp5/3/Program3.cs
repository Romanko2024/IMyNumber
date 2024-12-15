using System;
using System.Text;

class Program3 // Варіант7. Замінити всі від’ємні числа на їхні модулі, після чого знайти серед усіх елементів масиву два мінімальних.
{
    static void Main(string[] args)
    {
        // Вивід варіантів заповнення масиву користувачеві
        Console.WriteLine("Оберіть спосіб заповнення масиву:");
        Console.WriteLine("1. Випадково");
        Console.WriteLine("2. Вручну, кожен елемент у окремому рядку");
        Console.WriteLine("3. Вручну, всі елементи у одному рядку");

        // Отримання вибору користувача
        int choice = Convert.ToInt32(Console.ReadLine());
        int[] array = null; // Ініціалізація масиву

        // Обробка вибору користувача через switch
        switch (choice)
        {
            // Випадок 1: випадкове заповнення масиву
            case 1:
                Console.WriteLine("Введіть розмір масиву:");
                int sizeRandom = Convert.ToInt32(Console.ReadLine());
                array = FillArrayRandom(sizeRandom); // Заповнення масиву випадковими числами
                PrintArray(array); // Виведення масиву на екран
                break;

            // Випадок 2: заповнення масиву вручну, кожен елемент у окремому рядку
            case 2:
                Console.WriteLine("Введіть розмір масиву:");
                int sizeManual = Convert.ToInt32(Console.ReadLine());
                array = FillArraySeparateLines(sizeManual); // Заповнення масиву вручну користувачем
                break;

            // Випадок 3: заповнення масиву вручну, всі елементи у одному рядку
            case 3:
                array = FillArraySingleLine(); // Заповнення масиву користувачем в одному рядку
                break;

            // В разі, якщо користувач ввів невірне значення
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }

        // Перевірка чи масив не пустий
        if (array != null)
        {
            array = ReplaceNegativeWithAbsolute(array); // Заміна від'ємних чисел на їхні модулі
            PrintArray(array); // Виведення масиву після заміни від'ємних чисел
            FindTwoMin(array); // Знаходження двох мінімальних чисел у масиві
        }

        Console.ReadLine(); // Очікування натискання клавіші Enter перед завершенням програми
    }

    // Метод для заповнення масиву випадковими числами
    static int[] FillArrayRandom(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(-100, 101); // Заповнення масиву випадковими числами в діапазоні від -100 до 100
        }

        return arr; // Повернення заповненого масиву
    }

    // Метод для заповнення масиву вручну, кожен елемент у окремому рядку
    static int[] FillArraySeparateLines(int size)
    {
        int[] arr = new int[size];

        Console.WriteLine($"Введіть {size} чисел, кожне у окремому рядку:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine()); // Заповнення масиву значеннями, введеними користувачем
        }

        return arr; // Повернення заповненого масиву
    }

    // Метод для заповнення масиву вручну, всі елементи у одному рядку
    static int[] FillArraySingleLine()
    {
        Console.WriteLine("Введіть числа, розділені пробілами або табуляціями:");
        string input = Console.ReadLine(); // Отримання введених користувачем значень у рядок
        string[] numbers = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); // Розділення рядка на числа за пробілами або табуляціями
        int[] arr = new int[numbers.Length]; // Створення масиву з числами

        for (int i = 0; i < numbers.Length; i++)
        {
            arr[i] = Convert.ToInt32(numbers[i]); // Перетворення чисел з рядкового формату в числовий та запис їх у масив
        }

        return arr; // Повернення заповненого масиву
    }

    // Метод для виведення масиву на екран
    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Елементи масиву:");
        StringBuilder sb = new StringBuilder(); // Використання StringBuilder для оптимізації виводу
        foreach (int num in arr)
        {
            sb.Append(num + " "); // Додавання елементів масиву до рядка
        }
        Console.WriteLine(sb.ToString()); // Виведення рядка з елементами масиву на екран
    }

    // Метод для заміни від'ємних чисел на їхні модулі
    static int[] ReplaceNegativeWithAbsolute(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                arr[i] = Math.Abs(arr[i]); // Заміна від'ємного числа на його модуль
            }
        }

        return arr; // Повернення масиву зі зміненими значеннями
    }

    // Метод для пошуку двох мінімальних чисел у масиві
    static void FindTwoMin(int[] arr)
    {
        if (arr.Length < 2)
        {
            Console.WriteLine("Масив має недостатньо елементів"); // Повідомлення про недостатню кількість елементів у масиві
            return;
        }

        int min1 = int.MaxValue, min2 = int.MaxValue; // Ініціалізація змінних для зберігання двох мінімальних чисел

        // Пошук двох мінімальних чисел у масиві
        foreach (int num in arr)
        {
            if (num <= min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
            {
                min2 = num;
            }
        }

        // Виведення результату знайдених двох мінімальних чисел
        Console.WriteLine($"Два мінімальних числа: {min1} {min2}");
    }
}
