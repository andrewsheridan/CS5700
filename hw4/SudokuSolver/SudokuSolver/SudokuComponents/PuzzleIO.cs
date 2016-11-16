using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SudokuSolver.SudokuComponents
{
    public static class PuzzleIO
    {
        static public Puzzle LoadFromFile(string filename)
        {
            int size;
            List<char> symbols =  new List<char>();

            if (!System.IO.File.Exists(filename))
            {
                Console.WriteLine("File Does Not Exist");
                return null;
            }

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            string firstLine = file.ReadLine();
            //Todo: Make sure this doesn't throw anything
            size = Convert.ToInt16(firstLine);

            string secondLine = file.ReadLine();
            foreach (char symbol in secondLine)
            {
                if (symbol != ' ') 
                    symbols.Add(symbol);
            }

            if(symbols.Count != size)
            {
                Console.WriteLine("Bad File -- Incorrect number of symbols specified");
                return null;
            }
            //Initialize Puzzle with Size and Symbol Set
            Puzzle newPuzzle = new Puzzle(size, symbols);

            string nextLine = file.ReadLine();
            int rowCounter = 0;
            while (nextLine != "" && nextLine != null)
            {
                nextLine = Regex.Replace(nextLine, " ", "");
                
                if (nextLine.Length != size)
                {
                    Console.WriteLine("Bad File -- Invalid Row Found");
                    return null;
                }
                if (rowCounter >= size)
                {
                    Console.WriteLine("Bad File -- Too Many Columns");
                    return null;
                }
                for(int column = 0; column < nextLine.Length; column++)
                {
                    if (!symbols.Contains(nextLine[column]) && nextLine[column] != '-')
                    {
                        Console.WriteLine("Bad File -- Invalid Cell Value");
                        return null;
                    }
                    if(nextLine[column] != '-')
                        newPuzzle.UpdateCell(rowCounter, column, nextLine[column]);
                }
                rowCounter++;
                nextLine = file.ReadLine();
            }

            return newPuzzle;
        }
    }
}
