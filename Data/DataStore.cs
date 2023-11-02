using rest.Models;

namespace rest.Data;

public static class DataStore
{
    public static List<Person> PersonList = new List<Person>
    {
        new Person{Id = 1, FirstName = "Redolf"},
        new Person {Id = 2, FirstName = "Asamaning"},
        new Person{Id = 3, FirstName = "Kyle"}
    };
}