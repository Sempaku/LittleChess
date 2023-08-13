using LittleChess.BoardPackage;
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
        public const string ANSI_WHITE_CELL_BACKGROUND = "\u001B[47m";
        public const string ANSI_BLACK_CELL_BACKGROUND = "\u001B[0;100m";
        public const string ANSI_HIGHLITHTING_CELL_BACKGROUND = "\u001B[45m";
        // TODO : string -> StringBuilder
        public void Render(Board board, Figure figureToMove)
        {
            PrepareConsole();
            HashSet<Coordinates> aviableMoves = new();
            if (figureToMove != null)
                aviableMoves = figureToMove.GetAvailableMoves(board);

            for (int rank = 8; rank >= 1; rank--)
            {
                string line = "";
                for (File file = File.A; file <= File.H; file++)
                {
                    Coordinates coordinates = new Coordinates(file, rank);
                    bool isHighlithing = aviableMoves.Contains(coordinates);
                        

                    if (board.IsCellEmpty(coordinates))
                        line += GetEmptySprite(coordinates, isHighlithing);
                    else
                    {
                        line += GetFigureSprite(board.GetFigureByCoordinate(coordinates), isHighlithing);
                    }
                }
                Console.WriteLine(line + $"{rank}");
            }
            Console.WriteLine(" A  B  C  D  E  F  G  H ");
        }

        public void Render(Board board)
        {
            Render(board, null);
        }

        private void PrepareConsole()
        {
            Console.Clear();
            ConsoleHelper.SetCurrentFont("", 36);
            Console.SetWindowSize(35, 13);
            Console.SetBufferSize(55, 55);
        }
        private string GetFigureSprite(Figure figure, bool isHighlithing)
        {
            return PaintTheSprite($" {SelectUnicodeSpriteForFigure(figure)} ",
                figure.Color, 
                Board.IsDarkCell(figure.Coordinates), 
                isHighlithing);
        }

        /// <summary>
        /// Метод возвращает спрайт в зависимости от фигуры
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string SelectUnicodeSpriteForFigure(Figure figure)
        {
            string figureTitle = figure.GetType().Name;
            /*return figureTitle switch
            {
                "Bishop" => "♝",
                "King" => "♚",
                "Knight" => "♞",
                "Pawn" => "♟",
                "Queen" => "♛",
                "Rook" => "♜",
                _ => throw new Exception("Unk")
            };*/
            return figureTitle switch
            {
                "Bishop" => "b",
                "King" => "K",
                "Knight" => "n",
                "Pawn" => "p",
                "Queen" => "Q",
                "Rook" => "r",
                _ => throw new Exception("Unk")
            };
        }

        private string GetEmptySprite(Coordinates coordinates, bool isHighlithing)
        {
            return PaintTheSprite("   ", 
                Color.WHITE, 
                Board.IsDarkCell(coordinates),
                isHighlithing);
        }
        
        private string PaintTheSprite(string sprite, Color figureColor, bool isDarkCell, bool isHighlighted)
        {
            // format = bg_color + font_color + text
            string result = sprite;
            if (figureColor is Color.WHITE)
                result = ANSI_WHITE_FIGURE_COLOR + result;
            else
                result = ANSI_BLACK_FIGURE_COLOR + result;
            if (isHighlighted) 
                result = ANSI_HIGHLITHTING_CELL_BACKGROUND + result;
            else if (isDarkCell)
                result = ANSI_BLACK_CELL_BACKGROUND + result;
            else
                result = ANSI_WHITE_CELL_BACKGROUND + result;

            return result + ANSI_RESET;
        }
    }
}
