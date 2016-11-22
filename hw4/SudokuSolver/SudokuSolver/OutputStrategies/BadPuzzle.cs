using System;
using SudokuSolver;
using SudokuSolver.SudokuComponents;
using System.Collections.Generic;

namespace SudokuSolver.OutputStrategies
{
    public class BadPuzzle : OutputTemplate
    {
        public BadPuzzle(int size, List<char> symbols, List<Puzzle> solutions, string filename) 
            : base(size, symbols, solutions, filename) { }

        public override string SuccessState()
        {
            return "Bad Puzzle" + Environment.NewLine;
        }

        public override string Size()
        {
            return "";
        }

        public override string Symbols()
        {
            return "";
        }

        public override string Solutions()
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filename);
            return reader.ReadToEnd();
        }
    }
}
