using ApiCoreNet8.Models;

namespace ApiCoreNet8.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person GetById(int id);
        Person Create(Person person);
        Person Update(int id, Person person);
        void Delete(int id);
    }
}
