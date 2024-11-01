using System;
using System.CodeDom.Compiler;
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
        private Dictionary<string, List<string>> uniWords = new Dictionary<string, List<string>>();
        private (string word, int count)[] arrange;

        public void Read()
        {
            string temp = "";
            FileManager.Read(fileName, out content, out temp);
            Console.WriteLine($"\n{temp}");
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

        //okay
        public void uniqueWord()
        {
            string temp = "";

            for (int x = 0; x < words.Count; x++)
            {
                string word = words[x].ToLower();

                for (int y = 0; y < words[x].Length; y++)
                {
                    if ((word[y] >= '0' && word[y] <= '9') || (word[y] >= 'A' && word[y] <= 'Z') || (word[y] >= 'a' && word[y] <= 'z'))
                        temp += word[y];
                }

                if (temp.Length > 0)
                    uniWordCount(temp);
                
                temp = "";
            }
        }

        private void uniWordCount(string temp)
        {
            if (!uniWords.ContainsKey(temp))
            {
                uniWords[temp] = new List<string>();
            }

            uniWords[temp].Add(temp);
        }

        public int getUniWordCount()
        {
           return uniWords.Count;
        }

        public void arrangeOrder()
        {
            arrange = new (string word, int count)[uniWords.Count];
            int counter = 0;

            foreach (KeyValuePair<string, List<string>> kvp in uniWords)
            {
                arrange[counter] = (kvp.Key, kvp.Value.Count);
                counter++;
            }

            wordCountOrder();
        }

        private void wordCountOrder()
        {
            for (int i = 0; i < arrange.Length; i++)
            {
                for (int j = 0; j < arrange.Length - 1; j++)
                {
                    if (arrange[j].count < arrange[j + 1].count)
                    {
                        Tuple<string, int> temp = new Tuple<string, int>(arrange[j].word, arrange[j].count);
                        arrange[j] = (arrange[j + 1].word, arrange[j + 1].count);
                        arrange[j + 1] = (temp.Item1, temp.Item2);
                    }
                }
            }
        }

        private void alphabeticalOrder(string a, string b, int count)
        {
            int wordLength = 0;

            if (a.Length < b.Length || a.Length == b.Length)
                wordLength = a.Length;
            else if (b.Length < a.Length)
                wordLength = b.Length;


            for (int x = 0; x < wordLength; x++)
            {
                if (a[x] < b[x])
                {
                    arrange[count].word = b;
                    arrange[count + 1].word = a;
                }
            }

            if (a.Length < b.Length)
            {
                arrange[count].word = b;
                arrange[count + 1].word = a;
            }

        }

        public void displayWords()
        {
            for (int i = 0; i < arrange.Length; i++)
            {
                Console.WriteLine($"{i+1}. {arrange[i].word} = {arrange[i].count}");
            }
        }
    }
}
