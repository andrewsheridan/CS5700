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
        public int Row { get; }
        public int Column { get; }

        //Public Member Functions
        public Cell(List<char> symbols, int row, int col)
        {
            Row = row;
            Column = col;
            PossibleValues = new List<char>();
            PossibleValues.AddRange(symbols);
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
