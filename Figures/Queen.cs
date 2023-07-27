namespace LittleChess.Figures
{
    public class Queen : Figure
    {
        public Queen(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }
    }
}
