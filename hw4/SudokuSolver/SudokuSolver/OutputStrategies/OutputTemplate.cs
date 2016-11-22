using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.SudokuComponents;

namespace SudokuSolver.OutputStrategies
{
    public abstract class OutputTemplate
    {
        static readonly string OutputDirectory = "../../../../Output/";
        protected int _size;
        protected List<char> _symbols;
        protected List<Puzzle> _solutions;
        protected string _filename;
        public OutputTemplate(int size, List<char> symbols, List<Puzzle> solutions, string filename)
        {
            _size = size;
            _symbols = symbols;
            _solutions = solutions;
            _filename = filename;
        }
        public abstract string SuccessState();
        public virtual string Size()
        {
            return Convert.ToString(_size);
        }
        
        public virtual string Symbols()
        {
            string output = "";
            foreach (char symbol in _symbols)
                output += symbol + " ";
            return output;
        }
        public abstract string Solutions();

        public void OutputToFile()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(OutputDirectory + _filename);
            writer.WriteLine(SuccessState());
            writer.WriteLine(_size);
            writer.WriteLine(Symbols());
            writer.Write(Solutions());
            writer.Close();
            Console.WriteLine(SuccessState());
            Console.WriteLine(_size);
            Console.WriteLine(Symbols());
            Console.Write(Solutions());
        }
    }
}
