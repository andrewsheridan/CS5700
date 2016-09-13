using System.Collections;
using System.Collections.Generic;
using PersonMatcher.IO;

namespace PersonMatcher
{
    public class PersonSet : IEnumerable<Person> //Todo: Fix IEnumerable
    {
        private List<Person> _personList = new List<Person>(); 

        public ImportExportStrategy StorageStrategy { get; set; }
        

        public List<Person> Load(string filename)
        {
            _personList = StorageStrategy.Import(filename);
            return _personList;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return ((IEnumerable<Person>)_personList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Person>)_personList).GetEnumerator();
        }
    } 
}
