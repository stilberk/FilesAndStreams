using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine())!= null)
                {
                    if (count%2!=0)
                    {
                     Console.WriteLine(line);
                    }
                    count++;
                }
            }
        }
    }
}
