namespace LittleChess.BoardPackage
{
    public class Move
    {
        public Coordinates From { get; set; }
        public Coordinates To { get; set; }
        public Move(Coordinates from, Coordinates to)
        {
            From = from;
            To = to;
        }
    }
}