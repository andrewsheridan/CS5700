using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class HiddenSingle : Strategy
    {
        public override void Execute(Cell cell, Puzzle puzzle)
        {
            ReduceUnitByHiddenSingle(puzzle.Rows[cell.Row]);
            ReduceUnitByHiddenSingle(puzzle.Columns[cell.Column]);
            ReduceUnitByHiddenSingle(puzzle.Blocks[Puzzle.ComputeBlockIndex(cell.Row, cell.Column, puzzle.Size)]);
        }

        public void ReduceUnitByHiddenSingle(Unit unit)
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
            }
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
