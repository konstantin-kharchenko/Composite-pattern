using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Word : Component
    {
        public List<Component> components;
        public Word(int Page, int PositionInSomeThing) : base(Page, PositionInSomeThing)
        {
            components = new List<Component>();
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
                return components.Count;
            }
        }

        public override void Add(string contents)
        {
            Symbol buf;
            for (int i = 0; i < contents.Length; i++)
            {
                PAGE = (PositionInSomeThing + i) / PerPage + 1;
                buf = new Symbol(contents[i], PAGE, i);
                buf.Parent = this;
                components.Add(buf);
            }
        }

        public override void Add(char contents)
        {
            throw new NotImplementedException();
        }

        public override List<Component> GetArreyOfSomething()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Symbol a in components)
            {
                str.Append(a.contents);
            }
            return str.ToString();
        }
    }
}
