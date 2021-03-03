using System;

class Road
{
    public int weight;
    public int vehicle;

    public Road(int weight, int vehicle)
    {
        this.weight = weight;
        this.vehicle = vehicle;
    }
}

class Graph
{
    public Road[,] a;
    public int n { get; private set; }

    public Graph(int n)
    {
        this.n = n;
        a = new Road[n, n];

        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
                a[i, j] = new Road(-1, -1);
    }

    public Road this[int u, int v]
    {
        get { return a[u, v]; }
        set { a[u, v] = value; }
    }

    public void display(string separator)
    {
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
                Console.Write(a[i, j] + separator);

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}