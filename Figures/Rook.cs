using LittleChess.Utils;

namespace LittleChess.Figures
{
    public class Rook : LongRangeFigure
    {
        public Rook(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            return IRook.GetRookMoves();
        }
    }
}
