using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    public class JsonImportStrategy : ImportStrategy
    {

        public override List<Person> Import(string filename)
        {
            List<Person> personList = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child) });
            if (!filename.Contains(".json"))
                throw new System.Runtime.Serialization.SerializationException();
            if (OpenReader(filename))
            {
                Reader.BaseStream.Position = 0;
                personList = serializer.ReadObject(Reader.BaseStream) as List<Person>;
                foreach (Person p in personList)
                {
                    if (p.ObjectId == 0)
                        throw new System.Runtime.Serialization.SerializationException("objectId is a required field.");
                }
                Reader.Close();
            }
            return personList;
        }
    }
}
