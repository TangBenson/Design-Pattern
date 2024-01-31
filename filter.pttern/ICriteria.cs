namespace filter.pttern;

//過濾的標準
public interface ICriteria
{
    List<Person> MeetCriteria(List<Person> persons);
}
