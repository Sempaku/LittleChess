using LittleChess.BoardPackage;

namespace LittleChess.Figures
{
    public class Pawn : Figure
    {
        public Pawn(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            if (Color == Color.WHITE)
            {
                result.Add(new CoordinatesShift(0, 1));
                if (Coordinates.rank == 2)
                    result.Add(new CoordinatesShift(0, 2));

                result.Add(new CoordinatesShift(1, 1));
                result.Add(new CoordinatesShift(-1, 1));
            }
            else
            {
                result.Add(new CoordinatesShift(0, -1));
                if (Coordinates.rank == 7)
                    result.Add(new CoordinatesShift(0, -2));

                result.Add(new CoordinatesShift(1, -1));
                result.Add(new CoordinatesShift(-1, -1));
            }

            return result;
        }

        protected override bool isCellAviableForMove(Coordinates coordinatesTo, Board board)
        {
            if (Coordinates.file == coordinatesTo.file)
            {
                int rankShift = Math.Abs(Coordinates.rank - coordinatesTo.rank);
                if (rankShift == 2)
                {
                    var between = BoardUtils.GetVerticalCoordinatesBetween(Coordinates, coordinatesTo);
                    return board.IsCellEmpty(between[0]) && board.IsCellEmpty(coordinatesTo);
                }
                else
                {
                    return board.IsCellEmpty(coordinatesTo);
                }
            }
            else
            {
                if (board.IsCellEmpty(coordinatesTo))
                {
                    return false;
                }
                else
                {
                    return board.GetFigureByCoordinate(coordinatesTo).Color != Color;
                }
            }
        }

        protected override HashSet<CoordinatesShift> GetFigureAttacks()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            if (Color == Color.WHITE)
            {
                result.Add(new CoordinatesShift(1, 1));
                result.Add(new CoordinatesShift(-1, 1));
            }
            else
            {
                result.Add(new CoordinatesShift(1, -1));
                result.Add(new CoordinatesShift(-1, -1));
            }

            return result;
        }
    }
}