namespace LittleChess.Figures
{
    public class Pawn : Figure
    {
        public Pawn(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }
        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            throw new NotImplementedException();
        }
    }
}
