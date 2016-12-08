using System;
using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public class BirthInfoMatchStrategy : MatchStrategy
    {
        public bool Match(DataObjects.Person a, DataObjects.Person b)
        {
            if (a.GetType() == typeof(Child) && b.GetType() == typeof(Child))
            {
                return Match(a as Child, b as Child);
            }
            else return false;
        }

        private bool Match(Child a, Child b)
        {
            if (a.NewbornScreeningNumber == b.NewbornScreeningNumber)
            {
                if (String.IsNullOrEmpty(a.IsPartOfMultipleBirth) && String.IsNullOrEmpty(b.IsPartOfMultipleBirth))
                {
                    return true;
                }
                else
                {
                    if (a.IsPartOfMultipleBirth == b.IsPartOfMultipleBirth)
                    {
                        if (a.BirthOrder == b.BirthOrder)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
            }

            else return false;
        }
    }
}
