using ClarkCodingChallenge.Models;

namespace ClarkCodingChallenge.DataAccess
{
    public interface IContactsDataAccess
    {
        public void RecordContact(ContactModel contact);
    }
}