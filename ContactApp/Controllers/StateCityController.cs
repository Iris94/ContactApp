using ContactApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{
    [Route("api/statecity")]
    [ApiController]
    public class StateCityController : ControllerBase
    {
        private readonly StateCityContext _stateCityContext; 

        public StateCityController(StateCityContext stateCityContext) 
        {
            _stateCityContext = stateCityContext; 
        }

        [HttpGet("States")]
        public IActionResult GetStates()
        {
            var states = _stateCityContext.States.Select(s => s.StateName).Distinct().ToList();
            return Ok(states);
        }

        [HttpGet("Cities")]
        public IActionResult GetCities(string state)
        {
            var cities = _stateCityContext.Cities
                .Include(c => c.StateDb) 
                .Where(c => c.StateDb.StateName == state)
                .Select(c => c.CityName)
                .Distinct()
                .ToList();

            return Ok(cities);
        }
    }
}

