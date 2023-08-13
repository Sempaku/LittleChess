namespace LittleChess.Figures
{
    public class Bishop : LongRangeFigure
    {
        public Bishop(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            return IBishop.GetBishopMoves();
        }
    }
}