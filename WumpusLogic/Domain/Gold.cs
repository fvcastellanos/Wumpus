using System.Collections.Generic;

namespace WumpusLogic.Domain
{
    public class Gold : Item
    {
        public Gold()
        {
            Name = "Gold Bar";
            IsAlive = false;
            CanKill = false;
            Winner = true;
            Attributes = new List<string>() { "The shining!" };
        }

        public override string Die()
        {
            return "Gold can't die";
        }

        public override string Kill()
        {
            return "Gold can't kill you";
        }

        public override string Win()
        {
            return "You found the gold, you have win!";
        }
    }
}