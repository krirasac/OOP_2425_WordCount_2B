using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_WordCount_2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> fileList = new List<string>();
            File_thing[] files = new File_thing[] { };
            string temp = "";

            if(FileManager.Read(Directory.mainList, out fileList, out temp))
            {
                Console.WriteLine(temp);
                files = new File_thing[fileList.Count];
                for(int x = 0; x < files.Length; x++)
                {
                    files[x] = new File_thing();
                    files[x].fileName = fileList[x];
                    files[x].Read();
                    files[x].Separate();
                    files[x].uniqueWord();
                    files[x].arrangeOrder();
                    Console.WriteLine($"{files[x].fileName} contains {files[x].getWordCount()} words and {files[x].getUniWordCount()} unique words.\n");
                    files[x].displayWords();
                }
            }

            Console.ReadKey();
        }
    }
}
