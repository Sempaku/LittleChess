using LittleChess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess.BoardPackage
{
    internal class BoardFactory
    {
        FigureFactory figureFactory = new FigureFactory();
        // rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        public Board CreateBoardFromFEN(string fen)
        {
            Board board = new Board(fen);

            string[] fenParts = fen.Split(" ");
            string figuresPosition = fenParts[0];

            string[] figuresRows = figuresPosition.Split("/");

            for (int i = 0; i < figuresRows.Length; i++)
            {
                string row = figuresRows[i];
                int rank = 8 - i;
                int fileIndex = 0;
                for (int j = 0; j < row.Length; j++)
                {
                    char fenChar = row[j];
                    if (char.IsDigit(fenChar))
                    {
                        fileIndex += (int)char.GetNumericValue(fenChar);
                    }
                    else
                    {
                        File file = (File)Enum.GetValues<File>().GetValue(fileIndex);
                        Coordinates coordinates = new Coordinates(file, rank);

                        board.SetFigure(coordinates, figureFactory.CreateFigureByChar(fenChar, coordinates));
                        fileIndex++;

                    }
                }
            }


            return board;
        }

        public Board Copy(Board sourceBoard)
        {
            Board copyBoard = CreateBoardFromFEN(sourceBoard.StartFen);
            foreach (var move in sourceBoard.moveHistiry)
            {
                copyBoard.MakeMove(move);
            }

            return copyBoard;
        }
    }
}
