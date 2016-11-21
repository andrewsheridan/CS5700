using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.SudokuComponents
{
    public class PuzzleSolver
    {
        List<Cell> Q;
        List<Puzzle> revertStates;
        Puzzle currentPuzzle;
        int _size;
        List<char> _symbols;
        List<Puzzle> solutions;
        int _hiddenSingleCount = 0;
        int _nakedSubsetCount = 0;
        Strategies.Strategy _strategy;
        string _filepath;
        static readonly string OutputDirectory = "../../../../Output/";

        public PuzzleSolver(string filename)
        {
            try
            {
                currentPuzzle = new Puzzle(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not create puzzle. {e.Message}");
                OutputSolutions(-1);
                throw e;
            }
            
            _size = currentPuzzle.Size;
            _symbols = currentPuzzle.Symbols;
            InitQueue();
            revertStates = new List<Puzzle>();
            solutions = new List<Puzzle>();
        }

        PuzzleSolver(Puzzle p)
        {
            currentPuzzle = p;
            _size = p.Size;
            _symbols = p.Symbols;
            InitQueue();
            revertStates = new List<Puzzle>();
            solutions = new List<Puzzle>();
        }
        
        //Todo: Output strategies.
        public bool Solve()
        { 
            while (Q.Count > 0)
            {
                Cell cell = Q[0];
                if (cell.SolvedValue != '\0')
                {
                    Q.RemoveAt(0);
                    continue;
                }
                Console.WriteLine($"Solving cell at [{cell.Row}, {cell.Column}] Attempts : {cell.AttemptCounter}");
                switch (cell.PossibleValues.Count)
                {
                    case 0:
                        Console.WriteLine("This is not a valid puzzle. No solution.");
                        //OutputSolutions(0);
                        if (revertStates.Count > 0)
                        {
                            currentPuzzle = revertStates[revertStates.Count - 1];
                            revertStates.RemoveAt(revertStates.Count - 1);
                            InitQueue();
                            break;
                        }
                        else return false;
                    case 1:
                        _strategy = new Strategies.SoleCandidate();
                        Console.WriteLine("Using Sole Candidate");
                        break;
                    case 2:
                        if (cell.AttemptCounter == 0)
                        {
                            _strategy = new Strategies.NakedSubset();
                            _nakedSubsetCount++;
                            Console.WriteLine("Using Naked Subset");
                        }
                        else if (cell.AttemptCounter == 1)
                        {
                            _strategy = new Strategies.HiddenSingle();
                            Console.WriteLine("Using Hidden Single");
                            _hiddenSingleCount++;
                        }
                        else
                        {
                            Puzzle revertState = new Puzzle(currentPuzzle);
                            char guess = CellGuess(cell);
                            revertState.Cells[cell.Row][cell.Column].GuessedValues.Add(guess);
                            revertState.Cells[cell.Row][cell.Column].PossibleValues.Remove(guess);
                            revertStates.Add(revertState);
                            Console.WriteLine($"Made a guess: {guess}");
                        }
                        break;
                }
                bool reductionResult = _strategy.Execute(cell, currentPuzzle);
                cell.AttemptCounter = reductionResult ? 0 : cell.AttemptCounter + 1;
                if (reductionResult) Console.WriteLine("Reduction result: Success.");
                else Console.WriteLine("Reduction result: Failed.");
                if (cell.SolvedValue != '\0')
                    Q.RemoveAt(0);

                Q.Sort();
            }
            solutions.Add(currentPuzzle);
            //OutputSolutions(solutions.Count);
            Console.Write(currentPuzzle.ToString());
            return true;
        }
        private void InitQueue()
        {
            Q = new List<Cell>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (currentPuzzle.Cells[i][j].SolvedValue == '\0')
                    {
                        int key = i * _size + j;
                        Q.Add(currentPuzzle.Cells[i][j]);
                    }
                }
            }
            Q.Sort();
        }

        private void OutputSolutions(int solutionCount)
        {
            string outputFileName = OutputDirectory + _filepath;
            outputFileName = outputFileName.Replace(".txt", "-output.txt");
            string output = "";
            System.IO.StreamReader reader;
            switch (solutionCount)
            {
                case -1:
                    output += "Bad Puzzle" + Environment.NewLine;
                    reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filepath);
                    output += reader.ReadToEnd();
                    break;
                case 0:
                    output += "Unsolvable" + Environment.NewLine;
                    reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filepath);
                    output += reader.ReadToEnd();
                    break;
                case 1:
                    output += _size + Environment.NewLine;
                    foreach (char symbol in _symbols)
                        output += symbol + " ";
                    output += Environment.NewLine;
                    output += this.ToString();
                    break;
                default:
                    reader = new System.IO.StreamReader(Puzzle.PuzzlesDirectory + _filepath);
                    output += reader.ReadToEnd();
                    output += "Multiple Solutions";
                    output += solutions[0];
                    output += solutions[1];
                    break;
            }
            System.IO.File.WriteAllText(outputFileName, output);
        }
        //Outputs the current state of the Queue
        public void PrintQueue()
        {
            for (int i = 0; i < Q.Count; i++)
            {
                Cell cell = Q[i];
                Console.WriteLine($"[{cell.Row}][{cell.Column}]: {cell.GetPossibleValueCount()}");
            }
        }

        char CellGuess(Cell cell)
        {
            if (cell.PossibleValues.Count < 2) return '\0';

            char guess = cell.PossibleValues[0];
            cell.GuessedValues.Add(guess);
            cell.SetValue(guess);
            return guess;
        }
    }
}
