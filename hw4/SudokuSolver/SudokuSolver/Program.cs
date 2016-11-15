using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please input the name of your file: ");
            //Console.Write(Environment.CurrentDirectory);
            //string filename = Console.ReadLine();
            string filename = "../../TestPuzzles/Puzzle-4x4-0001.txt";
            Puzzle myPuzzle = SudokuComponents.PuzzleIO.LoadFromFile(filename);
            Console.Write(myPuzzle.ToString());
            Console.Read();
        }
    }
}
