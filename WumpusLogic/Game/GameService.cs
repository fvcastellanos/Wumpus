namespace WumpusLogic.Game
{
    public class GameService
    {
        private BoardService _boardService;

        public GameService(BoardService boardService)
        {
            _boardService = boardService;
        }
    }
}