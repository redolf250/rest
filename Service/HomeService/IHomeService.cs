using rest.Models;

namespace rest.Service
{
    public interface IHomeService
    {
        List<Person> GetListOfPersons();
        Person GetPersonById(int id);
        List<Person> AddPerson(Person person);

        List<Person> DeletePerson(int id);

        List<Person> UpdatePerson(int id, Person person);
    }
}