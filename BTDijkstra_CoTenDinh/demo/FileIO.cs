using System;
using System.Collections.Generic;
using System.IO;

class FileIO
{
    private List<string[]> thu(string[] fileName)
    {
        List<string[]> hihi = new List<string[]>();

        for (int i = 0; i < fileName.Length; ++i)
            hihi.Add(File.ReadAllLines(fileName[i]));

        return hihi;
    }

    private List<string[]> tach(List<string[]> hihi, int k)
    {
        char[] sep = new char[] { ' ', '\t' };

        List<string[]> cc = new List<string[]>();

        for (int i = 0; i < hihi.Count; ++i)
            cc.Add(hihi[i][k].Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries));

        return cc;
    }

    public Input docFile(string[] fileName)
    {
        List<string[]> hihi = thu(fileName);

        int n = int.Parse(hihi[0][0]);

        List<string> vertexName = new List<string>();
        Graph g = new Graph(n);

        for (int i = 1; i < hihi[0].Length; ++i)
        {
            List<string[]> t = tach(hihi, i);

            for (int j = 0; j < n; ++j)
            {
                int weight = int.Parse(t[0][j]);
                int vehicle = int.Parse(t[2][j]);
                string nameRoad = t[1][j];

                g[i - 1, j] = new Road(weight, vehicle, nameRoad);
            }

            vertexName.Add(t[3][1]);
        }

        Input input = new Input(vertexName, g);

        return input;
    }
}

class Input
{
    public List<string> vertexName;
    public Graph g;

    public Input(List<string> vertexName, Graph g)
    {
        this.vertexName = vertexName;
        this.g = g;
    }
}