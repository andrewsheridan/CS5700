using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Cell : Subject, IComparable<Cell>
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

        public bool SetValue(char value)
        {
            if (SolvedValue != '\0')
                return false;
            SolvedValue = value;
            PossibleValues.Clear();
            Notify(value);
            return true;
        }

        public int GetPossibleValueCount()
        {
            return PossibleValues.Count;
        }

        public int CompareTo(Cell obj)
        {
            int myCount = GetPossibleValueCount();
            int objCount = obj.GetPossibleValueCount();
            if (myCount < objCount)
                return -1;
            else if (myCount > objCount)
                return 1;
            else
                return 0;
        }
    }
}
