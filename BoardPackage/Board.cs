using LittleChess.Figures;

namespace LittleChess.BoardPackage
{
    public class Board
    {
        public string StartFen { get; }
        public List<Move> moveHistiry = new List<Move>();

        public Board(string startFen)
        {
            StartFen = startFen;
        }

        public Dictionary<Coordinates, Figure> FiguresOnBoard { get; } =
            new Dictionary<Coordinates, Figure>();

        // TODO: убрать координаты, можнои  брать из фигуры
        public void SetFigure(Coordinates coordinates, Figure figure)
        {
            figure.Coordinates = coordinates;
            RemoveFigure(coordinates);
            FiguresOnBoard.Add(coordinates, figure);
        }

        public void RemoveFigure(Coordinates coordinates)
        {
            FiguresOnBoard.Remove(coordinates);
        }

        // TODO : можно убрать coordFrom, и парсить ее из фигуры
        public void MakeMove(Move moveCoordinates)
        {
            Figure figure = GetFigureByCoordinate(moveCoordinates.From);
            RemoveFigure(moveCoordinates.From);
            SetFigure(moveCoordinates.To, figure);

            moveHistiry.Add(moveCoordinates);
        }

        public static bool IsDarkCell(Coordinates coordinates)
        {
            return ((int)coordinates.file + coordinates.rank - 1) % 2 == 0
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

        public IEnumerable<Figure> GetFiguresByColor(Color color)
        {
            return FiguresOnBoard.Values.Where(f => f.Color == color);
        }

        internal bool IsCellUnderAttackByColor(Coordinates coordinates, Color color)
        {
            var figures = GetFiguresByColor(color);

            foreach (Figure figure in figures)
            {
                HashSet<Coordinates> attackedCells = figure.GetAttackedCells(this);

                if (attackedCells.Contains(coordinates))
                {
                    return true;
                }
            }

            return false;
        }
    }
}