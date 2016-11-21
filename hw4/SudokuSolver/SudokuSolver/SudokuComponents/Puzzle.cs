using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SudokuSolver.SudokuComponents
{
    public class Puzzle
    {
        public static readonly string PuzzlesDirectory = "../../../TestPuzzles/";
        public int Size { get; private set; }
        public List<List<Cell>> Cells { get; private set; }

        public List<char> Symbols;
        public List<Row> Rows;
        public List<Column> Columns;
        public List<Block> Blocks;
        public List<string> solutions;
        
        private string _fileName;

        private int nakedSubsetCount = 0;
        private int hiddenSingleCount = 0;

        Strategies.Strategy solvingStrategy;
        

        public Puzzle(int size, List<char> symbols)
        {
            //Validate the constructor parameters
            int n = (int)Math.Sqrt(size);
            if (n * n != size) throw new ArgumentException("Size is not a squared value");
            if (size != symbols.Count) throw new ArgumentException("Incorrect number of symbols");
            if (size < 4) throw new ArgumentException("Invalid Puzzle Size");

            //Initialize the puzzle
            Symbols = symbols;
            Size = size;

            InitUnits();
            InitCells();
            LinkCellsToUnits();
        }

        public Puzzle(string filename)
       {
            _fileName = filename;
            if (!System.IO.File.Exists(PuzzlesDirectory + _fileName))
            {
                throw new System.IO.FileNotFoundException();
            }
            System.IO.StreamReader file = new System.IO.StreamReader(PuzzlesDirectory + _fileName);
            string firstLine = file.ReadLine();
            
            Size = Convert.ToInt16(firstLine);

            int n = (int)Math.Sqrt(Size);
            if (n * n != Size)
            {
                throw new FormatException("Size is not a squared value");
            }
            if (Size < 4)
            {
                throw new FormatException("Invalid Puzzle Size");
            }


            //Set up Symbols
            Symbols = new List<char>();
            string secondLine = file.ReadLine();
            foreach (char symbol in secondLine)
            {
                if (symbol != ' ')
                    Symbols.Add(symbol);
            }

            if (Symbols.Count != Size)
            {
                throw new System.IO.FileLoadException();
            }

            InitUnits();
            InitCells();
            LinkCellsToUnits();

            string nextLine = file.ReadLine();
            int rowCounter = 0;
            while (nextLine != "" && nextLine != null)
            {
                nextLine = Regex.Replace(nextLine, " ", "");

                if (nextLine.Length != Size)
                {
                    throw new System.IO.FileLoadException();
                }
                if (rowCounter >= Size)
                {
                    throw new System.IO.FileLoadException();
                }
                for (int column = 0; column < nextLine.Length; column++)
                {
                    if (!Symbols.Contains(nextLine[column]) && nextLine[column] != '-')
                    {
                        throw new System.IO.FileLoadException();
                    }
                    if (nextLine[column] != '-')
                        Cells[rowCounter][column].SetValue(nextLine[column]);

                }
                rowCounter++;
                nextLine = file.ReadLine();
            }
            file.Close();
        }

        public Puzzle(Puzzle puzzleToCopy)
        {
            Size = puzzleToCopy.Size;
            Cells = new List<List<Cell>>();
            foreach (List<Cell> list in puzzleToCopy.Cells)
            {
                List<Cell> listToAdd = new List<Cell>();
                foreach (Cell cell in list)
                {
                    Cell newCell = new Cell(cell);
                    listToAdd.Add(newCell);
                }
                Cells.Add(listToAdd);
            }

            Symbols = puzzleToCopy.Symbols;

            InitUnits();
            LinkCellsToUnits();
        }

        public void InitCells()
        {
            Cells = new List<List<Cell>>();
            for (int i = 0; i < Size; i++)
            {
                Cells.Add(new List<Cell>());
                for (int j = 0; j < Size; j++)
                {
                    Cells[i].Add(new Cell(Symbols, i, j));
                }
            }
        }

        public void InitUnits()
        {
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
        }

        public void LinkCellsToUnits()
        {
            //Initialize the cells and place them in corresponding units
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Rows[i].Add(Cells[i][j]);
                    Columns[j].Add(Cells[i][j]);
                    int blockIndex = ComputeBlockIndex(i, j, Size);
                    Blocks[blockIndex].Add(Cells[i][j]);

                    //Cells will notify the corresponding units when they are updated.
                    Cells[i][j].Subscribe(Rows[i]);
                    Cells[i][j].Subscribe(Columns[j]);
                    Cells[i][j].Subscribe(Blocks[blockIndex]);
                }
            }
        }
        

        //Sets the value of the cell to symbol, and removes symbol as a possible value from all corresponding units
        public void SetCellValue(int row, int col, char symbol)
        {
            if(IsValidInput(row, col, symbol))
                Cells[row][col].SetValue(symbol);
        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    output += Cells[i][j].SolvedValue != '\0' ? Cells[i][j].SolvedValue : '-';
                    output += ' ';
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
                throw new IndexOutOfRangeException("Invalid input parameters");
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

        /// <summary>
        /// Attempts to solve the puzzle
        /// </summary>
        //public bool Solve()
        //{
        //    while(Q.Count > 0)
        //    {
        //        Cell cell = Q[0];
        //        if (cell.SolvedValue != '\0')
        //        {
        //            Q.RemoveAt(0);
        //            continue;
        //        }
        //        Console.WriteLine($"Solving cell at [{cell.Row}, {cell.Column}] Attempts : {cell.AttemptCounter}");
        //        switch (cell.PossibleValues.Count)
        //        {
        //            case 0:
        //                Console.WriteLine("This is not a valid puzzle. No solution.");
        //                OutputSolutions(0);
        //                return false;
        //            case 1:
        //                solvingStrategy = new Strategies.SoleCandidate();
        //                Console.WriteLine("Using Sole Candidate");
        //                break;
        //            case 2:
        //                if(cell.AttemptCounter == 0)
        //                {
        //                    solvingStrategy = new Strategies.NakedSubset();
        //                    nakedSubsetCount++;
        //                    Console.WriteLine("Using Naked Subset");
        //                }
        //                else if(cell.AttemptCounter == 1)
        //                {
        //                    solvingStrategy = new Strategies.HiddenSingle();
        //                    Console.WriteLine("Using Hidden Single");
        //                    hiddenSingleCount++;
        //                }
        //                else
        //                {
        //                    solvingStrategy = new Strategies.Guess();
        //                    Console.WriteLine("Using Guess Strategy");
        //                }
        //                break;
        //        }
        //        bool reductionResult = solvingStrategy.Execute(cell, this);
        //        cell.AttemptCounter = reductionResult ? 0 : cell.AttemptCounter + 1;
        //        if (reductionResult) Console.WriteLine("Reduction result: Success.");
        //        else Console.WriteLine("Reduction result: Failed.");
        //        if (cell.SolvedValue != '\0')
        //            Q.RemoveAt(0);

        //        Q.Sort();
        //    }
        //    solutions.Add(this.ToString());
        //    OutputSolutions(solutions.Count);
        //    Console.Write(ToString());
        //    return true;
        //}

        public Cell GetCellAt(int row, int col)
        {
            return IsValidInput(row, col) ? Cells[row][col] : null;
        }

        private bool IsValidInput(int row, int col, char symbol = '\0')
        {
            if (row < 0 || col < 0 || row >= Size || col >= Size)
                throw new IndexOutOfRangeException();
            if (symbol != '\0' && !Symbols.Contains(symbol))
                throw new ArgumentException();

            return true;
        }
    }
}
