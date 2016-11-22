using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver.OutputStrategies
{
    public class MultipleSolutions : OutputTemplate
    {
        public MultipleSolutions(int size, List<char> symbols, List<Puzzle> solutions, string filename) : base(size, symbols, solutions, filename)
        {
        }

        public override string Solutions()
        {
            string output = "";
            foreach(Puzzle p in _solutions)
                output += p.ToString();
            return output;
        }

        public override string SuccessState()
        {
            return "Multiple Solutions" + Environment.NewLine;
        }
    }
}
