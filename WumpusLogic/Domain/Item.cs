using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public abstract class Item
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public bool CanKill { get; set; }
        public bool Winner { get; set; }
        public IList<string> Attributes { get; set; }

        public abstract string Die();
        public abstract string Kill();
        public abstract string Win();
    }
}
