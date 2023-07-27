namespace LittleChess
{
    public class CoordinatesShift
    {
        public int FileShift { get; }
        public int RankShift { get; }

        public CoordinatesShift(int fileShift, int rankShift)
        {
            FileShift = fileShift;
            RankShift = rankShift;
        }
    }
}