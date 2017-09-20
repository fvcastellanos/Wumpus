namespace WumpusLogic.Domain
{
    public class Container
    {
        public Cave Cave { get; set; }
        public bool DeadInside { get; set; }

        public Container(Cave cave, bool deadInside)
        {
            this.Cave = cave;
            this.DeadInside = deadInside;
        }
    }
}
