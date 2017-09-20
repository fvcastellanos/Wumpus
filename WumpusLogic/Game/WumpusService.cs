using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusLogic.Domain;

namespace WumpusLogic.Game
{
    public class WumpusService
    {
        private int rows;
        private int cols;
        private Container[ , ] _board;


        public WumpusService(int x, int y)
        {
            rows = x;
            cols = y;
            _board = new Container[rows, cols];
        }

        public void prepareBoard()
        {
            _fillBoardWithCaves();
            _interconnectCaves();
        }

        private void _fillBoardWithCaves()
        {
            for (int i=0; i < rows; i++)
                for (int j=0; j < cols; j++)
                {
                    string name = "Cave[" + i.ToString() + ", " + j.ToString() + "]";
                    _board[i, j] = new Container(new Cave(name), false);
                }

        }

        private void _interconnectCaves()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    // Nort cave
                    if (i > 0)
                        _board[i, j].Cave.NorthCave = _board[i - 1, j].Cave;

                    // East cave
                    if (j < (cols - 1))
                        _board[i, j].Cave.EastCave = _board[i, j + 1].Cave;

                    // South cave
                    if (i < (rows - 1))
                        _board[i, j].Cave.SouthCave = _board[i + 1, j].Cave;

                    // West cave
                    if (j > 0)
                        _board[i, j].Cave.WestCave = _board[i, j - 1].Cave;
                }
        }
    }
}
