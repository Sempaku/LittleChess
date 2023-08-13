using LittleChess.BoardPackage;
using LittleChess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.GameStates
{
    public class CheckmateGameStateChecker : GameStateChecker
    {
        public override GameState Check(Board board, Color color)
        {
            // Допущение -> у нас на доске есть король
            Figure? king = board.GetFiguresByColor(color).FirstOrDefault(f => f is King);
            if (king is null)
                throw new ArgumentNullException("King is null!");

            if (!board.IsCellUnderAttackByColor(king.Coordinates, 
                color == Color.WHITE 
                ? Color.BLACK 
                : Color.WHITE))
            {
                return GameState.GAME_IS_ON;
            }

            var allFiguresWithOurColors = board.GetFiguresByColor(color);
            foreach (Figure ourFigure in allFiguresWithOurColors)
            {
                var ourFigureAviableMoves = ourFigure.GetAvailableMoves(board);
                foreach (Coordinates coordinates in ourFigureAviableMoves)
                {
                    Board cloneBoard = new BoardFactory().Copy(board);
                    Figure? cloneBoardKing = cloneBoard.GetFiguresByColor(color).FirstOrDefault(f => f is King);

                    cloneBoard.MakeMove(new Move(ourFigure.Coordinates, coordinates));

                    if (cloneBoard.IsCellUnderAttackByColor(cloneBoardKing.Coordinates,
                        color == Color.WHITE
                        ? Color.BLACK
                        : Color.WHITE))
                    {
                        return GameState.GAME_IS_ON;
                    }
                }
            }

            if (color == Color.WHITE)
                return GameState.CHECKMATE_TO_WHITE_KING;
            else
                return GameState.CHECKMATE_TO_BLACK_KING;
        }
    }
}
