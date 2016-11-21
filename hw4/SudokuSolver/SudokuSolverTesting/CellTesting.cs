using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;
using SudokuSolver.SudokuComponents;

namespace SudokuSolverTesting
{
    [TestClass]
    public class CellTesting
    {
        [TestMethod]
        public void SetCellValueSuccess()
        {
            int row = 4;
            int column = 5;
            int size = 9;
            char testChar = '1';

            List<char> characters = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Puzzle p = new Puzzle(size, characters);
            
            p.SetCellValue(row, column, testChar);
            for(int i = 0; i < p.Size; i++)
            {
                Assert.IsFalse(p.GetCellAt(row, i).PossibleValues.Contains(testChar));
                Assert.IsFalse(p.GetCellAt(i, column).PossibleValues.Contains(testChar));
            }

            int blockIndex = Puzzle.ComputeBlockIndex(row, column, size);
            int rootSize = (int)Math.Sqrt(size);
            int rowStart = (blockIndex / rootSize) * rootSize;
            int colStart = (blockIndex % rootSize) * rootSize;
            for (int i = rowStart; i < rowStart + rootSize; i++)
            { 
                for(int j = colStart; j < colStart + rootSize; j++)
                {
                    Assert.IsFalse(p.GetCellAt(i, j).PossibleValues.Contains(testChar));
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCellValue()
        {
            int size = 9;
            int row = 4;
            int column = 5;
            char testChar = 'a';
            List<char> characters = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Puzzle p = new Puzzle(size, characters);

            p.SetCellValue(row, column, testChar);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidCellPosition()
        {
            int size = 9;
            int row = 20;
            int column = 5;
            char testChar = '1';
            List<char> characters = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Puzzle p = new Puzzle(size, characters);

            p.SetCellValue(row, column, testChar);
        }
    }
}
