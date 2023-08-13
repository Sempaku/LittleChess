using LittleChess.BoardPackage;
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

        protected virtual bool isCellAviableForMove(Coordinates coordinates, Board board)
        {
            return board.IsCellEmpty(coordinates) || 
                   board.GetFigureByCoordinate(coordinates).Color != Color;                
        }

        protected abstract HashSet<CoordinatesShift> GetFigureMoves();
        protected virtual HashSet<CoordinatesShift> GetFigureAttacks()
        {
            return GetFigureMoves();
        }
        
        internal HashSet<Coordinates> GetAttackedCells(Board board)
        {
            HashSet<CoordinatesShift> figureAttacksShifts =  GetFigureAttacks();
            HashSet<Coordinates> result = new HashSet<Coordinates>();

            foreach (var figureAttackShift in figureAttacksShifts)
            {
                if (Coordinates.CanShift(figureAttackShift))
                {
                    Coordinates shiftedCoordinates = Coordinates.Shift(figureAttackShift);

                    if (isCellAviableForAttack(shiftedCoordinates, board))
                    {
                        result.Add(shiftedCoordinates);
                    }
                }
            }

            return result;
        }

        protected virtual bool isCellAviableForAttack(Coordinates shiftedCoordinates, Board board)
        {
            return true;
        }
    }
}