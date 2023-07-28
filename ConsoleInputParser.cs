using LittleChess.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    internal class ConsoleInputParser
    {
        public static Coordinates Input()
        {
            while(true)
            {
                string? inputText = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputText))
                    continue;

                bool isParse = TryParseCoordinate(inputText, out char parsedFile, out int parsedRank);
                if (!isParse)
                    continue;

                File file = (File)Enum.Parse(typeof(File), parsedFile.ToString().ToUpper());
                return new Coordinates(file, parsedRank);
            }
        }

        public Coordinates InputFigureCoordinatesByColor(Color color, Board board)
        {
            while (true)
            {
                Console.Write($"[{color.ToString().ToUpper()}]: Enter coordinate -> ");
                Coordinates coord = Input();

                if (board.IsCellEmpty(coord))
                {
                    Console.WriteLine("Cell is empty!");
                    continue;
                }

                Figure figure = board.GetFigureByCoordinate(coord);

                if (!(figure.Color == color))
                {
                    Console.WriteLine("Take your figure!");
                    continue;
                }

                var aviableMoves = figure.GetAvailableMoves(board);
                if (aviableMoves.Count == 0)
                {
                    Console.WriteLine("Figure is locked!");
                    continue;
                }

                return coord;
            }
        }

        public Coordinates inputAviableMove(Figure figure, Board board)
        {
            while(true)
            {
                HashSet<Coordinates> aviableMoves = figure.GetAvailableMoves(board);
                Console.WriteLine("Aviable moves:");
                foreach (var move in aviableMoves)
                    Console.Write($"|{move.ToString()}| ");

                Console.Write($"[{figure.Color.ToString().ToUpper()}]: Move -> ");
                Coordinates coordinates = Input();
                if (!aviableMoves.Contains(coordinates))
                {
                    Console.WriteLine("Pick aviable move...");
                    continue;
                }

                return coordinates;
            }

        }

        /// <summary>
        /// Парсит строку, если данные не удалось спарсить, то возвращается false, 
        /// file = ' ', rank = -1;
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="file"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private static bool TryParseCoordinate(string inputText, out char file, out int rank)
        {
            file = ' '; rank = -1;

            char[] goodFiles = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            if (string.IsNullOrWhiteSpace(inputText) || inputText.Length != 2)
                return false;

            if (!goodFiles.Contains(inputText[0]))
                return false;

            bool isRankInt = int.TryParse(inputText[1].ToString(), out int parsedRank);

            if ((parsedRank < 1 || parsedRank > 8 || !isRankInt))
                return false;

            file = inputText[0]; rank = parsedRank;
            return true;
        }
    }
}
