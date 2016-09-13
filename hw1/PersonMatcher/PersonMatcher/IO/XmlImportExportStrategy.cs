using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PersonMatcher.IO
{
    class XmlImportExportStrategy : ImportExportStrategy
    {
        public override void Export(string filename, List<Person> personList)
        {
            throw new NotImplementedException();
        }

        public override List<Person> Import(string filename)
        {
            List<Person> personList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Person)/*, typeof(Adult), typeof(Child)*/});
            if (OpenReader(filename))
            {
                personList = serializer.Deserialize(Reader) as List<Person>;
                Reader.Close();
            }
            return personList;
        }
    }
}
