using LittleChess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    internal class FigureFactory
    {
        //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        public Figure CreateFigureByChar(char fenChar, Coordinates coordinates)
        {
            return fenChar switch
            {
                'r' => new Rook(Color.BLACK, coordinates),
                'R' => new Rook(Color.WHITE, coordinates),

                'n' => new Knight(Color.BLACK, coordinates),
                'N' => new Knight(Color.WHITE, coordinates),

                'b' => new Bishop(Color.BLACK, coordinates),
                'B' => new Bishop(Color.WHITE, coordinates),

                'q' => new Queen(Color.BLACK, coordinates),
                'Q' => new Queen(Color.WHITE, coordinates),

                'k' => new King(Color.BLACK, coordinates),
                'K' => new King(Color.WHITE, coordinates),

                'p' => new Pawn(Color.BLACK, coordinates),
                'P' => new Pawn(Color.WHITE, coordinates),

                _ => throw new ArgumentException("Unknown fenChar")
            };
        }
    }
}
