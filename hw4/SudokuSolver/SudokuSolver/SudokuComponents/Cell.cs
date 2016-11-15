using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Cell
    {
        //Public Variables
        public List<char> PossibleValues;
        public char SolvedValue;

        //Public Member Functions
        public Cell(List<char> symbols)
        {
            PossibleValues = new List<char>();
            PossibleValues = symbols;
        }

        void RemovePossibleValue(char value)
        {
            PossibleValues.Remove(value);
        }

        public void SetValue(char value)
        {
            SolvedValue = value;
            PossibleValues.Clear();
        }
    }
}
