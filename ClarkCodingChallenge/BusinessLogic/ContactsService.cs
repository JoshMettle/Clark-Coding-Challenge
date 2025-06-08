using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.Models.RequestDtos;
using ClarkCodingChallenge.Models.ResponseDtos;
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
        public int Create(CreateContactsRequestDto request)
        {
            var contactToCreate = new ContactModel(request.FirstName, request.LastName, request.Email);

            var createdContact = _contactsDataAccess.Create(contactToCreate);

            return createdContact.Id;
        }

        public ICollection<GetContactsResponseDto> Get(GetContactsRequestDto request)
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

            var sortedContacts = OrderContacts(isAscendingSort, contacts);

            var responseDto = sortedContacts.Select(x => new GetContactsResponseDto(x)).ToList();

            return responseDto;
        }

        private static ICollection<ContactModel> OrderContacts(bool isAscendingSort, ICollection<ContactModel> contacts)
        {
            if (isAscendingSort)
            {
               return contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            }
            else
            {
                return contacts.OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName).ToList();
            }
        }
    }
}
