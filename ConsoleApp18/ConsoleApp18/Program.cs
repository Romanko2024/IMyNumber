using System;
using System.Collections.Generic;

class Edge : IComparable<Edge> //IComparable<Edge> --для інтерф. для порівняння <дуг>
{
    //
    public int U { get; }
    public int V { get; }
    public int Length { get; }
    public int Index { get; }
    //іініц. об'єкт (дуги)
    public Edge(int u, int v, int len, int idx)
    {
        U = u;
        V = v;
        Length = len;
        Index = idx;
    }
    //реалізація інтерфейсу
    public int CompareTo(Edge other)
    {
        return Length.CompareTo(other.Length); //визначає як порівняти дуги
    }
}

class Program
{
    static void Main()
    {
        //зчитуємо кількість вершин N і кількість ребер M
        string[] firstLine = Console.ReadLine().Split();
        int N = int.Parse(firstLine[0]);  // кількість вершин
        int M = int.Parse(firstLine[1]);  //кількість ребер
        //ліст з ребрами по порядку вводу
        List<Edge> edges = new List<Edge>();
        //зчит всіх ребер
        for (int i = 0; i < M; i++)
        {
            string[] edgeData = Console.ReadLine().Split();
            int u = int.Parse(edgeData[0]);
            int v = int.Parse(edgeData[1]);
            int len = int.Parse(edgeData[2]);

            edges.Add(new Edge(u, v, len, i + 1));
        }
        //сорт ребер за довж (він неявно викликає CompareTo)
        edges.Sort();
        //вивід відсортованих
        foreach (Edge edge in edges)
        {
            Console.WriteLine($"{edge.U} {edge.V} {edge.Length} {edge.Index}");
        }
    }
}