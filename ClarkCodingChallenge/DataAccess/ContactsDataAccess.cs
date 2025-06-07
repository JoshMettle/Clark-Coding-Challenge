using ClarkCodingChallenge.Models;
using System.Collections;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : IContactsDataAccess
    {
        private ICollection<ContactModel> Contacts = new List<ContactModel>();
        public ContactsDataAccess()
        {

        }
        
        /// <summary>
        /// Adds contact to data store
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>returns contact with primary key</returns>
        public void RecordContact(ContactModel contact)
        {
            var contactId = Contacts.Count + 1;
            contact.AddId(contactId);
            Contacts.Add(contact);
        }


    }
}
