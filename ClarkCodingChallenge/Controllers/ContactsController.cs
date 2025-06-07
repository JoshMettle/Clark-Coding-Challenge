using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic.RequestDtos;

namespace ClarkCodingChallenge.Controllers
{
    [Route("/Contacts")]
    [ApiController]
    public class ContactsController : Controller
    {
        public ContactsController()
        {
            
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

        }
    }
}
