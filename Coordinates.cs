namespace LittleChess
{
    public struct Coordinates
    {
        public readonly File file;
        public readonly int rank;

        public Coordinates(File file, int rank)
        {
            this.file = file;
            this.rank = rank;
        }

        public bool CanShift(CoordinatesShift shift)
        {
            int f = (int)file + shift.FileShift;
            int r = rank + shift.RankShift;

            if (((f < 1) || (f > 8)) || ((r < 1) || (r > 8)))          
                return false;

            return true;
        }
        public Coordinates Shift(CoordinatesShift shift)
        {
            return new Coordinates(file + shift.FileShift, rank + shift.RankShift);
        }

        public override bool Equals(object? obj)
        {
            return obj is Coordinates coordinates &&
                   file == coordinates.file &&
                   rank == coordinates.rank;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(file, rank);
        }
    }
}
