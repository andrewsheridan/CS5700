using System;
using System.Collections;
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
        SortedList Q;

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
                    int blockIndex = ComputeBlockIndex(i, j, size);
                    Blocks[blockIndex].Add(Cells[i][j]);

                    //Cells will notify the corresponding units when they are updated.
                    Cells[i][j].Subscribe(Rows[i]);
                    Cells[i][j].Subscribe(Columns[j]);
                    Cells[i][j].Subscribe(Blocks[blockIndex]);
                }
            }
        }
        
        public void InitQueue()
        {
            Q = new SortedList();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Cells[i][j].SolvedValue == '\0')
                    {
                        int key = i * Size + j;
                        Q.Add(key, Cells[i][j]);
                    }
                        
                }
            }
        }

        //Sets the value of the cell to symbol, and removes symbol as a possible value from all corresponding units
        public bool UpdateCell(int row, int col, char symbol)
        {
            Cells[row][col].SetValue(symbol);
            //Rows[row].RemovePossibleValueFromCells(symbol);
            //Columns[col].RemovePossibleValueFromCells(symbol);
            //Blocks[ComputeBlockIndex(row, col, Size)].RemovePossibleValueFromCells(symbol);
            
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

        //Outputs the possible values for each cell in the puzzle
        public void PrintPossibleValues()
        {
            for(int row = 0; row < Size; row++)
            {
                for(int column = 0; column < Size; column++)
                {
                    string possibleCharacters = "";
                    foreach (char value in Cells[row][column].PossibleValues)
                        possibleCharacters += value;
                    Console.WriteLine($"[{row}][{column}]: {possibleCharacters}");
                }
            }
        }

        //Outputs the current state of the Queue
        public void PrintQueue()
        {
            for(int i = 0; i < Q.Count; i++)
            {
                int key = (int)Q.GetKey(i);
                int row = key / Size;
                int column = key % Size;
                Cell cell = Q.GetByIndex(i) as Cell;
                Console.WriteLine($"[{row}][{column}]: {cell.GetPossibleValueCount()}");
            }
        }
    }
}
