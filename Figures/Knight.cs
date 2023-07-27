namespace LittleChess.Figures
{
    public class Knight : Figure
    {
        public Knight(Color color, Coordinates coordinates) : base(color, coordinates)
        {
        }

        protected override HashSet<CoordinatesShift> GetFigureMoves()
        {
            return new HashSet<CoordinatesShift>(
                new List<CoordinatesShift>
                {
                    new CoordinatesShift( 1  ,  2),
                    new CoordinatesShift( 2  ,  1),

                    new CoordinatesShift(-1  ,  2),
                    new CoordinatesShift(-2  ,  1),

                    new CoordinatesShift( 2  , -1),
                    new CoordinatesShift( 1  , -2),

                    new CoordinatesShift(-2  , -1),
                    new CoordinatesShift(-1  , -2),
                }
            );
        }
    }
}