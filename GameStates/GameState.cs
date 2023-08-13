using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.GameStates
{
    public enum GameState
    {
        GAME_IS_ON,
        STALEMATE,
        CHECKMATE_TO_WHITE_KING,
        CHECKMATE_TO_BLACK_KING,
    }
}
