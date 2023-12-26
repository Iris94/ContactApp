using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("api/persons")]
    [Produces("application/json")]
    public class EditPersonController(ContactContext contactContext) : ControllerBase
    {
        private readonly ContactContext _contactContext = contactContext;

        [HttpGet("{personID}")]
        public IActionResult GetPerson (int personID)
        {
            var person = _contactContext.Persons
                .Include(p => p.PhoneNumbers)
                .Include(e => e.EmailAddresses)
                .FirstOrDefault(p => p.PersonID ==  personID);

            if (person == null)
            {
                return NotFound();
            }

            var response = new
            {
                person.FirstName,
                person.LastName,
                person.Sex,
                person.Birthday,
                person.State,
                person.City,
                PhoneNumbers = person.PhoneNumbers.Select(p => p.Phone).ToList(),
                EmailAddresses = person.EmailAddresses.Select(e => e.Email).ToList()
            };

            return Ok(response);
        }



        [HttpPatch("{personID}")]
        public IActionResult UpdatePerson (int personID, 
        [FromBody] Person updatedPerson)
        {
            var existingPerson = _contactContext.Persons
                .Include(p => p.PhoneNumbers)
                .Include(e => e.EmailAddresses)
                .FirstOrDefault(p => p.PersonID == personID);

            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.FirstName = updatedPerson.FirstName;
            existingPerson.LastName = updatedPerson.LastName;
            existingPerson.Birthday = updatedPerson.Birthday;
            existingPerson.Sex = updatedPerson.Sex;
            existingPerson.State = updatedPerson.State;
            existingPerson.City = updatedPerson.City;
            existingPerson.PhoneNumbers.Clear();
            existingPerson.PhoneNumbers.AddRange(updatedPerson.PhoneNumbers);
            existingPerson.EmailAddresses.Clear();
            existingPerson.EmailAddresses.AddRange(updatedPerson.EmailAddresses);

            _contactContext.SaveChanges();

            var response = new
            {
                existingPerson.FirstName,
                existingPerson.LastName,
                existingPerson.Sex,
                existingPerson.Birthday,
                existingPerson.State,
                existingPerson.City,
                PhoneNumbers = existingPerson.PhoneNumbers.Select(p => p.Phone).ToList(),
                EmailAddresses = existingPerson.EmailAddresses.Select(e => e.Email).ToList()
            };

            return Ok(response);

        }
    }
}
