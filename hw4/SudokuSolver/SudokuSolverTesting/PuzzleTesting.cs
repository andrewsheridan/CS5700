using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.SudokuComponents;
using SudokuSolver;
using System.Collections.Generic;

namespace SudokuSolverTesting
{
    [TestClass]
    public class PuzzleTesting
    {
        [TestMethod]
        public void NewPuzzleSuccess()
        {
            char[] list = { '1', '2', '3', '4' };
            List<char> symbolList = new List<char>();
            symbolList.AddRange(list);
            Puzzle newPuzzle = new Puzzle(4, symbolList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeTooSmall()
        {
            char[] list = { '1', '2', '3', '4' };
            List<char> symbolList = new List<char>();
            symbolList.AddRange(list);
            Puzzle newPuzzle = new Puzzle(1, symbolList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SizeNotSquare()
        {
            char[] list = { '1', '2', '3', '4' };
            List<char> symbolList = new List<char>();
            symbolList.AddRange(list);
            Puzzle newPuzzle = new Puzzle(5, symbolList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectSymbolCount()
        {
            char[] list = { '1', '2', '3', '4', '5'};
            List<char> symbolList = new List<char>();
            symbolList.AddRange(list);
            Puzzle newPuzzle = new Puzzle(4, symbolList);
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
        [ExpectedException(typeof(ArgumentException),
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
