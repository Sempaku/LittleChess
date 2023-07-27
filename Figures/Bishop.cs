namespace LittleChess.Figures
{
    public class Bishop : Figure
    {
        public Bishop(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }
        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }
    }
}
