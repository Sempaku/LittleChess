using LittleChess.Figures;

namespace LittleChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board();
            b.InitFiguresOnBoard();
            GameLogic gameLogic = new GameLogic(b);
            gameLogic.StartGame();
        }
    }
}