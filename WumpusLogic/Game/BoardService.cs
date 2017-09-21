using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WumpusLogic.Domain;

namespace WumpusLogic.Game
{
    public class BoardService
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly Container[ , ] _board;

        public BoardService(int x, int y)
        {
            _rows = x;
            _cols = y;
            _board = new Container[_rows, _cols];
        }

        public void PrepareBoard()
        {
            _fillBoardWithCaves();
            _interconnectCaves();
        }

        public void AddItems(IEnumerable<Item> items)
        {
            var rnd = new Random();
            foreach (var item in items)
            {
                var success = false;
                var x = rnd.Next(0, _rows - 1);
                var y = rnd.Next(0, _cols - 1);
                var thingItem = _board[x, y].Cave.CaveItem;

                while (!success)
                {
                    if (thingItem != null) continue;
                    thingItem = item;
                    success = true;
                }
            }
        }

        public void FillCaveAttributes()
        {
            for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _cols; j++)
            {
                var cave = _board[i, j].Cave;
                if (cave.NorthCave != null)
                    _addAtributesToCave(cave, cave.NorthCave);

                if (cave.SouthCave != null)
                    _addAtributesToCave(cave, cave.SouthCave);

                if (cave.EastCave != null)
                    _addAtributesToCave(cave, cave.EastCave);

                if (cave.WestCave != null)
                    _addAtributesToCave(cave, cave.WestCave);
            }
        }

        public CaveInfo GetCaveInfo(int x, int y)
        {
            var container = _board[x, y];
            var cave = container.Cave;
            var item = cave.CaveItem;

            return new CaveInfo(cave.Name, cave.Attributes, item?.CanKill ?? false, item?.Winner ?? false);
        }

        public bool DeadInside(int x, int y)
        {
            return _board[x, y].DeadInside;
        }

        public void MarkAsDeadInside(int x, int y)
        {
            _board[x, y].DeadInside = true;
        }

        public bool CaveExists(int x, int y)
        {
            if ((x < 0) || (x >= _rows))
                return false;

            if ((y < 0) || (y >= _cols))
                return false;

            return true;
        }

        private void _fillBoardWithCaves()
        {
            for (var i=0; i < _rows; i++)
                for (var j=0; j < _cols; j++)
                {
                    var name = "Cave[" + i + ", " + j + "]";
                    _board[i, j] = new Container(new Cave(name), false);
                }

        }

        private void _interconnectCaves()
        {
            for (var i = 0; i < _rows; i++)
                for (var j = 0; j < _cols; j++)
                {
                    // Nort cave
                    if (i > 0)
                        _board[i, j].Cave.NorthCave = _board[i - 1, j].Cave;

                    // East cave
                    if (j < (_cols - 1))
                        _board[i, j].Cave.EastCave = _board[i, j + 1].Cave;

                    // South cave
                    if (i < (_rows - 1))
                        _board[i, j].Cave.SouthCave = _board[i + 1, j].Cave;

                    // West cave
                    if (j > 0)
                        _board[i, j].Cave.WestCave = _board[i, j - 1].Cave;
                }
        }

        private void _addAtributesToCave(Cave target, Cave source)
        {
            if (source.CaveItem == null)
                return;

            var attributes = from item in source.CaveItem.Attributes
                             where !target.Attributes.Contains(item)
                             select item;

            foreach (var item in attributes)
            {
                target.Attributes.Add(item);
            }
        }

    }
}
