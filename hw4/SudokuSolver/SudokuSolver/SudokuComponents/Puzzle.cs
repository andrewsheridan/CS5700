using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Puzzle
    {
        int Size;
        
        List<char> Symbols;
        List<List<Cell>> Cells;
        List<Row> Rows;
        List<Column> Columns;
        List<Block> Blocks;

        public Puzzle(int size, List<char> symbols)
        {
            //Validate the constructor parameters
            int n =(int) Math.Sqrt(size);
            if (n * n != size) throw new ArgumentException("Size is not a squared value");
            if (size != symbols.Count) throw new ArgumentException("Incorrect number of symbols");
            if (size < 4) throw new ArgumentException("Invalid Puzzle Size");

            //Initialize the puzzle
            Symbols = symbols;
            Size = size;

            Cells = new List<List<Cell>>();
            Rows = new List<Row>();
            Blocks = new List<Block>();
            Columns = new List<Column>();
            for (int i = 0; i < Size; i++)
            {
                Row newRow = new Row(Symbols);
                Rows.Add(newRow);
                Column newCol = new SudokuSolver.Column(Symbols);
                Columns.Add(newCol);
                Block newBlock = new Block(Symbols);
                Blocks.Add(newBlock);
            }

            //Initialize the cells and place them in corresponding units
            for (int i = 0; i < Size; i++)
            {
                Cells.Add(new List<Cell>());
                for (int j = 0; j < Size; j++)
                {
                    Cells[i].Add(new Cell(symbols, i, j));
                    Rows[i].Add(Cells[i][j]);
                    Columns[j].Add(Cells[i][j]);
                    Blocks[ComputeBlockIndex(i, j, Size)].Add(Cells[i][j]);
                }
            }
        
        }

        //Sets the value of the cell to symbol, and removes symbol as a possible value from all corresponding units
        public bool UpdateCell(int row, int col, char symbol)
        {
            Cells[row][col].SetValue(symbol);
            Rows[row].RemovePossibleValueFromCells(symbol);
            Columns[col].RemovePossibleValueFromCells(symbol);
            Blocks[ComputeBlockIndex(row, col, Size)].RemovePossibleValueFromCells(symbol);
            
            return true;
        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    output += Cells[i][j].SolvedValue != '0' ? Cells[i][j].SolvedValue : '-';
                }
                output += Environment.NewLine;
            }

            return output;
        }

        //Computes the index of the block found at row "row", column "col", and with puzzle size "size"
        public static int ComputeBlockIndex(int row, int col, int size)
        {
            int n = (int)Math.Sqrt(size);
            if (n * n != size)
                throw new ArgumentException("Size is not a perfect square");
            if (row < 0 || col < 0 || row >= size || col >= size || size < 1)
                throw new ArgumentException("Invalid input parameters");
            int returnValue = (row / n) * n + (col / n);
            return returnValue;
        }
    }
}
