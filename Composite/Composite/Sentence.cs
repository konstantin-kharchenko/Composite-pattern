using Composite.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Sentence : Component
    {
        public List<Component> items;
        public PunctuationMark pun;
        public Word WordsInSentence;
        public Sentence(int PositionInSomeThing, int Page) : base(Page, PositionInSomeThing)
        {

            items = new List<Component>();
        }
        public override int ChildsCount
        {
            get
            {
                return items.Count;
            }
        }

        public override Component Parent { get; set; }

        public override int Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }

        public override void Add(string contents)
        {
            for (int i = 0, j = 0; i < contents.Length; i++)
            {
                if (IsPunctuation(contents[i]) || char.IsWhiteSpace(contents[i]))
                {

                    if (contents.Substring(j, i - j) != "")
                    {
                        PAGE = (PositionInSomeThing + j) / PerPage + 1;
                        WordsInSentence = new Word(PAGE, j);
                        WordsInSentence.Parent = this;
                        WordsInSentence.Add(contents.Substring(j, i - j));
                        items.Add(WordsInSentence);
                    }
                    pun = new PunctuationMark(contents[i], Page, i);
                    items.Add(pun);
                    j = i + 1;
                }
            }
        }
        public static bool IsPunctuation(char c)
        {
            if (c == ',' || c == '.' || c == ';' || c == ':' || c == '?' || c == '!' || c == '—') return true;
            return false;
        }
        public override void Add(char contents)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Component a in items)
            {
                str.Append(a.ToString());
            }
            return str.ToString();
        }

        public override List<Component> GetArreyOfSomething()
        {
            return items.FindAll(item =>
            {
                return item.ChildsCount > 0;
            });
        }
    }
}
