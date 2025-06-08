namespace ClarkCodingChallenge.Models.RequestDtos
{
    public class GetContactsRequestDto
    {
        public GetContactsRequestDto(string lastName, string sortOrder)
        {
            LastName = lastName;
            SortOrder = sortOrder;
        }

        public string LastName { get; private set; } = string.Empty;
        public string SortOrder { get; private set; } = string.Empty;
    }
}
