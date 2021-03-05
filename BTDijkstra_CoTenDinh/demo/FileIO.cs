using System;
using System.Collections.Generic;
using System.IO;

class FileIO
{
    private List<string[]> readFileList(string[] fileName)
    {
        List<string[]> fileList = new List<string[]>();

        for (int i = 0; i < fileName.Length; ++i)
            fileList.Add(File.ReadAllLines(fileName[i]));

        return fileList;
    }

    private List<string[]> splitListStr(List<string[]> fileList, int line)
    {
        char[] sep = new char[] { ' ', '\t' };

        List<string[]> listStr = new List<string[]>();

        for (int i = 0; i < fileList.Count; ++i)
            listStr.Add(fileList[i][line].Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries));

        return listStr;
    }

    public Input docFile(string[] fileName)
    {
        List<string[]> fileList = readFileList(fileName);

        int n = int.Parse(fileList[0][0]);

        List<string> vertexName = new List<string>();
        Graph g = new Graph(n);

        for (int i = 1; i < fileList[0].Length; ++i)
        {
            List<string[]> listStr = splitListStr(fileList, i);

            for (int j = 0; j < n; ++j)
            {
                int weight = int.Parse(listStr[0][j]);
                int vehicle = int.Parse(listStr[2][j]);
                string nameRoad = listStr[1][j];

                g[i - 1, j] = new Road(weight, vehicle, nameRoad);
            }

            vertexName.Add(listStr[3][1]);
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