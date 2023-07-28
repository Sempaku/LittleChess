using LittleChess.Figures;

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
            Color whoseMove = Color.WHITE;

            while (true)
            {
                // render
                _boardRenderer.Render(_board);
                // input
                Coordinates coordsFrom = _inputParser.InputFigureCoordinatesByColor(whoseMove, _board);
                Figure figure = _board.GetFigureByCoordinate(coordsFrom);
                Coordinates coordsTo = _inputParser.inputAviableMove(figure, _board);
                // make move
                _board.MoveFigure(coordsFrom, coordsTo);
                // pass move

                whoseMove = (whoseMove is Color.WHITE) ? Color.BLACK : Color.WHITE;
            }
        }
    }
}
