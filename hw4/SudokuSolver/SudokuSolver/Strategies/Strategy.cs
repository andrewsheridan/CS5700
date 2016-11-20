using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public abstract class Strategy
    {
        public abstract void Execute(Cell cell, Puzzle puzzle);
        //public abstract void FindApplicableCells(Unit unit);
        //public abstract void UpdateCells(Unit unit);
    }
}
