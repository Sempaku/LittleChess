using LittleChess.Figures;
using LittleChess.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    public class ConsoleBoardRenderer
    {
        public const string ANSI_RESET = "\u001B[0m";
        public const string ANSI_WHITE_FIGURE_COLOR = "\u001B[97m";
        public const string ANSI_BLACK_FIGURE_COLOR = "\u001B[30m";
        public const string ANSI_WHITE_SQUARE_BACKGROUND = "\u001B[47m";
        public const string ANSI_BLACK_SQUARE_BACKGROUND = "\u001B[0;100m";
        public void Render(Board board)
        {
            PrepareConsole();
            GetEmptySprite(new Coordinates(File.G, 5));
            for (int rank = 8; rank >= 1; rank--)
            {
                string line = "";
                for (File file = File.A; file <= File.H; file++)
                {
                    Coordinates coordinates = new Coordinates(file, rank);

                    if (board.IsCellEmpty(coordinates))
                        line += GetEmptySprite(coordinates);
                    else
                    {
                        line += GetFigureSprite(Board.GetFigureByCoordinate(coordinates));
                    }




                }
                Console.WriteLine(line);
                line = "";
            }
            Console.Read();
        }


        private void PrepareConsole()
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //ConsoleHelper.SetCurrentFont("Lucida Console", 22);
            /*Console.SetWindowSize(22, 11);
            Console.SetBufferSize(55, 55);*/
        }
        private string GetFigureSprite(Figure figure)
        {
            return PaintTheSprite($" {SelectUnicodeSpriteForFigure(figure)} ", figure.Color, Board.IsDarkCell(figure.Coordinates));
        }

        private string SelectUnicodeSpriteForFigure(Figure figure)
        {
            string figureTitle = figure.GetType().Name;
            return figureTitle switch
            {
                "Bishop" => "♝",
                "King" => "♚",
                "Knight" => "♞",
                "Pawn" => "♟",
                "Queen" => "♛",
                "Rook" => "♜",

            };
                    
            
        }
        private string GetEmptySprite(Coordinates coordinates)
        {
            return PaintTheSprite("   ", Color.WHITE, Board.IsDarkCell(coordinates));
        }
        
        private string PaintTheSprite(string sprite, Color figureColor, bool isDarkCell)
        {
            // format = bg_color + font_color + text
            string result = sprite;
            if (figureColor is Color.WHITE)
                result = ANSI_WHITE_FIGURE_COLOR + result;
            else
                result = ANSI_BLACK_FIGURE_COLOR + result;

            if (isDarkCell)
                result = ANSI_BLACK_SQUARE_BACKGROUND + result;
            else
                result = ANSI_WHITE_SQUARE_BACKGROUND + result;

            return result + ANSI_RESET;
        }
    }
}
