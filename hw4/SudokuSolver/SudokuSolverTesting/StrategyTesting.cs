﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SudokuSolver;
using SudokuSolver.Strategies;

namespace SudokuSolverTesting
{
    [TestClass]
    public class StrategyTesting
    {
        [TestMethod]
        public void NakedSubsetTest()
        {
            List<char> possibleSymbols = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Row r = new Row(possibleSymbols);
            for (int i = 0; i < 9; i++)
            {
                r.Add(new Cell(possibleSymbols, 0, i));
            }
            r[0].PossibleValues = new List<char>() { '4', '7' };
            r[1].PossibleValues = new List<char>() { '1', '4', '7' };
            r[2].SolvedValue = '5';
            r[2].PossibleValues.Clear();
            r[3].PossibleValues = new List<char>() { '2', '4', '6', '7' };
            r[4].PossibleValues = new List<char>() { '4', '7' };
            r[5].PossibleValues = new List<char>() { '2', '4', '7' };
            r[6].SolvedValue = '8';
            r[6].PossibleValues.Clear();
            r[7].PossibleValues = new List<char>() { '1', '2', '3', '4', '6', '7' };
            r[8].SolvedValue = '9';
            r[8].PossibleValues.Clear();

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

        [TestMethod]
        public void HiddenSingleTest()
        {
            List<char> possibleSymbols = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Row r = new Row(possibleSymbols);
            for (int i = 0; i < 9; i++)
            {
                r.Add(new Cell(possibleSymbols, 0, i));
            }
            r[0].PossibleValues = new List<char>() { '1', '2', '5' };
            r[1].PossibleValues = new List<char>() { '1', '3', '5', '6' };
            r[2].SolvedValue = '8';
            r[2].PossibleValues.Clear();
            r[3].SolvedValue = '4';
            r[3].PossibleValues.Clear();
            r[4].PossibleValues = new List<char>() { '1', '5', '6', '7' };
            r[5].PossibleValues = new List<char>() { '6', '7', '9' };
            r[6].PossibleValues = new List<char>() { '2', '7' };
            r[7].PossibleValues = new List<char>() { '7', '6' };
            r[8].PossibleValues = new List<char>() { '6', '7', '9' };

            HiddenSingle strategy = new HiddenSingle();
            strategy.ReduceUnitByHiddenSingle(r);

            Assert.IsTrue(r[1].SolvedValue == '3');
        }
    }
}
