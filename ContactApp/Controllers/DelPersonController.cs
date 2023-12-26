using ContactApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("api/persons")]
    [Produces("application/json")]

    public class DelPersonController (ContactContext contactContext) : ControllerBase
    {
        private readonly ContactContext _contactContext = contactContext;


        [HttpDelete("{personID}")]
        public IActionResult DeletePerson(int personID)
        {
            var person = _contactContext.Persons.Find(personID);

            if (person == null)
            {
                return NotFound();
            }

            _contactContext.Persons.Remove(person);
            _contactContext.SaveChanges();

            return Ok(new { Message = "deletion successful" });
        }
    }
}
