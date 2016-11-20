using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using SudokuSolver.Strategies;
using System.Collections.Generic;

namespace SudokuSolverTesting
{
    [TestClass]
    public class SolveTesting
    {
        [TestMethod]
        public void SoleCandidateSuccess()
        {
            //Todo: Compare results to actual solution.
            Puzzle myPuzzle = new Puzzle("Puzzle-9x9-0001.txt");
            myPuzzle.Solve();
        }

        [TestMethod]
        public void NakedSubsetTest()
        {
            List<char> possibleSymbols = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Row r = new Row(possibleSymbols);
            for(int i = 0; i < 9; i++)
            {
                r.Add(new Cell(possibleSymbols, 0, i));
            }
            r[0].PossibleValues = new List<char>() { '4', '7' };
            r[1].PossibleValues = new List<char>() { '1', '4', '7' };
            r[2].SolvedValue = '5';
            r[3].PossibleValues = new List<char>() { '2', '4', '6', '7' };
            r[4].PossibleValues = new List<char>() { '4', '7' };
            r[5].PossibleValues = new List<char>() { '2', '4', '7' };
            r[6].SolvedValue = '8';
            r[7].PossibleValues = new List<char>() { '1', '2', '3', '4', '6', '7' };
            r[8].SolvedValue = '9';

            NakedSubset strategy = new NakedSubset();
            strategy.ReduceUnitByNakedSubset(r);

            Assert.IsTrue(r[0].PossibleValues.Contains('4'));
            Assert.IsTrue(r[0].PossibleValues.Contains('7'));
            Assert.IsFalse(r[1].PossibleValues.Contains('4'));
            Assert.IsFalse(r[1].PossibleValues.Contains('7'));
            Assert.IsFalse(r[3].PossibleValues.Contains('4'));
            Assert.IsFalse(r[3].PossibleValues.Contains('7'));
            Assert.IsFalse(r[5].PossibleValues.Contains('4'));
            Assert.IsFalse(r[5].PossibleValues.Contains('7'));
            Assert.IsFalse(r[7].PossibleValues.Contains('4'));
            Assert.IsFalse(r[7].PossibleValues.Contains('7'));
        }
    }
}
