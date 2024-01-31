using filter.pttern;

List<Person> persons = new()
{
    new Person("Robert", "Male", "Single"),
    new Person("John", "Male", "Married"),
    new Person("Laura", "Female", "Married"),
    new Person("Diana", "Female", "Single"),
    new Person("Mike", "Male", "Single"),
    new Person("Bobby", "Male", "Single")
};

ICriteria male = new CriteriaMale();
ICriteria female = new CriteriaFemale();
ICriteria single = new CriteriaSingle();
ICriteria singleMale = new AndCriteria(single, male);
ICriteria singleOrFemale = new OrCriteria(single, female);

Console.WriteLine("Males: ");
PrintPersons(male.MeetCriteria(persons));

Console.WriteLine("\nFemales: ");
PrintPersons(female.MeetCriteria(persons));

Console.WriteLine("\nSingle Males: ");
PrintPersons(singleMale.MeetCriteria(persons));

Console.WriteLine("\nSingle Or Females: ");
PrintPersons(singleOrFemale.MeetCriteria(persons));


static void PrintPersons(List<Person> persons)
{
    foreach (Person person in persons)
    {
        Console.WriteLine("Person : [ Name : " + person.GetName()
           + ", Gender : " + person.GetGender()
           + ", Marital Status : " + person.GetMaritalStatus()
           + " ]");
    }
}