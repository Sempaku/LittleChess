namespace LittleChess.Figures
{
    public interface IBishop
    {
        static HashSet<CoordinatesShift> GetBishopMoves()
        {
            return new HashSet<CoordinatesShift>(
                new List<CoordinatesShift>
                {
                    // top-right
                    new CoordinatesShift( 1  , 1),
                    new CoordinatesShift( 2  , 2),
                    new CoordinatesShift( 3  , 3),
                    new CoordinatesShift( 4  , 4),
                    new CoordinatesShift( 5  , 5),
                    new CoordinatesShift( 6  , 6),
                    new CoordinatesShift( 7  , 7),

                    // top-left
                    new CoordinatesShift( -1  , 1),
                    new CoordinatesShift( -2  , 2),
                    new CoordinatesShift( -3  , 3),
                    new CoordinatesShift( -4  , 4),
                    new CoordinatesShift( -5  , 5),
                    new CoordinatesShift( -6  , 6),
                    new CoordinatesShift( -7  , 7),

                    // down-right
                    new CoordinatesShift( 1  , -1),
                    new CoordinatesShift( 2  , -2),
                    new CoordinatesShift( 3  , -3),
                    new CoordinatesShift( 4  , -4),
                    new CoordinatesShift( 5  , -5),
                    new CoordinatesShift( 6  , -6),
                    new CoordinatesShift( 7  , -7),

                    // down-left
                    new CoordinatesShift( -1  , -1),
                    new CoordinatesShift( -2  , -2),
                    new CoordinatesShift( -3  , -3),
                    new CoordinatesShift( -4  , -4),
                    new CoordinatesShift( -5  , -5),
                    new CoordinatesShift( -6  , -6),
                    new CoordinatesShift( -7  , -7),
                }
            );
        }
    }
}