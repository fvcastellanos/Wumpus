using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class Wumpus : Item
    {
        public Wumpus()
        {
            Name = "Wumpus";
            CanKill = true;
            IsAlive = true;
            Winner = false;
            Attributes = new List<string>() { "Smell like rotten tomatos" };
        }

        public override string Die()
        {
            return "A terrible roaring was heard in all the caves";
        }

        public override string Kill()
        {
            return "You are the Wumpus dinner";
        }

        public override string Win()
        {
            return "You can't win with the Wumpus";
        }
    }
}