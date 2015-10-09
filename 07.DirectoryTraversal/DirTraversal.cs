using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.DirectoryTraversal
{
    class DirTraversal
    {
        static void Main()
        {
            Console.WriteLine("Enter directory path:");
            string getPath = Console.ReadLine();
            string path = @getPath;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var files = Directory.GetFiles(path);
            var orderByExt = files.OrderBy(f => new FileInfo(f).Extension);
            var fileOrderBySize = orderByExt.OrderBy(f => new FileInfo(f).Length);
            foreach (var fileName in fileOrderBySize)
            {
                using (var writer = new StreamWriter(desktop+"\\text.txt",true))
                {
                    writer.WriteLine("--"+fileName.Split('\\').Last() +" - "+ new FileInfo(fileName).Length+"kb");
                }
            }           
        }
    }
}
