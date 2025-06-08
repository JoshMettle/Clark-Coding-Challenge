using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Contracts
{
    public interface IContactsDataAccess
    {
        /// <summary>
        /// Gets all results
        /// </summary>
        /// <returns></returns>
        ICollection<ContactModel> Get();

        /// <summary>
        /// Retrieves results matching target string.  Case insensitve.
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        ICollection<ContactModel> Get(string lastName);

        /// <summary>
        /// Retrieves results matching target string.  Case insensitve.
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public ContactModel Create(ContactModel contact);
    }
}