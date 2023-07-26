using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    public class Board
    {
        Dictionary<Coordinates, Figure> figuresOnBoard = new Dictionary<Coordinates, Figure>();

        public void SetFigure(Figure figure, Coordinates coordinates)
        {
            figure.Coordinates = coordinates;
            figuresOnBoard.Add(coordinates, figure);
        }

        public void InitFiguresOnBoard()
        {

        }
    }
}
