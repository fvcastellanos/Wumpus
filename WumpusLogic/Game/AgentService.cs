using System.Collections;
using System.Collections.Generic;

namespace WumpusLogic.Game
{
    public class AgentService
    {
        private int _startX;
        private int _startY;
        private BoardService _boardService;
        private IList<string> _log;

        public string Name { get; }

        public AgentService(string name, BoardService boardService, IList<string> log, int startX, int startY)
        {
            _boardService = boardService;
            _log = log;
            _startX = startX;
            _startY = startY;
            Name = name;
        }

        public void Move(int x, int y)
        {
            if (!_boardService.CaveExists(x, y))
            {
                _log.Add("Can't move there");
            }


        }
    }
}