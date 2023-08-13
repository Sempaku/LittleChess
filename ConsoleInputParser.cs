using LittleChess.BoardPackage;
using LittleChess.Figures;

namespace LittleChess
{
    internal class ConsoleInputParser
    {
        public static Coordinates Input()
        {
            while (true)
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

        public static Coordinates InputFigureCoordinatesByColor(Color color, Board board)
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

        public static Coordinates InputAviableMove(Figure figure, Board board)
        {
            while (true)
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
        /// Парсит строку, если данные не удалось спарсить, то возвращается false, file = ' ', rank
        /// = -1;
        /// </summary>
        /// <param name="inputText"> </param>
        /// <param name="file">      </param>
        /// <param name="rank">      </param>
        /// <returns> </returns>
        private static bool TryParseCoordinate(string inputText, out char file, out int rank)
        {
            file = ' '; rank = -1;

            char[] goodFiles = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            if (string.IsNullOrWhiteSpace(inputText) || inputText.Length != 2) // todo : del isnull
                return false;

            if (!goodFiles.Contains(inputText[0]))
                return false;

            bool isRankInt = int.TryParse(inputText[1].ToString(), out int parsedRank);

            if ((parsedRank < 1 || parsedRank > 8 || !isRankInt))
                return false;

            file = inputText[0]; rank = parsedRank;
            return true;
        }

        public static Move InputMove(Board board, Color color, ConsoleBoardRenderer boardRenderer)
        {
            while (true)
            {
                // input
                Coordinates coordsFrom = InputFigureCoordinatesByColor(color, board);
                Figure figure = board.GetFigureByCoordinate(coordsFrom);
                boardRenderer.Render(board, figure);
                Coordinates coordsTo = InputAviableMove(figure, board);
                Move move = new Move(coordsFrom, coordsTo);

                // check if king check after move (from , to) cw(king is under attack)

                if (ValidateIfKingCheckAfterMove(move, board, color))
                {
                    Console.WriteLine("Your king is under attack!!!");
                    continue;
                }

                return move;
            }
        }

        private static bool ValidateIfKingCheckAfterMove(Move move, Board board, Color color)
        {
            Board copyBoard = new BoardFactory().Copy(board);
            copyBoard.MakeMove(move);

            // Допущение -> на доске есть король :)
            Figure? king = copyBoard.GetFiguresByColor(color).FirstOrDefault(f => f is King);
            if (king is null)
            {
                throw new NullReferenceException("King is null!");
            }

            return copyBoard.IsCellUnderAttackByColor(king.Coordinates,
                (color == Color.WHITE)
                ? Color.BLACK
                : Color.WHITE);
        }
    }
}