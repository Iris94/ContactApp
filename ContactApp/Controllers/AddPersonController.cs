using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("api/persons")]
    [Produces("application/json")]
    public class AddPersonController(ContactContext context) : ControllerBase
    {
        private readonly ContactContext _context = context;

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                State = person.State,
                City = person.City,
                Sex = person.Sex,
                Birthday = person.Birthday,
                EmailAddresses = person.EmailAddresses,
                PhoneNumbers = person.PhoneNumbers
            };

            _context.Persons.Add(newPerson);
            _context.SaveChanges();
            return Ok(newPerson);
        }
    }   
}
