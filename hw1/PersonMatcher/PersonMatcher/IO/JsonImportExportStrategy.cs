using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace PersonMatcher.IO
{
    public class JsonImportExportStrategy : ImportExportStrategy
    {

        public override List<Person> Import(string filename)
        {
            List<Person> personList = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });
            if (OpenReader(filename))
            {
                Reader.BaseStream.Position = 0;
                personList = serializer.ReadObject(Reader.BaseStream) as List<Person>;
                Reader.Close();
            }
            return personList;
        }
    }
}
