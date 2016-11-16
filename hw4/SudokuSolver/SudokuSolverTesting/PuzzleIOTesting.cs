using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using SudokuSolver.SudokuComponents;

namespace SudokuSolverTesting
{
    [TestClass]
    public class PuzzleIOTesting
    {
        [TestMethod]
        public void LoadSuccess()
        {

            string filename = "../../../SudokuSolver/TestPuzzles/Puzzle-4x4-0001.txt";
            Puzzle myPuzzle = PuzzleIO.LoadFromFile(filename);
            Assert.IsNotNull(myPuzzle);
        }

        [TestMethod]
        public void LoadFailure()
        {
            string filename = "../../../SudokuSolver/TestPuzzles/Puzzle-4x4-0901.txt";
            Puzzle myPuzzle = PuzzleIO.LoadFromFile(filename);
            Assert.IsNull(myPuzzle);
        }
    }
}
