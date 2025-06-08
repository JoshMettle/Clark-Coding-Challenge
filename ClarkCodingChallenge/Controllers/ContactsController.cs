using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models.RequestDtos;

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
        public IActionResult Index(CreateContactsRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var result = _contactsService.Create(request);
                return RedirectToAction("Success");
            }

            return View(request);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Errors()
        {
            return View();
        }
    }
}
