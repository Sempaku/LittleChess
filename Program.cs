namespace LittleChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board();
            b.InitFiguresOnBoard();
            ConsoleBoardRenderer consoleBoardRenderer = new();
            consoleBoardRenderer.Render(b);
        }
    }
}