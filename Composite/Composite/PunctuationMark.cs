using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Composite
{
    class PunctuationMark : Component
    {
        public char contents;
        public PunctuationMark(char contents, int Page, int PossitionInSomeThing) : base(Page, PossitionInSomeThing)
        {
            this.contents = contents;
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
                return 0;
            }
        }

        public override void Add(string contents)
        {
            throw new NotImplementedException();
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
            return contents.ToString();
        }
    }
}
