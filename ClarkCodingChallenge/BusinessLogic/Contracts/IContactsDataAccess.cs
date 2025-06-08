using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic.Contracts
{
    public interface IContactsDataAccess
    {
        ICollection<ContactModel> Get();
        ICollection<ContactModel> Get(string lastName);
        public void RecordContact(ContactModel contact);
    }
}