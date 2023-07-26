namespace LittleChess.Figures
{
    public abstract class Figure
    {
        public Color Color { get; }
        public Coordinates Coordinates { get; set; }

        public Figure(Color color, Coordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }
    }
}
