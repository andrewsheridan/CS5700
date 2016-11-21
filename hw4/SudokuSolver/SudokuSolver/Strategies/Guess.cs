using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class Guess : Strategy
    {
        public override bool Execute(Cell cell, Puzzle puzzle)
        {
            Puzzle newPuzzle = new Puzzle(puzzle);
            return true;
        }
    }
}
