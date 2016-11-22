using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver.OutputStrategies
{
    public class Unsolvable : OutputTemplate
    {
        public Unsolvable(int size, List<char> symbols, List<Puzzle> solutions, string filename) : base(size, symbols, solutions, filename)
        {

        }

        public override string SuccessState()
        {
            return "Unsolvable" + Environment.NewLine;
        }
        public override string Size()
        {
            return "";
        }

        public override string Symbols()
        {
            return "";
        }

        public override string Solutions()
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filename);
            return reader.ReadToEnd();
        }
    }
    //private void OutputSolutions(int solutionCount)
    //{
    //    string outputFileName = OutputDirectory + _filename;
    //    outputFileName = outputFileName.Replace(".txt", "-output.txt");
    //    string output = "";
    //    System.IO.StreamReader reader;
    //    switch (solutionCount)
    //    {
    //        case -1:
    //            output += "Bad Puzzle" + Environment.NewLine;
    //            reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filename);
    //            output += reader.ReadToEnd();
    //            break;
    //        case 0:
    //            output += "Unsolvable" + Environment.NewLine;
    //            reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filename);
    //            output += reader.ReadToEnd();
    //            break;
    //        case 1:
    //            output += _size + Environment.NewLine;
    //            foreach (char symbol in _symbols)
    //                output += symbol + " ";
    //            output += Environment.NewLine;
    //            output += this.ToString();
    //            break;
    //        default:
    //            reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filename);
    //            output += reader.ReadToEnd();
    //            output += "Multiple Solutions";
    //            output += solutions[0];
    //            output += solutions[1];
    //            break;
    //    }
    //    System.IO.File.WriteAllText(outputFileName, output);
    //}
}
