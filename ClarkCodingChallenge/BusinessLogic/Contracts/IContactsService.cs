using ClarkCodingChallenge.BusinessLogic.RequestDtos;

namespace ClarkCodingChallenge.BusinessLogic.Contracts
{
    public interface IContactsService
    {
        int CreateContact(CreateContactsRequestDto createContactDto);
    }
}