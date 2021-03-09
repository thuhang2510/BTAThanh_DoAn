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
            Input input = fileIO.docFile();

            Dijkstra dijkstra = new Dijkstra(input.g, input.vertexName);

            List<string> kq = dijkstra.findPath("Hung_Yen", "Yen_Bai", (int)LoaiXe.xemay);

            if (kq == null)
                Console.WriteLine("Khong co duong di");
            else
            {
                string chuoiKQ = "";

                for (int i = 0; i < kq.Count - 1; ++i)
                    chuoiKQ += kq[i] + " -- (" + kq[++i] + ") --> ";

                chuoiKQ += kq[kq.Count - 1];

                Console.WriteLine(chuoiKQ);
            }
        }
    }
}
