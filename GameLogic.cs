namespace LittleChess
{
    internal class GameLogic
    {
        private Board _board;
        private ConsoleBoardRenderer _boardRenderer;
        private ConsoleInputParser _inputParser;
        public GameLogic(Board board)
        {
            _board = board;
            _boardRenderer = new ConsoleBoardRenderer();
            _inputParser = new ConsoleInputParser();
        }

        public void StartGame()
        {
            bool isWhiteMove = true;

            while (true)
            {
                // render
                // input
                var coorinates = _inputParser.Input();
                // make move
                // pass move
            }
        }
    }
}
