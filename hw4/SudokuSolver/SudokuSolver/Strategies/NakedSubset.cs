using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Strategies
{
    public class NakedSubset : Strategy
    {
        public override bool Execute(Cell cell, Puzzle puzzle)
        {
            bool didReduction = false;
            didReduction = ReduceUnitByNakedSubset(puzzle.Rows[cell.Row]) ? true : didReduction;
            didReduction = ReduceUnitByNakedSubset(puzzle.Columns[cell.Column]) ? true : didReduction;
            didReduction =  ReduceUnitByNakedSubset(puzzle.Blocks[Puzzle.ComputeBlockIndex(cell.Row, cell.Column, puzzle.Size)]) ? true : didReduction;
            return didReduction;
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

        public bool ReduceUnitByNakedSubset(Unit unit)
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

            bool didReduction = false;
            if(cellsContainingOnlyCommonChars.Count == commonCharacters.Count)
            {
                foreach(Cell cell in cellsContainingMoreThanCommonChars)
                {
                    foreach(char commonCharacter in commonCharacters)
                    {
                        if(cell.PossibleValues.Contains(commonCharacter))
                        {
                            cell.PossibleValues.Remove(commonCharacter);
                            cell.AttemptCounter = 0;
                            didReduction = true;
                        }
                    }
                }
            }
            return didReduction;
        }
    }
}
