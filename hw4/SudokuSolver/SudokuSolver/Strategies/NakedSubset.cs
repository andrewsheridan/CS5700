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
            List<char> commonCharacters = new List<char>();
            commonCharacters.AddRange(unit.PossibleValues);
            HashSet<char> charactersNotFound = new HashSet<char>();
            foreach(Cell cell in unit)
            {
                if(cell.SolvedValue == '\0')
                {
                    foreach (char character in unit.PossibleValues)
                    {
                        if (!cell.PossibleValues.Contains(character))
                        {
                            charactersNotFound.Add(character);
                        }
                    }
                }
            }
            foreach(char character in charactersNotFound)
            {
                commonCharacters.Remove(character);
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
                if(cell.SolvedValue == '\0')
                {
                    if (cell.PossibleValues.Count > commonCharacters.Count)
                        cellsContainingMoreThanCommonChars.Add(cell);
                    else
                        cellsContainingOnlyCommonChars.Add(cell);
                }
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
