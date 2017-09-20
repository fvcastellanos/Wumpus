using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class Cave
    {
        public string Name { get; set; }
        public Item CaveItem { get; set; }
        public IList<string> Attributes { get; set; }
        public Cave NorthCave { get; set; }
        public Cave SouthCave { get; set; }
        public Cave EastCave { get; set; }
        public Cave WestCave { get; set; }

        public Cave(string name)
        {
            Name = name;
            Attributes = new List<string>();
        }

/*        public Cave(string name, Cave northCave, Cave southCave, Cave eastCave, Cave westCave)
        {
            Name = name;
            NorthCave = northCave;
            SouthCave = southCave;
            EastCave = eastCave;
            WestCave = westCave;
            Attributes = new List<string>();
        }
        */

        public void SetCaveItem(Item item)
        {
            CaveItem = item;
            _propagateItemAttributes(item.Attributes);
        }

        private void _propagateItemAttributes(IList<string> attributes)
        {
            _assignItemAttributes(NorthCave, attributes);
            _assignItemAttributes(SouthCave, attributes);
            _assignItemAttributes(EastCave, attributes);
            _assignItemAttributes(WestCave, attributes);
        }

        private void _assignItemAttributes(Cave cave, IEnumerable<string> attributes)
        {
            if (cave == null) return;

            foreach (var attribute in attributes)
            {
                cave.Attributes.Add(attribute);
            }
        }
    }
}
