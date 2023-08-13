using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.Figures
{
    public interface IRook
    {
        static HashSet<CoordinatesShift> GetRookMoves()
        {
            return new HashSet<CoordinatesShift>(
                new List<CoordinatesShift>
                {
                    // up
                    new CoordinatesShift( 0  ,  1),
                    new CoordinatesShift( 0  ,  2),
                    new CoordinatesShift( 0  ,  3),
                    new CoordinatesShift( 0  ,  4),
                    new CoordinatesShift( 0  ,  5),
                    new CoordinatesShift( 0  ,  6),
                    new CoordinatesShift( 0  ,  7),

                    // down
                    new CoordinatesShift( 0  ,  -1),
                    new CoordinatesShift( 0  ,  -2),
                    new CoordinatesShift( 0  ,  -3),
                    new CoordinatesShift( 0  ,  -4),
                    new CoordinatesShift( 0  ,  -5),
                    new CoordinatesShift( 0  ,  -6),
                    new CoordinatesShift( 0  ,  -7),

                    // left
                    new CoordinatesShift( 1  , 0),
                    new CoordinatesShift( 2  , 0),
                    new CoordinatesShift( 3  , 0),
                    new CoordinatesShift( 4  , 0),
                    new CoordinatesShift( 5  , 0),
                    new CoordinatesShift( 6  , 0),
                    new CoordinatesShift( 7  , 0),

                    //right
                    new CoordinatesShift( -1  , 0),
                    new CoordinatesShift( -2  , 0),
                    new CoordinatesShift( -3  , 0),
                    new CoordinatesShift( -4  , 0),
                    new CoordinatesShift( -5  , 0),
                    new CoordinatesShift( -6  , 0),
                    new CoordinatesShift( -7  , 0),
                }
            );
        }
    }
}
