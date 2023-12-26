using ContactApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{
    public class HomeController(ContactContext contactContext) : Controller
    {
        private readonly ContactContext _contactContext = contactContext;

        public async Task<IActionResult> Index()
        {
            var persons = await _contactContext.Persons
                .Include(p => p.PhoneNumbers)
                .Include(a => a.EmailAddresses)
                .ToListAsync();

            return View(persons);
        }
    }
}
