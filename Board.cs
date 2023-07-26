using LittleChess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    public class Board
    {
        public static Dictionary<Coordinates, Figure> FiguresOnBoard { get; } = new Dictionary<Coordinates, Figure>();

        public void SetFigure(Coordinates coordinates, Figure figure)
        {
            figure.Coordinates = coordinates;
            FiguresOnBoard.Add(coordinates, figure);
        }

        public void InitFiguresOnBoard()
        {
            foreach (File file in Enum.GetValues(typeof(File)))
            {
                SetFigure(new Coordinates(file, 2), new Pawn(Color.WHITE, new Coordinates(file, 2)));
                SetFigure(new Coordinates(file, 7), new Pawn(Color.BLACK, new Coordinates(file, 7)));
            }
        }

        public static bool IsDarkCell(Coordinates coordinates)
        {
            return (((int)coordinates.file + coordinates.rank - 1) % 2 == 0) 
                ? true 
                : false;
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            return !FiguresOnBoard.ContainsKey(coordinates);
        }

        public static Figure GetFigureByCoordinate(Coordinates coordinates)
        {
            return FiguresOnBoard[coordinates];
        }
    }
}
