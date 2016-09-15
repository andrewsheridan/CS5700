using System;
using System.Collections.Generic;
using System.IO;

namespace PersonMatcher.IO
{
    public abstract class ImportExportStrategy
    {
        protected StreamWriter Writer { get; set; }
        protected StreamReader Reader { get; set; }
        public abstract List<Person> Import(string filename);
        protected virtual bool OpenReader(string filename)
        {
            try
            {
                Reader = new StreamReader(filename);
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine($"Cannot open input file {filename}, error={err}");
                return false;
            }
        }
        protected virtual bool OpenWriter(string filename)
        {
            try
            {
                Writer = new StreamWriter(filename);
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine($"Cannot open output file {filename}, error={err}");
                return false;
            }
        }
    }
}
