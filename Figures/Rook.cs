namespace LittleChess.Figures
{
    public class Rook : Figure
    {
        public Rook(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }
    }
}
