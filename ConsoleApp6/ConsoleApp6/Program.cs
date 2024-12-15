using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int P = int.Parse(input[1]);

        int M = N;
        while (M % P != 0)
        {
            M++;
        }

        Console.WriteLine(M);
    }
}



