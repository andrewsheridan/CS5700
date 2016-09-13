using PersonMatcher.IO;
using System.Collections.Generic;

namespace PersonMatcher
{
    public class PersonMatcher
    {
        private PersonSet personSet;
        public ImportExportStrategy StorageStrategy { get; set; }

        public List<Person> Import(string inputFileName)
        {
            personSet = new PersonSet();
            personSet.StorageStrategy = StorageStrategy;
            return personSet.Load(inputFileName);
        }

        public void Run()
        {
            personSet.StorageStrategy = StorageStrategy;
        }
    }
}
