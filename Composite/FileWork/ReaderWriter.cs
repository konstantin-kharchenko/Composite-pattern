using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.FileWork
{
    class ReaderWriter
    {
        public static List<string> Read1(string path, int kol)
        {
            StreamReader read = new StreamReader(path);
            List<string> TEXT = new List<string>();
            string line = "";
            StringBuilder buf = new StringBuilder("");
            int ii = 0;
            while ((line = read.ReadLine()) != null)
            {
                ii++;
                buf.Append(line);
                if (ii == kol) { TEXT.Add(buf.ToString()); buf.Clear(); ii = 0; }
            }
            if (buf.Length > 0) TEXT.Add(buf.ToString());
            read.Close();
            return TEXT;
        }
        public static string Read2(string path)
        {
            StreamReader read = new StreamReader(path);
            string tex = read.ReadToEnd();
            return tex;
        }
        public static void Write(List<File.WordsInFile> unik)
        {
            char ferst_char = unik[0].name_of_word[0];
            bool join = true;
            StreamWriter writer = new StreamWriter("output.txt");
            foreach (File.WordsInFile bugf in unik)
            {
                if (bugf.name_of_word[0] != ferst_char)
                {
                    join = true;
                    ferst_char = bugf.name_of_word[0];
                }
                if (join) { Console.WriteLine(ferst_char); join = false; writer.WriteLine(ferst_char); }
                Console.WriteLine(bugf.name_of_word + "-> in kol " + bugf.SUM + "-> in pages " + String.Join(", ", bugf.possitionInPage));
                writer.WriteLine(bugf.name_of_word + "-> in kol " + bugf.SUM + "-> in pages " + String.Join(", ", bugf.possitionInPage));
            }
            writer.Close();
        }
    }
}
