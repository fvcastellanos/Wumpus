using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WumpusLogic.Domain;
using WumpusLogic.Game;

namespace Wumpus
{
    public partial class MainForm : Form
    {
        private GameService _gameService;
        private readonly IList<string> _agents;
        private readonly string _playerOne;
        private readonly string _playerTwo;
        private int _currentTurn;
        private readonly IDictionary<string, PictureBox> _pictureBoxes;
        private IDictionary<string, AgentInfo> _currentInfo;

        private string _lastAgent;
        private string _lastCave;

        public MainForm()
        {
            InitializeComponent();
            _playerOne = "Indiana Jones";
            _playerTwo = "Lara Croft";
            _agents = new List<string>() { _playerOne, _playerTwo };
            _pictureBoxes = new Dictionary<string, PictureBox>();
            _currentInfo = new Dictionary<string, AgentInfo>();

        }

        private string _getNextTurn()
        {
            var agent = _agents[_currentTurn];

            _currentTurn++;
            if (_currentTurn == _agents.Count)
            {
                _currentTurn = 0;
            }

            return agent;
        }

        private void _stopGame()
        {
            tmTurns.Stop();
            _gameService.Reset();
        }

        private void _initGame()
        {
            _gameService = new GameService(_agents);
            _gameService.InitGame();
            _currentTurn = 0;
        }

        private void _moveToInitialPosition()
        {
            _currentInfo[_playerOne] = _gameService.MoveToInitialCave(_playerOne);
            _displayActiveCave(_playerOne, _currentInfo[_playerOne].CaveName);

            _currentInfo[_playerTwo] = _gameService.MoveToInitialCave(_playerTwo);
            _displayActiveCave(_playerTwo, _currentInfo[_playerTwo].CaveName);
        }

        private void _displayActiveCave(string name, string caveName)
        {
            var color = _playerOne.Equals(name) ? Color.Bisque : Color.BlueViolet;
            _pictureBoxes[caveName].BackColor = color ;
        }

        private void _clearLastPictureBox(string name)
        {
            var info = _playerOne.Equals(name) ? _currentInfo[_playerOne] : _currentInfo[_playerTwo];
            _pictureBoxes[info.CaveName].BackColor = TransparencyKey;
        }

        private void _moveAndEvaluate()
        {
            var agent = _getNextTurn();
            _clearLastPictureBox(agent);
            var agentInfo = _gameService.MoveAgent(agent);
            _currentInfo[agent] = agentInfo;
            _displayActiveCave(agent, agentInfo.CaveName);
            _evaluate(agent, agentInfo);
        }

        private void _evaluate(string name, AgentInfo info)
        {
            var log = _gameService.GetAgentLog(name);
            _displayAgentLog(name, log);

            if (!info.IsAlive)
            {
                _gameService.Respawn(name);
            }

            if (info.HasWon)
            {
                _stopGame();
                MessageBox.Show("Player: " + name + " is the winner!");
            }
        }

        private void _displayAgentLog(string name, IEnumerable<string> entries)
        {
            var log = name.Equals(_playerOne) ? playerOneLog : playerTwoLog;

            log.Clear();

            foreach (var entry in entries)
            {
                log.AppendText(entry);
            }
        }

        private Image _getImageResource(Item item)
        {
            if (item == null) return Properties.Resources.cave;

            if (item.Name.Equals("Wumpus")) return Properties.Resources.wumpus;

            if (item.Name.Equals("Gold Bar")) return Properties.Resources.gold;

            return item.Name.Equals("Bottomless Pit") ? Properties.Resources.pit : null;
        }

        private void _fillImageTable()
        {
            var board = _gameService.GetBoard();
            imageTable.Controls.Clear();

            for (var x = 0; x < 6; x++)
            for (var y = 0; y < 6; y++)
            {
                var image = new PictureBox() {Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.StretchImage};
                var item = board[x, y].Cave.CaveItem;
                image.Image = _getImageResource(item);
                image.Name = board[x, y].Cave.Name;
                _pictureBoxes[image.Name] = image;
                imageTable.Controls.Add(image);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            _initGame();
            _fillImageTable();
            _moveToInitialPosition();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stopGame();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _moveAndEvaluate();
            tmTurns.Start();   
        }

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            _moveAndEvaluate();
        }

        private void tmTurns_Tick(object sender, EventArgs e)
        {
            _moveAndEvaluate();
        }
    }
}
