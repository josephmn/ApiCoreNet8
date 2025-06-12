using ApiCoreNet8.Models;
using ApiCoreNet8.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCoreNet8.Controller
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            try
            {
                var persons = _personService.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            try
            {
                var person = _personService.GetById(id);
                if (person == null)
                {
                    return NotFound($"Person with ID {id} not found.");
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Person> Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person object is null.");
            }
            try
            {
                var createdPerson = _personService.Create(person);
                return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id }, createdPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Person> Update(int id, [FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person object is null.");
            }
            try
            {
                var updatedPerson = _personService.Update(id, person);
                if (updatedPerson == null)
                {
                    return NotFound($"Person with ID {id} not found.");
                }
                return Ok(updatedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _personService.Delete(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
