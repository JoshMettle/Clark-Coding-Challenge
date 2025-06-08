using ClarkCodingChallenge.Models.RequestDtos;
using ClarkCodingChallenge.Models.ResponseDtos;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Contracts
{
    public interface IContactsService
    {
        int Create(CreateContactsRequestDto createContactDto);
        ICollection<GetContactsResponseDto> Get(GetContactsRequestDto request);
    }
}