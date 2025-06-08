using ClarkCodingChallenge.BusinessLogic.Contracts;
using ClarkCodingChallenge.BusinessLogic.RequestDtos;
using ClarkCodingChallenge.BusinessLogic.ResponseDtos;
using ClarkCodingChallenge.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsDataAccess _contactsDataAccess;

        public ContactsService(IContactsDataAccess contactsDataAccess)
        {
            _contactsDataAccess = contactsDataAccess;
        }

        //TODO: Place business logic for contact here
        public int CreateContact(CreateContactsRequestDto request)
        {
            var contactToCreate = new ContactModel(request.FirstName, request.LastName, request.Email);

            _contactsDataAccess.RecordContact(contactToCreate);

            return contactToCreate.Id;
        }

        public ICollection<GetContactsResponseDto> GetContacts(GetContactsRequestDto request)
        {
            var isAscendingSort = request.SortOrder != "desc";
            ICollection<ContactModel> contacts;

            if (String.IsNullOrEmpty(request.LastName))
            {
              contacts = _contactsDataAccess.Get();
            }
            else
            {
               contacts = _contactsDataAccess.Get(request.LastName);
            }

            if (isAscendingSort)
            {
                contacts.OrderBy(x => x.LastName);
            } else
            {
                contacts.OrderByDescending(x => x.LastName);
            }

            var responseDto = contacts.Select(x => new GetContactsResponseDto(x)).ToList();

            return responseDto;
        }
    }
}
