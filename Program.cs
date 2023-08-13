using LittleChess.BoardPackage;
using LittleChess.Figures;

namespace LittleChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoardFactory boardFactory = new BoardFactory();
            //Board b = boardFactory.CreateBoardFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //Board b = boardFactory.CreateBoardFromFEN("k4r2/8/8/r7/4KN2/2q1N3/8/8 w - - 0 1");
            //Board b = boardFactory.CreateBoardFromFEN("8/8/8/4p3/8/4K3/8/8 w - - 0 1");
            Board b = boardFactory.CreateBoardFromFEN("6r1/8/8/8/8/8/r7/7K w - - 0 1");
            GameLogic gameLogic = new GameLogic(b);
            gameLogic.StartGame();


        }
    }
}