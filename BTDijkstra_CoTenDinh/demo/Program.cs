using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            Input input = fileIO.docFile("input.txt");

            Dijkstra dijkstra = new Dijkstra(input.g, input.vertexName);
            List<string> kq = dijkstra.findPath("Kieu_Ky", "Ngoc_Dong", 1);

            if (kq == null)
                Console.WriteLine("Khong co duong di");
            else
                Console.WriteLine(string.Join(" --> ", kq));
        }
    }
}
