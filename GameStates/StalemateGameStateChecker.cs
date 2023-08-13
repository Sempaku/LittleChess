using LittleChess.BoardPackage;

namespace LittleChess.GameStates
{
    public class StalemateGameStateChecker : GameStateChecker
    {
        public override GameState Check(Board board, Color color)
        {
            var figures = board.GetFiguresByColor(color);
            foreach (var figure in figures)
            {
                HashSet<Coordinates> figureAviableMoves = figure.GetAvailableMoves(board);
                if (figureAviableMoves.Count > 0)
                {
                    return GameState.GAME_IS_ON;
                }
            }

            return GameState.STALEMATE;
        }
    }
}