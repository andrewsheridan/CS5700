using System.Collections;
using System.Collections.Generic;
using PersonMatcher.IO;

namespace PersonMatcher
{
    public class PersonSet : IEnumerable<Person> //Todo: Fix IEnumerable
    {
        private List<Person> _personList = new List<Person>(); 

        public ImportExportStrategy StorageStrategy { get; set; }
        
        public void Add(Person person)
        {
            if (person != null)
            {
                _personList.Add(person);
            }
        }

        public List<Person> Import(string filename)
        {
            _personList = StorageStrategy.Import(filename);
            return _personList;
        }

        public void Export(string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && StorageStrategy != null)
                StorageStrategy.Export(filename, _personList);
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

    public class PersonEnum : IEnumerator
    {
        private readonly Person[] _persons;
        private int _currentPosition = -1;

        public PersonEnum(Person[] persons)
        {
            _persons = persons;
        }

        public bool MoveNext()
        {
            return (++_currentPosition < _persons.Length);
        }

        public void Reset()
        {
            _currentPosition = -1;
        }

        object IEnumerator.Current { get { return Current; } }

        public Person Current
        {
            get
            {
                return (_currentPosition >= 0 && _currentPosition < _persons.Length) ? _persons[_currentPosition] : null;
            }
        }
    }
}
