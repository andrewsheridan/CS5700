using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public abstract class Unit : List<Cell>
    {
        public Unit(List<char> symbols)
        {
            PossibleValues = new List<char>();
            PossibleValues.AddRange(symbols);
        }
        List<char> PossibleValues;
    }
}
