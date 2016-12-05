using System;
using System.Collections.Generic;
using System.IO;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    public abstract class ImportStrategy
    {
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
    }
}
