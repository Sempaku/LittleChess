using LittleChess.BoardPackage;

namespace LittleChess.Figures
{
    public class King : Figure
    {
        public King(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }
        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            return new HashSet<CoordinatesShift>()
            {
                new CoordinatesShift(1,1),
                new CoordinatesShift(1, -1),
                new CoordinatesShift(-1, 1),
                new CoordinatesShift(1,0),
                new CoordinatesShift(0,1),
                new CoordinatesShift(-1,0),
                new CoordinatesShift(0,-1),
                new CoordinatesShift(-1,-1)
            };

        }

        protected override bool isCellAviableForMove(Coordinates coordinates, Board board)
        {
            bool baseLogic = base.isCellAviableForMove(coordinates, board);
            
            if (baseLogic)
            {
                return !board.IsCellUnderAttackByColor(coordinates, (Color == Color.BLACK) ? Color.WHITE : Color.BLACK);
            }

            return false;
        }
    }
}
