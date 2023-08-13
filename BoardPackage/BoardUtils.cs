namespace LittleChess.BoardPackage
{
    public class BoardUtils
    {
        public static List<Coordinates> GetDiagonalCoordinatesBetween(Coordinates from, Coordinates to)
        {
            // допущение - to лежит на одной диагонали с from

            List<Coordinates> result = new List<Coordinates>();

            int fileShift = from.file < to.file ? 1 : -1;
            int rankShift = from.rank < to.rank ? 1 : -1;

            for (
                 int fileIndex = (int)from.file + fileShift, rankIndex = from.rank + rankShift;
                 fileIndex != (int)to.file && rankIndex != to.rank;
                 fileIndex += fileShift, rankIndex += rankShift
                 )
            {
                result.Add(new Coordinates((File)fileIndex, rankIndex));
            }

            return result;
        }

        public static List<Coordinates> GetVerticalCoordinatesBetween(Coordinates from, Coordinates to)
        {
            // допущение - to лежит на одной вертикали с from

            List<Coordinates> result = new List<Coordinates>();

            int rankShift = from.rank < to.rank ? 1 : -1;

            for (int rankIndex = from.rank + rankShift; rankIndex != to.rank; rankIndex += rankShift)
            {
                result.Add(new Coordinates(from.file, rankIndex));
            }

            return result;
        }

        public static List<Coordinates> GetHorizontalCoordinatesBetween(Coordinates from, Coordinates to)
        {
            // допущение - to лежит на одной горизонтали с from

            List<Coordinates> result = new List<Coordinates>();

            int fileShift = from.file < to.file ? 1 : -1;

            for (int fileIndex = (int)from.file + fileShift; fileIndex != (int)to.file; fileIndex += fileShift)
            {
                result.Add(new Coordinates((File)fileIndex, from.rank));
            }

            return result;
        }
    }
}