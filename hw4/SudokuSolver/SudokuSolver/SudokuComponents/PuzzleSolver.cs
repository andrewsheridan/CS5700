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
        OutputStrategies.OutputTemplate _outputTemplate;
        string _filename;

        public PuzzleSolver(string filename)
        {
            _filename = filename;
            try
            {
                currentPuzzle = new Puzzle(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not create puzzle. {e.Message}");
                _outputTemplate = new OutputStrategies.BadPuzzle(_size, _symbols, null, _filename);
                _outputTemplate.OutputToFile();
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
        
        public List<Puzzle> Solve()
        {
            int loopCount = 0;
            bool shouldExit = false;
            while (!shouldExit)
            {
                loopCount++;
                Console.WriteLine(loopCount);
                if (Q.Count == 0)
                {
                    solutions.Add(currentPuzzle);
                    if (!Revert() || solutions.Count > 2)
                        shouldExit = true;
                    continue;
                }

                Cell cell = Q[0];
                if (cell.SolvedValue != '\0')
                {
                    Q.RemoveAt(0);
                    continue;
                }
                
                switch (cell.PossibleValues.Count)
                {
                    case 0:
                        if (!Revert())
                            shouldExit = true;
                        continue;
                    case 1:
                        _strategy = new Strategies.SoleCandidate();
                        break;
                    default:
                        if (cell.AttemptCounter == 0)
                        {
                            _strategy = new Strategies.NakedSubset();
                            _nakedSubsetCount++;
                        }
                        else if (cell.AttemptCounter == 1)
                        {
                            _strategy = new Strategies.HiddenSingle();
                            _hiddenSingleCount++;
                        }
                        else
                        {
                            Puzzle revertState = new Puzzle(currentPuzzle);
                            char guess = CellGuess(cell);
                            revertState.Cells[cell.Row][cell.Column].GuessedValues.Add(guess);
                            revertState.Cells[cell.Row][cell.Column].PossibleValues.Remove(guess);
                            revertState.Cells[cell.Row][cell.Column].AttemptCounter = 0;
                            revertStates.Add(revertState);
                        }
                        break;
                }
                bool reductionResult = _strategy.Execute(cell, currentPuzzle);
                cell.AttemptCounter = reductionResult ? 0 : cell.AttemptCounter + 1;
                if (cell.SolvedValue != '\0')
                    Q.RemoveAt(0);

                Q.Sort();
            }
            switch (solutions.Count)
            {
                case 0:
                    _outputTemplate = new OutputStrategies.Unsolvable(_size, _symbols, null, _filename);
                    break;
                case 1:
                    _outputTemplate = new OutputStrategies.SingleSolution(_size, _symbols, solutions, _filename);
                    break;
                default:
                    _outputTemplate = new OutputStrategies.MultipleSolutions(_size, _symbols, solutions, _filename);
                    break;
            }
            _outputTemplate.OutputToFile();
            return solutions;
        }
        private void InitQueue()
        {
            Q = new List<Cell>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (currentPuzzle.Cells[i][j].SolvedValue == '\0')
                        Q.Add(currentPuzzle.Cells[i][j]);
                }
            }
            Q.Sort();
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

        bool Revert()
        {
            if(revertStates.Count > 0)
            {
                //Console.WriteLine("Before Guess:");
                //Console.Write(revertStates[0].ToString());
                //Console.WriteLine("After Guess:");
                //Console.Write(currentPuzzle.ToString());
                //Console.WriteLine("-------Reverting--------");
            }
            
            if (revertStates.Count == 0)
                return false;
            currentPuzzle = revertStates[revertStates.Count - 1];
            revertStates.RemoveAt(revertStates.Count - 1);
            InitQueue();
            return true;
        }
    }
}
