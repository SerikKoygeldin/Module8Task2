using System;
using System.IO;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module8Work2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dirName = @"C:\\CSharp\\1";
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            try
            {
                long dirSize = DirSize(dirInfo);
                Console.WriteLine(dirSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }        
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo Di in dis)
            {
                size += DirSize(d);
            }

            return size;
        }
    }
}
