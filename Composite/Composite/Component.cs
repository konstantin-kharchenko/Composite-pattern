using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Component
    {
        public int PositionInSomeThing;

        public int page, PAGE, PerPage;

        public Component Per1, Per2;

        public Component(int page, int pageinsom)
        {
            this.page = page;
            PositionInSomeThing = pageinsom;
            PerPage = 100;
        }

        public abstract Component Parent { get; set; }

        public abstract int Page { get; set; }

        public abstract void Add(string contents);

        public abstract void Add(char contents);

        public abstract int ChildsCount { get; }

        public abstract List<Component> GetArreyOfSomething();

        public abstract override string ToString();
    }
}
