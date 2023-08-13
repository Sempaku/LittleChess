using LittleChess.BoardPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.Figures
{
    public class LongRangeFigure : Figure
    {
        public LongRangeFigure(Color color, Coordinates coordinates)
            :base(color, coordinates) {}

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }

        protected override bool isCellAviableForMove(Coordinates coordinatesToMove, Board board)
        {
            bool result = base.isCellAviableForMove(coordinatesToMove, board);
            if (result)
            {
                return isCellAviableForAttack(coordinatesToMove, board);
            }
            else
            {
                return false;
            }
        }

        protected override bool isCellAviableForAttack(Coordinates shiftedCoordinates, Board board)
        {
            //1. get cells between current pos and target pos
            List<Coordinates> aviableCells;
            if (this.Coordinates.file == shiftedCoordinates.file)
            {
                aviableCells = BoardUtils.GetVerticalCoordinatesBetween(this.Coordinates, shiftedCoordinates);
            }
            else if (this.Coordinates.rank == shiftedCoordinates.rank)
            {
                aviableCells = BoardUtils.GetHorizontalCoordinatesBetween(this.Coordinates, shiftedCoordinates);
            }
            else
            {
                aviableCells = BoardUtils.GetDiagonalCoordinatesBetween(this.Coordinates, shiftedCoordinates);
            }

            //2. check that cell is free
            foreach (Coordinates c in aviableCells)
            {
                if (!board.IsCellEmpty(c))
                    return false;
            }
            return true;
        }
    }
}
