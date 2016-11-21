using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please input the name of your file: ");
            //Console.Write(Environment.CurrentDirectory);
            //string filename = Console.ReadLine();
            Console.WriteLine("Please input the name of your input file (Inside the TestPuzzles Directory)");
            string fileName = Console.ReadLine();
            try
            {
                PuzzleSolver solver = new PuzzleSolver(fileName);
                solver.Solve();
            }
            catch
            {
                Console.WriteLine("Your input was invalid");
            }
           
            
            
            Console.Read();
        }
    }
}
