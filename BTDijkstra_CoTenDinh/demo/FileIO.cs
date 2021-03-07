using System.Collections.Generic;
using System.IO;

class FileIO
{
    private List<string[]> readFileList(string[] fileName)
    {
        List<string[]> fileList = new List<string[]>();

        foreach (string name in fileName)
            fileList.Add(File.ReadAllLines(name));

        return fileList;
    }

    private List<string[]> splitListStr(List<string[]> fileList, int line)
    {
        char[] sep = new char[] { ' ', '\t' };

        List<string[]> listStr = new List<string[]>();

        foreach (string[] str in fileList)
            listStr.Add(str[line].Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries));

        return listStr;
    }

    private (int weight, int vehicle, string nameRoad) getValue(List<string[]> fileList, int vt)
    {
        List<string> arrValue = new List<string>();

        for (int i = 0; i < fileList.Count - 1; ++i)
            arrValue.Add(giatri(fileList[i], vt));

        return (int.Parse(arrValue[0]), int.Parse(arrValue[2]), arrValue[1]);
    }

    private string giatri(string[] list, int vt)
    {
        return list[vt];
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
                (int weight, int vehicle, string nameRoad) = getValue(listStr, j);

                g[i - 1, j] = new Road(weight, vehicle, nameRoad);
            }

            vertexName.Add(giatri(listStr[3], 1));
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