using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class NakedSubset : Strategy
    {
        public override void Execute(Cell cell, Puzzle puzzle)
        {
            ReduceUnitByNakedSubset(puzzle.Rows[cell.Row]);
            ReduceUnitByNakedSubset(puzzle.Columns[cell.Column]);
            ReduceUnitByNakedSubset(puzzle.Blocks[Puzzle.ComputeBlockIndex(cell.Row, cell.Column, puzzle.Size)]);
        }

        private List<char> FindCommonCharacters(Unit unit)
        {
            List<char> commonCharacters = new List<char>(unit[0].PossibleValues);
            foreach(Cell cell in unit)
            {
                foreach(char character in commonCharacters)
                {
                    if(!cell.PossibleValues.Contains(character))
                    {
                        commonCharacters.Remove(character);
                    }
                }
            }
            return commonCharacters;
        }

        public void ReduceUnitByNakedSubset(Unit unit)
        {
            List<char> commonCharacters = FindCommonCharacters(unit);
            List<Cell> cellsContainingMoreThanCommonChars = new List<Cell>();
            List<Cell> cellsContainingOnlyCommonChars = new List<Cell>();

            foreach(Cell cell in unit)
            {
                if (cell.PossibleValues.Count > commonCharacters.Count)
                    cellsContainingMoreThanCommonChars.Add(cell);
                else
                    cellsContainingOnlyCommonChars.Add(cell);
            }

            if(cellsContainingOnlyCommonChars.Count == commonCharacters.Count)
            {
                foreach(Cell cell in cellsContainingMoreThanCommonChars)
                {
                    foreach(char commonCharacter in commonCharacters)
                        cell.PossibleValues.Remove(commonCharacter);
                }
            }
        }
    }
}
