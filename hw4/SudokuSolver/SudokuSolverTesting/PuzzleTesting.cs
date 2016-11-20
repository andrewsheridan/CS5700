using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;

namespace SudokuSolverTesting
{
    [TestClass]
    public class PuzzleTesting
    {
        [TestMethod]
        public void LoadSuccess()
        {
            string filename = "Puzzle-4x4-0001.txt";
            Puzzle myPuzzle = new Puzzle(filename);
            Assert.IsNotNull(myPuzzle);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileLoadException))]
        public void LoadFailure()
        {
            string filename = "Puzzle-4x4-0901.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void FileDoesNotExist()
        {
            string filename = "NOTAFILE.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileLoadException))]
        public void TooManyColumns()
        {
            string filename = "TooManyColumns.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TooManyRows()
        {
            string filename = "TooManySymbols.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileLoadException))]
        public void MissingEntry()
        {
            string filename = "NotEnoughColumns.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidSizeType()
        {
            string filename = "InvalidSize.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SizeNotSquare()
        {
            string filename = "SizeNotSquare.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SizeTooSmall()
        {
            string filename = "SizeNotSquare.txt";
            Puzzle myPuzzle = new Puzzle(filename);
        }


        [TestMethod]
        public void ComputeBlockIndexSuccess()
        {
            Assert.AreEqual(Puzzle.ComputeBlockIndex(0, 0, 9), 0);
            Assert.AreEqual(Puzzle.ComputeBlockIndex(4, 0, 9), 3);
            Assert.AreEqual(Puzzle.ComputeBlockIndex(3, 2, 4), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Size is not a perfect square")]
        public void ComputeBlockIndexFailures()
        {
            Puzzle.ComputeBlockIndex(4, 0, 8);
            Puzzle.ComputeBlockIndex(4, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "Invalid input parameters")]
        public void ComputeBlockIndexBadInput()
        {
            Puzzle.ComputeBlockIndex(-1, 0, 9);
            Puzzle.ComputeBlockIndex(0, -1, 9);
            Puzzle.ComputeBlockIndex(10, 0, 9);
            Puzzle.ComputeBlockIndex(0, 10, 9);
        }


    }
}
