using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic.RequestDtos;
using ClarkCodingChallenge.BusinessLogic;

namespace ClarkCodingChallenge.Controllers
{

    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto request)
        {
            if (ModelState.IsValid)
            {
             var result = _contactsService.CreateContact(request);
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetContacts([FromQuery] string lastName, [FromQuery] bool isAscending)
        {
            return new OkResult();
        }
    }
}
