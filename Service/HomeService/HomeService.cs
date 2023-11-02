using rest.Data;
using rest.Models;

namespace rest.Service.HomeService;

public class HomeService : IHomeService
{
    public List<Person> GetListOfPersons()
    {
        return DataStore.PersonList;
    }

    public Person GetPersonById(int id)
    {
        var person = DataStore.PersonList.Find(person => person.Id==id);
        if (person is null)
            return null;
        return person;
    }

    public List<Person> AddPerson(Person person)
    {
        Console.WriteLine(person);
        DataStore.PersonList.Add(person);
        return DataStore.PersonList;
    }

    public List<Person> DeletePerson(int id)
    {
        var person = DataStore.PersonList.Find(person => person.Id==id);
        if (person is null)
            return null;
        DataStore.PersonList.Remove(person);
        return DataStore.PersonList;
    }

    public List<Person> UpdatePerson(int id, Person person)
    {
        throw new NotImplementedException();
    }
}