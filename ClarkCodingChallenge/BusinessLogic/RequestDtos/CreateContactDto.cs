using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ClarkCodingChallenge.BusinessLogic.RequestDtos
{
    public class CreateContactDto
    {
        public CreateContactDto()
        {
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
