using ClarkCodingChallenge.BusinessLogic.RequestDtos;

namespace ClarkCodingChallenge.BusinessLogic
{
    public interface IContactsService
    {
        int CreateContact(CreateContactDto createContactDto);
    }
}