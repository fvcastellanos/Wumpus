using System;
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
        private Cave _currentCave;
        private readonly IList<string> _whereIDied;

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
            _currentCave = null;
            _whereIDied = new List<string>();
        }

        public Cave MoveToInitialCave()
        {
            _currentCave = _boardService.GetCave(_startX, _startY).Cave;
            return _currentCave;
        }

        public AgentInfo Move(Position position)
        {
            var cave = _movePosition(position);

            if (_currentCave.Equals(cave))
            {
                _info("I can't move there\n");
                return GetAgentInfo();
            }

            var info = _boardService.GetCaveInfo(cave);
            _info(info.ToString());

            if (_whereIDied.Contains(info.Name))
            {
                _info("According with my past life this cave has dead inside, so, I won't go there\n");
                MoveToInitialCave();
                return GetAgentInfo();
            }

            _analyzeCave(info);
            _showFindings(info);
            _currentCave = cave;

            return GetAgentInfo();
        }

        public AgentInfo GetAgentInfo()
        {
            return new AgentInfo(_name, _deaths, _respawns, _isAlive, _hasWon, _currentCave.Name);
        }

        public AgentInfo Respawn()
        {
            _respawns++;
            _isAlive = true;
            _info("Using a phoenix down in me! -> I'm back!!\n");
            MoveToInitialCave();
            return GetAgentInfo();
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

        private Cave _movePosition(Position position)
        {
            switch (position)
            {
                case Position.North:
                    return _moveNorth(_currentCave);
                case Position.South:
                    return _moveSouth(_currentCave);
                case Position.East:
                    return _moveEast(_currentCave);
                case Position.West:
                    return _moveWest(_currentCave);
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }

        private Cave _moveNorth(Cave cave)
        {
            return cave.NorthCave ?? cave;
        }

        private Cave _moveSouth(Cave cave)
        {
            return cave.SouthCave ?? cave;
        }

        private Cave _moveEast(Cave cave)
        {
            return cave.EastCave ?? cave;
        }

        private Cave _moveWest(Cave cave)
        {
            return cave.WestCave ?? cave;
        }

    }
}