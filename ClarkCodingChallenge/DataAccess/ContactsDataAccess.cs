using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : IContactsDataAccess
    {
        private ICollection<ContactModel> Contacts = new List<ContactModel>();
        public ContactsDataAccess()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>returns contact with primary key</returns>
        public ContactModel Create(ContactModel contact)
        {
            var contactCount = Contacts.Count();
            contact.AddId(contactCount + 1);
            Contacts.Add(contact);

            return contact;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public ICollection<ContactModel> Get()
        {
            return Contacts;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public ICollection<ContactModel> Get(string lastName)
        {
            return Contacts.Where(x => x.LastName.ToLower() == lastName.ToLower()).ToList();
        }

    }
}
