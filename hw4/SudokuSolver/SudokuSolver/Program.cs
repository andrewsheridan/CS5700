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
            Console.WriteLine("Type 'exit' to exit.");
            string fileName = Console.ReadLine();
            while(fileName != "exit")
            {
                try
                {
                    PuzzleSolver solver = new PuzzleSolver(fileName);
                    solver.Solve();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Your input was invalid: {e.Message}");
                }
                Console.WriteLine("Please input the name of your input file (Inside the TestPuzzles Directory)");
                fileName = Console.ReadLine();
            }
            
           
            Console.Read();
        }
    }
}
