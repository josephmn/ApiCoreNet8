using ApiCoreNet8.Models;
using ApiNetCore.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            try
            {
                var person = _context.Person.FirstOrDefault(p => p.Id == id);

                if (person == null)
                {
                    throw new KeyNotFoundException($"Person with ID {id} not found.");
                }

                return person;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Person.Add(person);

                int result = _context.SaveChanges();

                if (result == 0)
                {
                    throw new Exception("No se pudo guardar la persona en la base de datos.");
                }

                return person;
            }
            catch (DbUpdateException dbEx)
            {
                // Error a nivel de base de datos (restricciones, claves foráneas, etc.)
                throw new Exception("Error al guardar en la base de datos: " + dbEx.Message, dbEx);
            }
            catch (Exception ex)
            {
                // Otro tipo de errores
                throw new Exception("Error inesperado al crear la persona: " + ex.Message, ex);
            }
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
