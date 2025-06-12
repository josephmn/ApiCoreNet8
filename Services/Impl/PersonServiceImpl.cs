using ApiCoreNet8.Models;
using ApiNetCore.Data;

namespace ApiCoreNet8.Services.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public List<Person> GetAll()
        {
            List<Person> person = new List<Person>();
            person = _context.Person.ToList();
            if (person.Count == 0)
            {
                throw new NotImplementedException("No personas available.");
            }
            return person; // Return the static list of personas
        }
        public Person GetById(int id)
        {
            throw new NotImplementedException();
            //var persona = _persons.FirstOrDefault(p => p.Id == id);
            //if (persona == null)
            //{
            //    throw new NotImplementedException("No personas available.");
            //}
            //return persona; // Return the persona with the specified ID
        }
        public Person Create(Person person)
        {
            throw new NotImplementedException();
            //person.Id = _persons.Max(p => p.Id) + 1; // Assign a new ID based on the max existing ID
            //_persons.Add(person); // Add the new persona to the list

            //return person; // Return the saved persona
        }
        public Person Update(int id, Person person)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
