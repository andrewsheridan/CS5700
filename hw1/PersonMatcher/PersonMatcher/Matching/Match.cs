using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatcher.Matching
{
    public class Match
    {
        public int ObjectId1 { get; set; }
        public int ObjectId2 { get; set; }
        public Match(int id1, int id2) {
            ObjectId1 = id1;
            ObjectId2 = id2;
        }

        public override string ToString()
        {
            return $"{ObjectId1}, {ObjectId2}";
        }
    }
}
