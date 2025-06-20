﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ClarkCodingChallenge.Models.RequestDtos
{
    public class CreateContactsRequestDto
    {
        public CreateContactsRequestDto()
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
