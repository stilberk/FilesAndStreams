using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class LineNnumbers
    {
        static void Main()
        {
            int nums = 0;
            using (StreamReader reader = new StreamReader("lines.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    nums++;
                    using (StreamWriter writer = new StreamWriter("numberedLines.txt", true))
                    {
                        writer.WriteLine(nums.ToString()+"- " + line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
