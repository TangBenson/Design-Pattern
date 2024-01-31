namespace filter.pttern;

//過濾的對象
public class Person
{

    private readonly string name;
    private readonly string gender;
    private readonly string maritalStatus;

    public Person(string name, string gender, string maritalStatus)
    {
        this.name = name;
        this.gender = gender;
        this.maritalStatus = maritalStatus;
    }

    public string GetName()
    {
        return name;
    }
    public string GetGender()
    {
        return gender;
    }
    public string GetMaritalStatus()
    {
        return maritalStatus;
    }
}
