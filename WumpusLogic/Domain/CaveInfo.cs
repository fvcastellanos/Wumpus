using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class CaveInfo
    {
        public string Name { get; }
        public IEnumerable<string> Attributes { get; }
        public bool CanKill { get; }
        public bool IsWinner { get; }
        public string DieMessage { get; }
        public string WinMessage { get; }

        public CaveInfo(string name, IEnumerable<string> attributes, bool canKill, bool isWinner, string dieMessage, string winMessage)
        {
            Name = name;
            Attributes = attributes;
            CanKill = canKill;
            IsWinner = isWinner;
            DieMessage = dieMessage;
            WinMessage = winMessage;
        }

        public override string ToString()
        {
            return "Cave: " + Name + "\n" + _attributesToString();
        }

        private string _attributesToString()
        {
            var st = "";
            foreach (var attribute in Attributes)
            {
                st += "- " + attribute + "\n";
            }

            return st;
        }
    }
}
