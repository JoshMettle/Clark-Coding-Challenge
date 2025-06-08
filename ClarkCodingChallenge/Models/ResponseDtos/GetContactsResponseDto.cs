using ClarkCodingChallenge.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models.ResponseDtos
{
    public class GetContactsResponseDto
    {
        public GetContactsResponseDto(ContactModel contact)
        {
            Id = contact.Id;
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = contact.Email;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
