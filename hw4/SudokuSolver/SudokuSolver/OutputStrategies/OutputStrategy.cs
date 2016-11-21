using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.OutputStrategies
{
    public abstract class OutputTemplate
    {
        public abstract string SuccessState();
        public abstract string Size();
        public abstract string Symbols();
        public abstract string Solutions();

        public void OutputToFile(string filename)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);
            writer.Write(SuccessState());
            writer.Write(Size());
            writer.Write(Symbols());
            writer.Write(Solutions());
            writer.Close();
        }
    }
}
