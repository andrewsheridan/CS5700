using SudokuSolver.SudokuComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.OutputStrategies
{
    public class SingleSolution : OutputTemplate
    {
        public SingleSolution(int size, List<char> symbols, List<Puzzle> solutions, string filename) 
            : base(size, symbols, solutions, filename) { }

        public override string Solutions()
        {
            return _solutions[0].ToString();
        }

        public override string SuccessState()
        {
            return "";
        }
    }
}
