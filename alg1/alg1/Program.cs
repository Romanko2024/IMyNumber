class Program
{
    static void Main()
    {
        int n = 1;

        while (true)
        {
            double ls = 100 * Math.Pow(n, 2);
            double rs = Math.Pow(2, n);

            Console.WriteLine($"n = {n}: 100n^2 = {ls}, 2^n = {rs}");
            if (ls < rs)
            {
                Console.WriteLine($"Найменше n, для якого 100n^2 < 2^n: {n}");
                break;
            }

            n++;
        }
    }
}
