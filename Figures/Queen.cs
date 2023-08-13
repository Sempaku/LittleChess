namespace LittleChess.Figures
{
    public class Queen : LongRangeFigure
    {
        public Queen(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            var moves = IBishop.GetBishopMoves();
            foreach (var item in IRook.GetRookMoves())
            {
                moves.Add(item);
            }
            return moves;
        }
    }
}