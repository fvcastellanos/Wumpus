using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class CaveInfo
    {
        public string Name { get; }
        public IEnumerable<string> Attributes { get; }
        public bool CanKill { get; }
        public bool IsWinner { get; }

        public CaveInfo(string name, IEnumerable<string> attributes, bool canKill, bool isWinner)
        {
            Name = name;
            Attributes = attributes;
            CanKill = canKill;
            IsWinner = isWinner;
        }
    }
}
