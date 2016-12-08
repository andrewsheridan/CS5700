using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    public class XmlImportStrategy : ImportStrategy
    {
        public override List<Person> Import(string filename)
        {
            List<Person> personList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person), typeof(Adult), typeof(Child)});
            if (!filename.Contains(".xml"))
                throw new System.Runtime.Serialization.SerializationException();
            if (OpenReader(filename))
            {
                Reader.BaseStream.Position = 0;
                personList = serializer.Deserialize(Reader) as List<Person>;
                Reader.Close();
            } 
            else
            {
                throw new FileLoadException();
            }
            foreach(Person p in personList)
            {
                if(p.ObjectId == 0)
                    throw new System.Runtime.Serialization.SerializationException("objectId is a required field.");
            }
            return personList;
        }
    }
}
