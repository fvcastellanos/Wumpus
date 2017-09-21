using System.Collections;
using System.Collections.Generic;
using WumpusLogic.Domain;

namespace WumpusLogic.Game
{
    public class AgentService
    {
        private readonly int _startX;
        private readonly int _startY;
        private readonly BoardService _boardService;
        private readonly IList<string> _log;

        private readonly string _name;
        private int _deaths;
        private int _respawns;
        private bool _isAlive;
        private bool _hasWon;
        private IList<string> _whereIDied;

        public AgentService(string name, BoardService boardService, IList<string> log, int startX, int startY)
        {
            _boardService = boardService;
            _log = log;
            _startX = startX;
            _startY = startY;
            _name = name;
            _deaths = 0;
            _respawns = 0;
            _isAlive = true;
            _hasWon = false;
            _whereIDied = new List<string>();
        }

        public AgentInfo MoveToInitialCave()
        {
            return Move(_startX, _startY);
        }

        public AgentInfo Move(int x, int y)
        {
            if (!_boardService.CaveExists(x, y))
            {
                _info("I can't move there");
                return GetAgentInfo();
            }

            var info = _boardService.GetCaveInfo(x, y);

            if (_whereIDied.Contains(info.Name))
            {
                _info("According with my past life this cave has dead inside, so, I won't go there");
                return GetAgentInfo();
            }

            _analyzeCave(info);
            _showFindings(info);

            return GetAgentInfo();
        }

        public AgentInfo GetAgentInfo()
        {
            return new AgentInfo(_name, _deaths, _respawns, _isAlive, _hasWon);
        }

        public AgentInfo Respawn()
        {
            _respawns++;
            _isAlive = true;
            _info("Using a phoenix down in me! -> I'm back!!");
            return MoveToInitialCave();
        }

        private void _info(string message)
        {
            var name = "[" + _name + "] " + message;
            _log.Add(name);
        }

        private void _showFindings(CaveInfo info)
        {
            _info(info.ToString());
        }

        private void _analyzeCave(CaveInfo info)
        {
            if (info.CanKill)
            {
                _whereIDied.Add(info.Name);
                _isAlive = false;
                _deaths++;
                _info(info.DieMessage);
            }

            if (info.IsWinner)
            {
                _hasWon = true;
                _info(info.WinMessage);
            }
            
        }
    }
}