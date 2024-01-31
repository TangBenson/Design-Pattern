using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filter.pttern
{
    public class CriteriaSingle : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new();
            foreach (Person person in persons)
            {
                if (person.GetMaritalStatus().ToUpper().Equals("Single".ToUpper()))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }
}