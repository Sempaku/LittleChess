using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleChess
{
    internal class ConsoleInputParser
    {
        public Coordinates Input()
        {
            char[] goodFiles = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            while(true)
            {
                Console.WriteLine("INPUT COORDINATES [ex. g5]:");
                string inputText = Console.ReadLine();
                bool isRankInt = int.TryParse(inputText[1].ToString(), out int rank);
                if ((inputText.Length != 2 )|| (rank < 1 || rank > 8 || !isRankInt) || (!goodFiles.Contains(inputText[0])))
                {
                    Console.WriteLine("OMG...");
                    continue;
                }
                File file = (File)Enum.Parse(typeof(File), inputText[0].ToString().ToUpper());
                return new Coordinates(file, rank);
            }
        }
    }
}
