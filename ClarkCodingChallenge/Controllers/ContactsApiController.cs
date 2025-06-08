using ClarkCodingChallenge.BusinessLogic.Contracts;
using ClarkCodingChallenge.BusinessLogic.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarkCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsApiController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsApiController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet()]
        public IActionResult GetContacts(string lastName = null, string sortOrder = "asc")
        {
            var request = new GetContactsRequestDto(lastName, sortOrder);
            var response = _contactsService
        }
    }
}
