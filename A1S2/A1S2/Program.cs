using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            long size = Volume(path);
            Console.WriteLine(size);
        }

        private static long Volume(string path)
        {
            long volume = 0;
            string[] dir = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                volume += fi.Length;

            }
            foreach (string paths in dir)
            {
                volume += Volume(paths);

            }
            return volume;

        }
    }
}
