using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main()
        {
            int count = 0;
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string readed = reader.ReadLine();
                while (readed!=null)
                {
                    using (StreamReader reader2 = new StreamReader("text.txt"))
                    {
                        string[] readed2 = reader2.ReadToEnd().Split(new[] {' ','\t','\n','\r','-',',','.'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        string theWord = "";
                        foreach (string word in readed2)
                        {
                            if (readed==word.ToLower())
                            {
                                count++;
                                theWord = word.ToLower();
                            }
                        }
                        words.Add(count.ToString()+"-"+theWord);
                    }
                    count = 0;
                    readed = reader.ReadLine();
                }
            }
            words.Sort();
            words.Reverse();
            foreach (var w in words)
            {
                string[] reformat = w.Split('-');
                string wrd = reformat[1] +" - "+ reformat[0];
                using (StreamWriter writer = new StreamWriter("results.txt", true))
                {
                    writer.WriteLine(wrd);
                }
            }
        }
    }
}
