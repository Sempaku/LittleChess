using LittleChess.BoardPackage;

namespace LittleChess.GameStates
{
    public abstract class GameStateChecker
    {
        public abstract GameState Check(Board board, Color color);
    }
}