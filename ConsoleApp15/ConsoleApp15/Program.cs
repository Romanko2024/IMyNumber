public class EquationSystem
{
    private double[,] coefficients = new double[2, 3]; // масив зберігання коефіцієнтів a1, b1, c1, a2, b2, c2

    // індексатор доступу до коеф-ів системи
    public double this[int equation, int coefficient]
    {
        get
        {
            // перевірка чи індекси (номер рівняння і номер коеф.) in range
            if (equation < 0 || equation > 1 || coefficient < 0 || coefficient > 2)
                throw new ArgumentOutOfRangeException("Некоректні індекси.");
            // надає значення
            return coefficients[equation, coefficient];
        }
        set
        {
            if (equation < 0 || equation > 1 || coefficient < 0 || coefficient > 2)
                throw new ArgumentOutOfRangeException("Некоректні індекси.");
            // змінює значення
            coefficients[equation, coefficient] = value;
        }
    }

    // метод введення коеф-ів системи
    public void InputCoefficients()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Введіть порядково коефіцієнти для рівняння {i + 1} (a, b, c): ");
            for (int j = 0; j < 3; j++)
            {
                this[i, j] = Convert.ToDouble(Console.ReadLine()); // використовуємо індексатор для збереження коефіцієнтів
            }
        }
    }

    // метод виведення рівнянь з коеф-ами
    public void DisplayCoefficients()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Рівняння {i + 1}: {this[i, 0]}x + {this[i, 1]}y = {this[i, 2]}"); // використовуємо індексатор для доступу до коефіцієнтів
        }
    }

    // метод знаходження розв'язку системи
    public (double x, double y)? Solve()
    {
        // за методом Крамера
        double a1 = this[0, 0], b1 = this[0, 1], c1 = this[0, 2];
        double a2 = this[1, 0], b2 = this[1, 1], c2 = this[1, 2];

        double determinant = a1 * b2 - a2 * b1;

        if (determinant == 0)
        {
            Console.WriteLine("Система не має розв'язків або має безліч розв'язків.");
            return null;
        }

        double x = (c1 * b2 - c2 * b1) / determinant;
        double y = (a1 * c2 - a2 * c1) / determinant;

        return (x, y);
    }

    // чи точка (x,y) є розв'язком системи?
    public bool IsSolution(double x, double y)
    {
        // цикл перевіряє чи ліва і права частина обох рівнянь +- однакові
        for (int i = 0; i < 2; i++)
        {
            double leftSide = this[i, 0] * x + this[i, 1] * y; // використовуємо індексатор для доступу до коефіцієнтів
            double rightSide = this[i, 2]; // використовуємо індексатор для доступу до коефіцієнтів
            if (Math.Abs(leftSide - rightSide) > 1e-9 * (1 + (Math.Abs(leftSide) + Math.Abs(rightSide)))) //похибка в одну мільярдну здається допустимою
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        // новий екземпляр класу для обчислень
        EquationSystem system = new EquationSystem();

        // ввід коеф-ів
        system.InputCoefficients();

        // вивід коеф-ів
        system.DisplayCoefficients();

        // знаходження розв'язку
        var solution = system.Solve();
        if (solution.HasValue) //HasValue повертає true якщо не null
        {
            Console.WriteLine($"Розв'язок: x = {solution.Value.x}, y = {solution.Value.y}");

            // перевірка розв'язку
            if (system.IsSolution(solution.Value.x, solution.Value.y))
            {
                Console.WriteLine("Точка є розв'язком системи.");
            }
            else
            {
                Console.WriteLine("Точка не є розв'язком системи.");
            }
        }
    }
}