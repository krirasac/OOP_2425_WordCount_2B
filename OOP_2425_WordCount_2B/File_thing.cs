using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_WordCount_2B
{
    internal class File_thing
    {
        public string fileName = "";
        private List<string> content = new List<string>();
        private List<string> words = new List<string>();

        public void Read()
        {
            string temp = "";
            FileManager.Read(fileName, out content, out temp);
            Console.WriteLine(temp);
        }

        public void Separate()
        {
            string[] temp = new string[] { };
            for(int a = 0; a < content.Count; a++)
            {
                temp = content[a].Split(' ');
                for(int b = 0; b < temp.Length; b++)
                {
                    words.Add(temp[b]);
                }
            }
        }

        public int getWordCount()
        {
            return words.Count;
        }

    }
}
