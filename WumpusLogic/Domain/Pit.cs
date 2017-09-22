using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class Pit : Item
    {
        public Pit()
        {
            Name = "Bottomless Pit";
            CanKill = true;
            IsAlive = false;
            Winner = false;
            Attributes = new List<string> { "Breeze" };
        }

        public override string Die()
        {
            return "A pit can't die\n";
        }

        public override string Kill()
        {
            return "Keep falling until the end of times\n";
        }

        public override string Win()
        {
            return "You can't win while falling forever\n";
        }
    }
}
