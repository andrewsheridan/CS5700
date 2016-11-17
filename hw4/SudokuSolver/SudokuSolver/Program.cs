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
            string filePath = "../../TestPuzzles/";
            Console.WriteLine("Please input the name of your input file (Inside the TestPuzzles Directory)");
            string fileName = Console.ReadLine();
            Puzzle myPuzzle = SudokuComponents.PuzzleIO.LoadFromFile(filePath + fileName);
            Console.Write(myPuzzle.ToString());
            myPuzzle.PrintPossibleValues();
            //myPuzzle.Solve();
            Console.Read();
        }
    }
}
