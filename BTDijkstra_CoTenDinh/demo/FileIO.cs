using System.Collections.Generic;
using System.IO;

class FileIO
{
    private string[] splitListStr(string fileLine)
    {
        char[] sep = new char[] { ' ', '\t' };

        return fileLine.Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
    }

    public Input docFile()
    {
        string[] fileTrongSo = File.ReadAllLines("input_trongso.txt");
        string[] fileTenDinh = File.ReadAllLines("input_tenduongdi.txt");
        string[] fileTenDuong = File.ReadAllLines("input_loaixe.txt");
        string[] fileLoaiXe = File.ReadAllLines("input_tenDinh.txt");

        int n = int.Parse(fileTrongSo[0]);
        List<string> vertexName = new List<string>();
        Graph g = new Graph(n);

        for (int i = 1; i < fileTrongSo.Length; ++i)
        {
            string[] arrTS = splitListStr(fileTrongSo[i]);
            string[] arrTenDinh = splitListStr(fileTenDinh[i]);
            string[] arrTenDuong = splitListStr(fileTenDuong[i]);
            string[] arrLoaiXe = splitListStr(fileLoaiXe[i]);

            for (int j = 0; j < n; ++j)
            {
                int weight = int.Parse(arrTS[j]);
                int vehicle = int.Parse(arrLoaiXe[j]);
                string nameRoad = arrTenDuong[j];

                g[i - 1, j] = new Road(weight, vehicle, nameRoad);
            }

            vertexName.Add(arrTenDinh[1]);
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