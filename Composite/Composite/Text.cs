using Composite.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Text : Component
    {
        public string text;
        int PG;
        public List<Component> items;
        public Text(int Page) : base(0, 0)
        {
            items = new List<Component>();
            PG = Page;
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
        public override int ChildsCount
        {
            get
            {
                return items.Count;
            }
        }

        public void SORT()
        {
            var SentencesSort = GetArreyOfSomething();
            SentencesSort.Sort(new SentenceComparer());
            NewText(SentencesSort);
        }

        public void NewText(List<Component> SentencesSort)
        {
            int i = 0;
            for (int j = 0; j < items.Count; j++)
            {
                if (items[j].ChildsCount > 0)
                {
                    items[j] = SentencesSort[i];
                    i++;
                }
            }
        }

        public override void Add(string contents)
        {
            Sentence buf;
            for (int i = 0, j = 0; i < contents.Length; i++)
            {
                if (contents[i] == '.' || contents[i] == '?' || contents[i] == '!')
                {
                    Page = j % PerPage + 1;
                    buf = new Sentence(j, Page);
                    buf.Add(contents.Substring(j, i - j + 1));
                    buf.Parent = this;
                    items.Add(buf);
                    j = i + 2;
                    if (i + 1 < contents.Length)
                    {
                        PunctuationMark pun = new PunctuationMark(' ', Page, i);
                        items.Add(pun);
                    }
                }
            }
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
            text = str.ToString();
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
    class SentenceComparer : IComparer<Component>
    {
        public int Compare(Component p1, Component p2)
        {
            return p1.GetArreyOfSomething().Count.CompareTo(p2.GetArreyOfSomething().Count);
        }
    }
}
