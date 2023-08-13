using LittleChess.BoardPackage;
using LittleChess.GameStates;

namespace LittleChess
{
    internal class GameLogic
    {
        private readonly Board _board;
        private readonly ConsoleBoardRenderer _boardRenderer;
        private readonly ConsoleInputParser _inputParser;

        private readonly List<GameStateChecker> _gameStateCheckers = new List<GameStateChecker>
        {
            new StalemateGameStateChecker(),
            new CheckmateGameStateChecker()
        };

        private GameState _gameState;

        public GameLogic(Board board)
        {
            _board = board;
            _boardRenderer = new ConsoleBoardRenderer();
            _inputParser = new ConsoleInputParser();
        }

        public void StartGame()
        {
            Color whoseMove = Color.WHITE;
            _gameState = CheckGameState(_board, whoseMove);
            while (_gameState == GameState.GAME_IS_ON)
            {
                // render
                _boardRenderer.Render(_board);
                // input
                Move moveCoords = ConsoleInputParser.InputMove(_board, whoseMove, _boardRenderer);
                // make move
                _board.MakeMove(moveCoords);
                // pass move

                whoseMove = (whoseMove is Color.WHITE) ? Color.BLACK : Color.WHITE;

                _gameState = CheckGameState(_board, whoseMove);
            }
            _boardRenderer.Render(_board);
            Console.WriteLine($"Game ended with state: {_gameState}");
        }

        private GameState CheckGameState(Board board, Color whoseMove)
        {
            foreach (var checker in _gameStateCheckers)
            {
                GameState state = checker.Check(_board, whoseMove);

                if (state != GameState.GAME_IS_ON)
                {
                    return state;
                }
            }
            return GameState.GAME_IS_ON;
        }
    }
}