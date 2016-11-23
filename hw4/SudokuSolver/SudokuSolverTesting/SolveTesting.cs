using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using SudokuSolver.Strategies;
using System.Collections.Generic;
using SudokuSolver.SudokuComponents;
using System.Text.RegularExpressions;

namespace SudokuSolverTesting
{
    [TestClass]
    public class SolveTesting
    {
        private bool TestFile(string expectedResult, string filename, int solutionCount)
        {
            PuzzleSolver solver = new PuzzleSolver(filename);
            List<Puzzle> results = solver.Solve();
            Assert.AreEqual(results.Count, solutionCount);
            if (solutionCount > 0)
            {
                bool expectedResultFound = false;
                foreach (Puzzle p in results)
                    expectedResultFound = ResultsAreEqual(expectedResult, p.ToString()) ? true : expectedResultFound;
                return expectedResultFound;
            }
            return true;
        }

        private string stripAnswer(string answer)
        {
            string result = answer.Replace(System.Environment.NewLine, string.Empty);
            result = Regex.Replace(result, @"\s+", "");
            return result;
        }

        private bool ResultsAreEqual(string expected, string actual)
        {
            expected = stripAnswer(expected);
            actual = stripAnswer(actual);
            return expected == actual;
        }

        [TestMethod]
        public void Two21()
        {
            string filename = "Puzzle-4x4-0201.txt";
            string expectedResult = @"2 4 3 1
                                        1 3 2 4
                                        3 1 4 2
                                        4 2 1 3";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine01()
        {
            string filename = "Puzzle-9x9-0001.txt";
            string expectedResult = @"4 9 2 1 3 6 7 5 8
                                    7 6 3 5 4 8 1 9 2 
                                    5 1 8 7 2 9 3 6 4 
                                    8 2 5 3 1 7 9 4 6 
                                    6 7 4 8 9 5 2 1 3 
                                    9 3 1 2 6 4 5 8 7 
                                    1 8 6 9 7 3 4 2 5 
                                    2 4 7 6 5 1 8 3 9 
                                    3 5 9 4 8 2 6 7 1 ";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine02()
        {
            string filename = "Puzzle-9x9-0002.txt";
            string expectedResult = @"8 9 3 6 2 4 5 1 7
                                    2 5 1 7 8 3 6 4 9
                                    6 7 4 5 9 1 2 8 3
                                    1 3 7 9 6 5 4 2 8
                                    9 8 6 3 4 2 1 7 5
                                    5 4 2 8 1 7 9 3 6
                                    4 6 8 2 3 9 7 5 1
                                    3 1 5 4 7 6 8 9 2
                                    7 2 9 1 5 8 3 6 4";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine11()
        {
            string filename = "Puzzle-9x9-0101.txt";
            string expectedResult = @"1 9 2 6 4 8 3 7 5
                                    4 3 5 1 7 9 2 6 8
                                    7 8 6 2 5 3 4 9 1
                                    9 1 8 4 2 6 7 5 3
                                    2 7 3 9 1 5 6 8 4
                                    6 5 4 8 3 7 9 1 2
                                    8 2 7 5 9 4 1 3 6
                                    3 6 1 7 8 2 5 4 9
                                    5 4 9 3 6 1 8 2 7";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine12()
        {
            string filename = "Puzzle-9x9-0102.txt";
            string expectedResult = @"4 3 8 5 9 1 2 7 6
                                    7 9 2 3 6 4 1 5 8
                                    5 6 1 2 8 7 9 4 3
                                    8 4 5 1 2 3 7 6 9
                                    9 7 6 4 5 8 3 1 2
                                    2 1 3 9 7 6 4 8 5
                                    3 8 7 6 4 9 5 2 1
                                    6 2 9 7 1 5 8 3 4
                                    1 5 4 8 3 2 6 9 7";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine13()
        {
            string filename = "Puzzle-9x9-0103.txt";
            string expectedResult = @"5 1 3 6 7 2 9 8 4
                                    9 4 2 5 3 8 1 7 6
                                    7 8 6 9 4 1 2 5 3
                                    2 6 9 4 5 7 8 3 1
                                    8 3 5 2 1 9 6 4 7
                                    4 7 1 8 6 3 5 2 9
                                    1 9 7 3 2 5 4 6 8
                                    6 2 8 7 9 4 3 1 5
                                    3 5 4 1 8 6 7 9 2";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine21()
        {
            string filename = "Puzzle-9x9-0201.txt";
            string expectedResult = @"8 2 6 9 3 5 1 4 7
                                    7 5 1 6 8 4 2 9 3
                                    3 4 9 2 1 7 5 8 6
                                    1 9 2 7 4 3 6 5 8
                                    4 6 7 5 9 8 3 1 2
                                    5 3 8 1 6 2 9 7 4
                                    6 7 3 8 5 9 4 2 1
                                    2 1 5 4 7 6 8 3 9
                                    9 8 4 3 2 1 7 6 5";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine22()
        {
            string filename = "Puzzle-9x9-0202.txt";
            string expectedResult = @"6 3 4 9 5 2 8 7 1
                                    1 7 5 8 6 3 9 4 2
                                    2 8 9 7 4 1 5 3 6
                                    3 6 1 4 2 8 7 5 9
                                    9 5 2 6 3 7 1 8 4
                                    7 4 8 1 9 5 6 2 3
                                    8 9 6 3 7 4 2 1 5
                                    4 2 7 5 1 9 3 6 8
                                    5 1 3 2 8 6 4 9 7";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Nine23()
        {
            string filename = "Puzzle-9x9-0203.txt";
            string expectedResult = @"8 9 2 4 1 6 7 3 5
                                    1 6 5 3 7 2 8 9 4
                                    7 4 3 9 8 5 1 6 2
                                    9 3 4 1 2 8 6 5 7
                                    6 2 7 5 9 3 4 8 1
                                    5 8 1 7 6 4 9 2 3
                                    3 7 6 8 5 1 2 4 9
                                    2 5 9 6 4 7 3 1 8
                                    4 1 8 2 3 9 5 7 6";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine24()
        {
            string filename = "Puzzle-9x9-0204.txt";
            string expectedResult = @"4 8 6 3 7 5 1 9 2
                                    9 3 1 6 4 2 7 8 5
                                    2 7 5 9 1 8 4 6 3
                                    3 1 9 2 5 4 8 7 6
                                    8 2 7 1 6 9 5 3 4
                                    5 6 4 8 3 7 9 2 1
                                    1 9 3 5 8 6 2 4 7
                                    7 5 8 4 2 3 6 1 9
                                    6 4 2 7 9 1 3 5 8";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine25()
        {
            string filename = "Puzzle-9x9-0205.txt";
            string expectedResult = @"7 4 9 6 3 5 8 1 2
                                    8 6 5 2 9 1 7 3 4
                                    3 2 1 4 7 8 6 5 9
                                    6 3 4 5 1 2 9 7 8
                                    1 8 7 3 4 9 5 2 6
                                    9 5 2 7 8 6 3 4 1
                                    4 9 8 1 5 3 2 6 7
                                    2 7 3 9 6 4 1 8 5
                                    5 1 6 8 2 7 4 9 3";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine26()
        {
            string filename = "Puzzle-9x9-0206.txt";
            string expectedResult = @"8 2 6 9 3 5 1 4 7
                                    7 5 1 6 8 4 2 9 3
                                    3 4 9 2 1 7 5 8 6
                                    1 9 2 7 4 3 6 5 8
                                    4 6 7 5 9 8 3 1 2
                                    5 3 8 1 6 2 9 7 4
                                    6 7 3 8 5 9 4 2 1
                                    2 1 5 4 7 6 8 3 9
                                    9 8 4 3 2 1 7 6 5";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine31()
        {
            string filename = "Puzzle-9x9-0301.txt";
            string expectedResult = @"4 8 2 9 3 6 1 5 7
                                    3 6 1 2 7 5 4 9 8
                                    7 9 5 8 4 1 6 3 2
                                    9 7 6 5 8 3 2 4 1
                                    5 2 4 6 1 7 9 8 3
                                    1 3 8 4 9 2 5 7 6
                                    2 1 9 7 5 8 3 6 4
                                    6 5 7 3 2 4 8 1 9
                                    8 4 3 1 6 9 7 2 5";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine32()
        {
            string filename = "Puzzle-9x9-0302.txt";
            string expectedResult = @"1 2 3 6 4 8 5 9 7
                                    4 9 5 2 7 1 3 8 6
                                    6 7 8 3 5 9 4 2 1
                                    7 4 1 5 8 2 6 3 9
                                    2 8 9 7 6 3 1 5 4
                                    5 3 6 9 1 4 2 7 8
                                    3 1 4 8 2 7 9 6 5
                                    9 6 7 1 3 5 8 4 2
                                    8 5 2 4 9 6 7 1 3";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Nine41()
        {
            string filename = "Puzzle-9x9-0401.txt";
            string expectedResult = @"9 7 5 3 8 2 1 4 6
                                    2 8 1 4 9 6 5 3 7
                                    6 4 3 7 5 1 2 9 8
                                    8 3 4 6 7 5 9 1 2
                                    5 1 2 9 3 8 7 6 4
                                    7 9 6 2 1 4 8 5 3
                                    1 5 7 8 4 3 6 2 9
                                    4 6 9 1 2 7 3 8 5
                                    3 2 8 5 6 9 4 7 1";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }

        [TestMethod]
        public void Sixteen01()
        {
            string filename = "Puzzle-16x16-0001.txt";
            string expectedResult = @"7 1 D G A 9 E C 4 3 2 5 6 F B 8
                                    6 5 2 4 8 1 G 7 F A E B D C 3 9
                                    E 8 A B D 3 6 F 1 C G 9 2 4 5 7
                                    9 3 F C B 4 2 5 8 6 D 7 E G A 1
                                    A E 4 8 F C B 1 5 9 6 D G 3 7 2
                                    1 2 3 6 4 E 8 D A 7 C G B 9 F 5
                                    D 7 C 5 6 G 9 2 3 B F E A 8 1 4
                                    G 9 B F 7 A 5 3 2 4 8 1 C D 6 E
                                    3 B 5 A E 7 C 4 6 8 9 F 1 2 G D
                                    F G 8 D 2 6 1 9 E 5 7 A 3 B 4 C
                                    C 6 E 9 3 D A G B 2 1 4 5 7 8 F
                                    2 4 1 7 5 8 F B D G 3 C 9 6 E A
                                    8 C 9 1 G B D E 7 F A 3 4 5 2 6
                                    B A 7 E C 2 4 6 G D 5 8 F 1 9 3
                                    4 F 6 3 9 5 7 A C 1 B 2 8 E D G
                                    5 D G 2 1 F 3 8 9 E 4 6 7 A C B";
            Assert.IsTrue(TestFile(expectedResult, filename, 1));
        }
        [TestMethod]
        public void Sixteen02()
        {
            string filename = "Puzzle-16x16-0002.txt";
            PuzzleSolver solver = new PuzzleSolver(filename);
            List<Puzzle> results = solver.Solve();
            Assert.IsTrue(results.Count > 1);
        }
    }
}
