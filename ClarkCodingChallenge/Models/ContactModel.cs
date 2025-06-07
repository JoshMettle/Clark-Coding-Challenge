using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ClarkCodingChallenge.Models
{
    public class ContactModel
    {
        public ContactModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }


        public int Id { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        public void AddId(int id)
        {
            this.Id = id;
        }
    }
}
