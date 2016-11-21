using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class SoleCandidate : Strategy
    {
        public override bool Execute(Cell cell, Puzzle puzzle)
        {
            char newValue = puzzle.Cells[cell.Row][cell.Column].PossibleValues[0];
            puzzle.Cells[cell.Row][cell.Column].SetValue(newValue);
            puzzle.Cells[cell.Row][cell.Column].PossibleValues.Clear();
            return true;
        }
    }
}
