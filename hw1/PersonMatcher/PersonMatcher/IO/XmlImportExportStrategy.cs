using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    class XmlImportExportStrategy : ImportExportStrategy
    {
        public override List<Person> Import(string filename)
        {
            List<Person> personList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person)/*, typeof(Adult), typeof(Child)*/});
            if (OpenReader(filename))
            {
                Reader.BaseStream.Position = 0;
                personList = serializer.Deserialize(Reader.BaseStream) as List<Person>;
                Reader.Close();
            }
            return personList;
        }
    }
}
