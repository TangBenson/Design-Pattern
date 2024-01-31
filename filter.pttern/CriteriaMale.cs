using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filter.pttern
{
    public class CriteriaMale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new();
            foreach (Person person in persons)
            {
                if (person.GetGender().ToUpper().Equals("Male".ToUpper()))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }
}