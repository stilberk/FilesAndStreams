using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ZippingSlicedFiles
{
    class zipSliced
    {
        static void Main()
        {
            Console.WriteLine("Enter desired number of parts:");
            int parts = int.Parse(Console.ReadLine());
            int divParts = parts;
            Console.WriteLine("Enter source file path:");
            string path = Console.ReadLine();
            string source = @path;
            string destination = @"../newfile";
            List<string> sourceFiles = new List<string>();
            //Compression and decompression added inside the methods
            sourceFiles = SplitFile(source, divParts, destination);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string assembledFileDestination = @desktop+"\\newfile.avi";
            AssembleFiles(sourceFiles, assembledFileDestination);
            Console.WriteLine("The file parts are located in the bin folder of this assembly");
            Console.WriteLine("The new file was saved on your desktop");
        }

        private static void AssembleFiles(List<string> files, string destination)
        {
            for (int i = 0; i < files.Count; i++)
            {
                var fsRead = new FileStream(files[i], FileMode.Open);
                var fsWrite = new FileStream(destination, FileMode.Append);
                byte[] buffer = new byte[4096];
                using (fsRead)
                {
                    using (fsWrite)
                    {
                        using (var deCompress = new GZipStream(fsRead,CompressionMode.Decompress,false))
                        {
                            while (true)
                            {
                                int readBytes = deCompress.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }
                                fsWrite.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }

        public static List<string> SplitFile(string sourceFile, int parts, string destinationDir)
        {
            List<string> files = new List<string>();
            int bytesStart = 0;
            FileInfo flInfo = new FileInfo(sourceFile);
            long calcPartForDevision = flInfo.Length / parts;
            for (int i = 0; i < parts; i++)
            {
                var fsRead = new FileStream(sourceFile, FileMode.Open);
                var fsWrite = new FileStream(destinationDir + i.ToString(), FileMode.Create);
                files.Add(destinationDir + i.ToString());
                byte[] buffer = new byte[4096];
                int totalRead = 0;
                fsRead.Seek(bytesStart, SeekOrigin.Current);
                using (fsRead)
                {
                    using (fsWrite)
                    {
                        using (var compression = new GZipStream(fsWrite,CompressionMode.Compress, false))
                        {
                            while (true)
                            {
                                int readByte = fsRead.Read(buffer, 0, buffer.Length);
                                totalRead += readByte;
                                if (readByte == 0)
                                {
                                    break;
                                }
                                compression.Write(buffer, 0, readByte);
                                if (totalRead >= calcPartForDevision)
                                {
                                    break;
                                }
                            }
                            bytesStart += totalRead;
                        }
                    }
                }
            }
            return files;
        }
    }
}
