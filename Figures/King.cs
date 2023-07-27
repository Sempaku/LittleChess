namespace LittleChess.Figures
{
    public class King : Figure
    {
        public King(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }
        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }
    }
}
