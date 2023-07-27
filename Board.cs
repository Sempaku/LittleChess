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
        public static Dictionary<Coordinates, Figure> FiguresOnBoard { get; } = 
            new Dictionary<Coordinates, Figure>();

        // TODO: убрать координаты, можнои  брать из фигуры
        private void SetFigure(Coordinates coordinates, Figure figure)
        {
            figure.Coordinates = coordinates;
            FiguresOnBoard.Add(coordinates, figure);
        }

        public void RemoveFigure(Coordinates coordinates)
        {
            FiguresOnBoard.Remove(coordinates);
        }

        // TODO : можно убрать coordFrom, и парсить ее из фигуры
        public void MoveFigure(Coordinates coordinatesFrom, Coordinates coordinatesTo)
        {
            Figure figure = GetFigureByCoordinate(coordinatesFrom);
            RemoveFigure(coordinatesFrom);
            SetFigure(coordinatesTo, figure);
        }

        public void InitFiguresOnBoard()
        {
            // установка пешек
            foreach (File file in Enum.GetValues(typeof(File)))
            {
                SetFigure(new Coordinates(file, 2), new Pawn(Color.WHITE, new Coordinates(file, 2)));
                SetFigure(new Coordinates(file, 7), new Pawn(Color.BLACK, new Coordinates(file, 7)));
            }
            
            // установка ладей
            SetFigure(new Coordinates(File.A,1), new Rook(Color.WHITE, new Coordinates(File.A, 1)));
            SetFigure(new Coordinates(File.H,1), new Rook(Color.WHITE, new Coordinates(File.H, 1)));
            SetFigure(new Coordinates(File.A,8), new Rook(Color.BLACK, new Coordinates(File.A, 8)));
            SetFigure(new Coordinates(File.H,8), new Rook(Color.BLACK, new Coordinates(File.H, 8)));

            // установка коней
            SetFigure(new Coordinates(File.B, 1), new Knight(Color.WHITE, new Coordinates(File.B, 1)));
            SetFigure(new Coordinates(File.G, 1), new Knight(Color.WHITE, new Coordinates(File.G, 1)));
            SetFigure(new Coordinates(File.B, 8), new Knight(Color.BLACK, new Coordinates(File.B, 8)));
            SetFigure(new Coordinates(File.G, 8), new Knight(Color.BLACK, new Coordinates(File.G, 8)));

            // установка слонов
            SetFigure(new Coordinates(File.C, 1), new Bishop(Color.WHITE, new Coordinates(File.C, 1)));
            SetFigure(new Coordinates(File.F, 1), new Bishop(Color.WHITE, new Coordinates(File.F, 1)));
            SetFigure(new Coordinates(File.F, 8), new Bishop(Color.BLACK, new Coordinates(File.F, 8)));
            SetFigure(new Coordinates(File.C, 8), new Bishop(Color.BLACK, new Coordinates(File.C, 8)));

            // установка ферзей
            SetFigure(new Coordinates(File.D,1), new Queen(Color.WHITE, new Coordinates(File.D,1)));
            SetFigure(new Coordinates(File.D,8), new Queen(Color.BLACK, new Coordinates(File.D,8)));

            // установка королей
            SetFigure(new Coordinates(File.E,1), new King(Color.WHITE, new Coordinates(File.E,1)));
            SetFigure(new Coordinates(File.E,8), new King(Color.BLACK, new Coordinates(File.E, 8)));

        }

        public static bool IsDarkCell(Coordinates coordinates)
        {
            return (((int)coordinates.file + coordinates.rank - 1) % 2 == 0) 
                ? false // четные черные 
                : true; 
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            return !FiguresOnBoard.ContainsKey(coordinates);
        }

        public Figure GetFigureByCoordinate(Coordinates coordinates)
        {
            return FiguresOnBoard[coordinates];
        }
    }
}
