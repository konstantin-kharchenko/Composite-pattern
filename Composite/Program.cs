using ClassLibrary1;
using Composite.FileWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            bool kek = true, kok = true, OPO = true;
            Class2 menu = new Class2();
            string text = "";
            do
            {
                try
                {
                    while (kek)
                    {
                        int a = menu.menu_language();
                        if (a == -1) kek = false;
                        if (a == -2) { kok = false; kek = false; continue; }
                        else if (a == -3) continue;
                    }
                    if (!kok) continue;
                    const int CountSymblsOnPage = 100;

                    if (OPO)
                    {
                        IOC.TEXT();
                        text = Console.ReadLine();

                        OPO = false;
                    }
                    GoodText goodtext = new GoodText(text);
                    text = goodtext.WorkWithBadText();
                    Text Text_ = new Text(CountSymblsOnPage);
                    Text_.Add(text);
                    Console.WriteLine(Text_.ToString());
                    bool kk = true;
                    do
                    {
                        IOC.Choice(); IOC.number_1(); IOC.number_2(); IOC.number_3(); IOC.number_4(); IOC.number_5();
                        string xz = Console.ReadLine();
                        switch (xz)
                        {
                            case "1":
                                {
                                    Text_.SORT();
                                    Text_.ToString();
                                    Console.WriteLine(Text_.text);
                                }
                                break;
                            case "2":
                                {
                                    IOC.Chouse_Lenght();
                                    int lenght = Convert.ToInt32(Console.ReadLine());
                                    HashSet<string> UnikumWords = new HashSet<string>();
                                    for (int i = 0; i < Text_.items.Count; i++)
                                    {
                                        if (Text_.items[i].ChildsCount > 0)
                                        {
                                            Sentence sen = Text_.items[i] as Sentence;
                                            if (sen.ToString()[sen.ToString().Length - 1] == '?')
                                            {
                                                for (int j = 0; j < sen.items.Count; j++)
                                                {
                                                    if (sen.items[j].ChildsCount == lenght)
                                                    {
                                                        UnikumWords.Add(sen.items[j].ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    foreach (string i in UnikumWords)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }
                                break;
                            case "3":
                                {
                                    IOC.Chouse_Lenght();
                                    int lenght = Convert.ToInt32(Console.ReadLine());
                                    List<int> pos = new List<int>();
                                    for (int i = 0; i < Text_.ChildsCount; i++)
                                    {
                                        Sentence sen = Text_.items[i] as Sentence;
                                        if (sen != null)
                                        {
                                            for (int j = 0; j < sen.items.Count; j++)
                                            {
                                                Word wr = sen.items[j] as Word;
                                                if (wr != null)
                                                    if (wr.components.Count == lenght && !EqualFirstCharacter(wr.ToString()))
                                                    {
                                                        if (j != 0)
                                                        {
                                                            sen.items.RemoveAt(j - 1);
                                                            sen.items.RemoveAt(j - 1);
                                                        }
                                                        else sen.items.RemoveAt(j);
                                                        if (j + 1 < sen.items.Count)
                                                            for (int k = j + 1; k < sen.items.Count; k++)
                                                            {
                                                                sen.items[k].PositionInSomeThing = sen.items[k].PositionInSomeThing - lenght - 1;
                                                            }
                                                        for (int jj = i; jj < Text_.ChildsCount; jj++)
                                                        {
                                                            Text_.items[jj].PositionInSomeThing = Text_.items[jj].PositionInSomeThing - lenght - 1;
                                                        }
                                                        j--;
                                                    }
                                            }
                                        }
                                    }
                                    Text_.ToString();
                                    Console.WriteLine(Text_.text);
                                }
                                break;
                            case "4":
                                {
                                    IOC.Chouse_sentence();
                                    for (int z = 0; z < Text_.items.Count; z++)
                                    {
                                        Sentence sentence = Text_.items[z] as Sentence;
                                        if (sentence != null)
                                            Console.WriteLine(sentence.ToString());
                                    }
                                    int Num_of_sentence = Int32.Parse(Console.ReadLine());
                                    IOC.Chouse_Lenght();
                                    int lenght = Int32.Parse(Console.ReadLine());
                                    IOC.Chouse_word();
                                    string word = Console.ReadLine();
                                    int position = 2 * Num_of_sentence - 2;
                                    Sentence sen = Text_.items[position] as Sentence;
                                    if (sen != null)
                                    {
                                        for (int j = 0; j < sen.items.Count; j++)
                                        {
                                            Word wr = sen.items[j] as Word;
                                            if (wr != null)
                                            {
                                                if (wr.components.Count == lenght)
                                                {
                                                    if (j != 0)
                                                    {
                                                        Word wr2 = new Word(wr.Page, wr.PositionInSomeThing);
                                                        wr2.Add(word);
                                                        sen.items.RemoveAt(j);
                                                        sen.items.Insert(j, wr2);
                                                    }
                                                    else sen.items.RemoveAt(j);
                                                    if (j + 1 < sen.items.Count)
                                                    {
                                                        for (int k = j + 1; k < sen.items.Count; k++)
                                                        {
                                                            sen.items[k].PositionInSomeThing = sen.items[k].PositionInSomeThing + (word.Length - lenght);
                                                        }
                                                    }
                                                    for (int jj = position; jj < Text_.ChildsCount; jj++)
                                                    {
                                                        Text_.items[jj].PositionInSomeThing = Text_.items[jj].PositionInSomeThing + (word.Length - lenght);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Text_.ToString();
                                    Console.WriteLine(Text_.text);
                                }
                                break;
                            case "5":
                                {
                                    IOC.How_match();
                                    int kol = Int32.Parse(Console.ReadLine()); File.FileWork(kol);
                                }
                                break;
                            case "end": { kk = false; kok = false; } continue;
                            case "language": { kk = false; kek = true; } break;
                            default: IOC.error4(); break;
                        }

                    } while (kk);

                }
                catch (Exception ex)
                {
                    string a1 = ex.TargetSite.ToString();
                    if (a1 == "Void ThrowArgumentOutOfRangeException(System.ExceptionArgument, System.ExceptionResource)")
                        menu.error_language(1);
                    if (a1 == "Char get_Chars(Int32)")
                    {

                        continue;
                    }
                    if (a1 == "Void StringToNumber(System.String, System.Globalization.NumberStyles, NumberBuffer ByRef, System.Globalization.NumberFormatInfo, Boolean)")
                    {
                        IOC.Number();
                    }
                }
            }
            while (kok);
            Console.ReadKey();
        }
        public static bool EqualFirstCharacter(String aa)//проверяет с какой буквы начинается слово(нужны согласные)
        {
            char a = aa[0];
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'e', 'y', 'u', 'i', 'o', 'a', 'A', 'E', 'Y', 'U', 'I', 'O', 'А', 'О', 'Е', 'У', 'Э', 'Я', 'И', 'Ю', 'Ё', 'Ы' };
            foreach (char c in vowels)
            {
                if (c == a) return true;
            }
            return false;
        }
    }
}
