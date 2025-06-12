using ApiCoreNet8.Models;

namespace ApiCoreNet8.Services.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        private static List<Person> _persons = new List<Person>
        {
            new Person {
                Id = 1,
                Document = "11111111",
                Name = "Jorge",
                LastName ="Perez",
                Age = 25,
                DateBirthday = DateTime.Parse("2000-04-12"),
                Email = "jperez@gmail.com",
                Status = 1
            },
            new Person {
                Id = 2,
                Document = "22222222",
                Name = "Eduardo",
                LastName ="Gomez",
                Age = 24,
                DateBirthday = DateTime.Parse("2001-06-10"),
                Email = "eduardo.gom@gmail.com",
                Status = 1
            },
        };

        public List<Person> GetAll()
        {
            if (_persons == null || !_persons.Any())
            {
                throw new NotImplementedException("No personas available.");
            }
            return _persons; // Return the static list of personas
        }
        public Person GetById(int id)
        {
            var persona = _persons.FirstOrDefault(p => p.Id == id);
            if (persona == null)
            {
                throw new NotImplementedException("No personas available.");
            }
            return persona; // Return the persona with the specified ID
        }
        public Person Create(Person person)
        {
            person.Id = _persons.Max(p => p.Id) + 1; // Assign a new ID based on the max existing ID
            _persons.Add(person); // Add the new persona to the list

            return person; // Return the saved persona
            //throw new NotImplementedException();
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
