using System;
using System.Collections.Generic;
using WumpusLogic.Domain;

namespace WumpusLogic.Game
{
    public class GameService
    {
        private const int X = 6;
        private const int Y = 6;

        private readonly BoardService _boardService;
        private IDictionary<string, AgentService> _agents;
        private readonly IDictionary<string, List<string>> _logDictionary;
        private readonly Random _random;

        public GameService(IEnumerable<string> agentsNames)
        {
            _boardService = new BoardService(X, Y);
            _logDictionary = new Dictionary<string, List<string>>();
            _buildAgents(_boardService, agentsNames);
            _random = new Random();
        }

        public void InitGame()
        {
            _boardService.PrepareBoard();
            _boardService.AddItems(_buildItemList());
            _boardService.FillCaveAttributes();

            foreach (var key in _agents.Keys)
            {
                _agents[key].MoveToInitialCave();
            }
        }

        public AgentInfo MoveToInitialCave(string name)
        {
            _agents[name].MoveToInitialCave();
            return _agents[name].GetAgentInfo();
        }

        public AgentInfo Respawn(string name)
        {
            return _agents[name].Respawn();
        }

        public void Reset()
        {
            _boardService.ResetBoard();
            InitGame();
        }

        public AgentInfo MoveAgent(string name)
        {
            var position = _getPosition();
            var message = "[" + name + "] moving: " + position + "\n";
            _logDictionary[name].Add(message);
            return _agents[name].Move(position);
        }

        public IList<string> GetAgentLog(string name)
        {
            return _logDictionary[name];
        }

        public Container[,] GetBoard()
        {
            return _boardService.GetContainers();
        }

        private void _buildAgents(BoardService boardService, IEnumerable<string> agentsNames)
        {
            _agents = new Dictionary<string, AgentService>();

            foreach (var name in agentsNames)
            {
                _logDictionary[name] = new List<string>();
                _agents[name] = new AgentService(name, boardService, _logDictionary[name], 0, 0);
            }
        }

        private IEnumerable<Item> _buildItemList()
        {
            var itemList = new List<Item> { new Wumpus(), new Gold(), new Pit(), new Pit(), new Pit() };

            return itemList;
        }

        private Position _getPosition()
        {
            var position = _random.Next(1, 4);

            switch (position)
            {
                case 1:
                    return Position.North;
                case 2:
                    return Position.South;
                case 3:
                    return Position.East;
                case 4:
                    return Position.West;
                default:
                    return Position.North;
            }
        }

    }
}