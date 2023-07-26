namespace LittleChess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinates coordinates = new Coordinates(File.A, 1);
            Console.WriteLine($"{coordinates.GetHashCode()}");
        }
    }
}