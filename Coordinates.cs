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
