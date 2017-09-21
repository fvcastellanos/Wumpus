namespace WumpusLogic.Domain
{
    public class AgentInfo
    {
        public string Name { get; }
        public int Deaths { get; }
        public int Respawns { get; }
        public bool IsAlive { get; }
        public bool HasWon { get; }

        public AgentInfo(string name, int deaths, int respawns, bool isAlive, bool hasWon)
        {
            Name = name;
            Deaths = deaths;
            Respawns = respawns;
            IsAlive = isAlive;
            HasWon = hasWon;
        }

    }
}