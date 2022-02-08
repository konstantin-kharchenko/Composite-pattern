using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.FileWork
{
    class File
    {
        public static void FileWork(int kol)
        {
            List<string> TEXT = ReaderWriter.Read1("input.txt", kol);
            for (int i = 0; i < TEXT.Count; i++)
            {
                GoodText goodtext = new GoodText(TEXT[i]);
                TEXT[i] = goodtext.WorkWithBadText();
            }
            List<Text> ClassText = new List<Text>();
            for (int i = 0; i < TEXT.Count; i++)
            {
                Text bufer = new Text(i + 1);
                bufer.Add(TEXT[i]);
                ClassText.Add(bufer);
            }
            string tex = ReaderWriter.Read2("input.txt");
            Text Tex = new Text(0);
            Tex.Add(tex);
            List<string> WordsWithoutRepeat = new List<string>();
            WordsWithoutRepeat = FindWords(Tex).ToList<string>();
            WordsInFile arrey_in_file_buffer;
            List<WordsInFile> arrey_in_file = new List<WordsInFile>();
            int sum = 0;
            for (int i = 0; i < WordsWithoutRepeat.Count; i++)
            {
                string we = WordsWithoutRepeat[i];
                arrey_in_file_buffer = new WordsInFile();
                arrey_in_file_buffer.possitionInPage = new List<int>();
                arrey_in_file_buffer.name_of_word = we.ToLower();
                for (int j = 0; j < ClassText.Count; j++)
                {
                    Text bufer = ClassText[j];
                    for (int k = 0; k < bufer.ChildsCount; k++)
                    {
                        Sentence bufer2 = bufer.items[k] as Sentence;
                        if (bufer2 != null)
                            for (int c = 0; c < bufer2.ChildsCount; c++)
                            {
                                Word bufer3 = bufer2.items[c] as Word;
                                if (bufer3 != null)
                                    if (we == bufer3.ToString())
                                    {
                                        sum++;
                                        arrey_in_file_buffer.possitionInPage.Add(j + 1);
                                    }
                            }
                    }
                }
                arrey_in_file_buffer.SUM = sum;
                sum = 0;
                arrey_in_file.Add(arrey_in_file_buffer);
            }
            arrey_in_file.Sort((WordsInFile a, WordsInFile b) => a.name_of_word.CompareTo(b.name_of_word));
            List<WordsInFile> unik = arrey_in_file.GroupBy(a => a.name_of_word).Select(g => g.First()).ToList();
            ReaderWriter.Write(unik);
        }
        public struct WordsInFile
        {
            public string name_of_word;
            public List<int> possitionInPage;
            public int SUM;
        }
        public static HashSet<string> FindWords(Text Tex)
        {
            HashSet<string> words = new HashSet<string>();
            for (int j = 0; j < Tex.items.Count; j++)
            {
                Sentence sen = Tex.items[j] as Sentence;
                if (sen != null)
                    for (int i = 0; i < sen.items.Count; i++)
                    {
                        Word wr = sen.items[i] as Word;
                        if (wr != null)
                        {
                            words.Add(wr.ToString());
                        }
                    }
            }
            return words;
        }
    }
}
