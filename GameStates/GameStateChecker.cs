using LittleChess.BoardPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.GameStates
{
    public abstract class GameStateChecker
    {
        public abstract GameState Check(Board board, Color color);
    }
}
