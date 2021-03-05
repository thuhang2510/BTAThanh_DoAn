using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        enum LoaiXe
        {
            oto,
            xemay,
            ca2
        }

        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            string[] tenFile = { "input_trongso.txt", "input_tenduongdi.txt", "input_loaixe.txt", "input_tenDinh.txt" };
            Input input = fileIO.docFile(tenFile);

            Dijkstra dijkstra = new Dijkstra(input.g, input.vertexName);

            List<string> kq = dijkstra.findPath("Hung_Yen", "Yen_Bai", (int)LoaiXe.xemay);

            if (kq == null)
                Console.WriteLine("Khong co duong di");
            else
                Console.WriteLine(string.Join(" --> ", kq));
        }
    }
}
