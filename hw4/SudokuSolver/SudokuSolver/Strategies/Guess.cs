//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SudokuSolver.SudokuComponents;

//namespace SudokuSolver.Strategies
//{
//    public class Guess : Strategy
//    {
//        public override bool Execute(Cell cell, Puzzle puzzle)
//        {
//            if (cell.PossibleValues.Count <= 1) return false;
            
//            char guessedCharacter = '\0';
//            foreach (char character in cell.PossibleValues)
//            {
//                if (!cell.GuessedValues.Contains(character))
//                {
//                    guessedCharacter = character;
//                    break;
//                }
//            }

//            if (guessedCharacter == '\0') return false;
            
//            cell.GuessedValues.Add(guessedCharacter);
//            cell.PossibleValues.Remove(guessedCharacter);

//            Puzzle newPuzzle = new Puzzle(puzzle);
//            if (newPuzzle.Solve())
//            {
//                puzzle.solutions.Add(newPuzzle.ToString());
//                return true;
//            }
//            else return false;
//        }
//    }
//}
