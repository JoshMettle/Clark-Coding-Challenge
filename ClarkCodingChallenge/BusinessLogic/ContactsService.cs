using ClarkCodingChallenge.BusinessLogic.RequestDtos;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;

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
        public int CreateContact(CreateContactDto createContactDto)
        {
            var contactToCreate = new ContactModel(createContactDto.FirstName, createContactDto.LastName, createContactDto.Email);

            _contactsDataAccess.RecordContact(contactToCreate);

            return contactToCreate.Id;
        }
    }
}
