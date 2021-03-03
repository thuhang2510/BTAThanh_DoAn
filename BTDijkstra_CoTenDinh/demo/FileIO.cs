using System;
using System.Collections.Generic;
using System.IO;

class FileIO
{
    public Input docFile(string fileName)
    {
        char[] sep = new char[] { ' ', '\t' };

        string[] lines = File.ReadAllLines(fileName);

        int n = int.Parse(lines[0]);

        List<string> vertexName = new List<string>();
        Graph g = new Graph(n);

        for (int i = 1; i < lines.Length; ++i)
        {
            string[] content = lines[i].Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
            int N = int.Parse(content[0]);

            for (int j = 0; j < N; ++j)
            {
                int v = int.Parse(content[j * 3 + 1]);
                int weight = int.Parse(content[j * 3 + 2]);
                int vehicle = int.Parse(content[j * 3 + 3]);

                g[i - 1, v] = new Road(weight, vehicle);
            }

            vertexName.Add(content[3 * N + 1]);
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