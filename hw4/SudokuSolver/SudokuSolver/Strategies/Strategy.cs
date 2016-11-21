using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver.Strategies
{
    public abstract class Strategy
    {
        /// <summary>
        /// Executes the solving strategy on the given cell in the given puzzle
        /// </summary>
        /// <param name="cell">The cell we are focused on solving</param>
        /// <param name="puzzle">The puzzle containing the cell</param>
        /// <returns>True if reductions were made to the cells in the puzzle. False otherwise.</returns>
        public abstract bool Execute(Cell cell, Puzzle puzzle);
        //public abstract void FindApplicableCells(Unit unit);
        //public abstract void UpdateCells(Unit unit);
    }
}
