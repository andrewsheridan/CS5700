using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver.Strategies
{
    public class HiddenSingle : Strategy
    {
        public override bool Execute(Cell cell, Puzzle puzzle)
        {
            bool didReduction = false;
            didReduction = ReduceUnitByHiddenSingle(puzzle.Rows[cell.Row]) ? true : didReduction;
            didReduction = ReduceUnitByHiddenSingle(puzzle.Columns[cell.Column]) ? true : didReduction;
            didReduction = ReduceUnitByHiddenSingle(puzzle.Blocks[Puzzle.ComputeBlockIndex(cell.Row, cell.Column, puzzle.Size)]) ? true : didReduction;
            return didReduction;
        }

        public bool ReduceUnitByHiddenSingle(Unit unit)
        {
            Dictionary<char, int> possibleValueCounts = GetPossibleValueCounts(unit);
            List<char> singles = new List<char>();
            foreach(KeyValuePair<char,int> pair in possibleValueCounts)
            {
                if (pair.Value == 1)
                    singles.Add(pair.Key);
            }
            if(singles.Count > 0)
            {
                foreach (Cell cell in unit)
                {
                    foreach (Char character in singles)
                    {
                        if (cell.PossibleValues.Contains(character))
                            cell.SetValue(character);
                    }
                }
                return true;
            }
            return false;
        }

        private Dictionary<char, int> GetPossibleValueCounts(Unit unit)
        {
            Dictionary<char, int> possibleValueCounts = new Dictionary<char, int>();
            foreach(char character in unit.PossibleValues)
            {
                int count = 0;
                foreach (Cell cell in unit)
                {
                    if (cell.PossibleValues.Contains(character))
                        count++;
                }
                possibleValueCounts.Add(character, count);
            }
            return possibleValueCounts;
        }
    }
}
