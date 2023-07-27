using System.Collections.Generic;

namespace LittleChess.Figures
{
    public abstract class Figure
    {
        public Color Color { get; }
        public Coordinates Coordinates { get; set; }
        public Figure(Color color, Coordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public HashSet<Coordinates> GetAvailableMoves(Board board)
        {
            HashSet<Coordinates> aviableMoves = new HashSet<Coordinates>();
            foreach (CoordinatesShift shift in GetFigureMoves())
            {
                if (!Coordinates.CanShift(shift)) continue;
                var newCoordinates = Coordinates.Shift(shift);


                if (isCellAviableForMove(newCoordinates, board))
                {
                    aviableMoves.Add(newCoordinates);
                }
            }

            return aviableMoves;
        }

        private bool isCellAviableForMove(Coordinates coordinates, Board board)
        {
            return board.IsCellEmpty(coordinates) || 
                   board.GetFigureByCoordinate(coordinates).Color != Color;

                
        }

        protected abstract HashSet<CoordinatesShift> GetFigureMoves();
    }
}