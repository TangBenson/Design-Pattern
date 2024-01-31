using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filter.pttern
{
    public class CriteriaFemale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new();
            foreach (Person person in persons)
            {
                if (person.GetGender().ToUpper().Equals("Female".ToUpper()))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }
}