using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {
            FileStream inpStream = new FileStream("lin.jpg", FileMode.Open);
            FileStream outpStream = new FileStream("kali-lin.jpg", FileMode.Create);
            using (inpStream)
            {
                using (outpStream)
                {
                    byte[] bytes = new byte[4096];
                    while (true)
                    {
                        int readBytes = inpStream.Read(bytes, 0, bytes.Length);
                        if (readBytes==0){break;}
                        outpStream.Write(bytes, 0, readBytes);                 
                    }
                }
            }
        }
    }
}
