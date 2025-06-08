using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarkCodingChallenge.Controllers
{
    [Route("Api/Contacts")]
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
            if(sortOrder != "asc" && sortOrder != "desc")
            {
                return new BadRequestObjectResult("Sort order must have value of 'asc' or 'desc'");
            }
            var request = new GetContactsRequestDto(lastName, sortOrder);
            var response = _contactsService.Get(request);

            return new OkObjectResult(response);
        }
    }
}
