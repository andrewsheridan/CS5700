using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.SudokuComponents;
using SudokuSolver;

namespace SudokuSolverTesting
{
    [TestClass]
    public class LoadFileTesting
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
