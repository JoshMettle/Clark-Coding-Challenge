using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests.Mocks
{
    public static class MockContactsDataAccess
    {

        public static Mock<IContactsDataAccess> GetMockContactsDataAccess()
        {
            ICollection<ContactModel> contacts = new List<ContactModel>
            {
                new ContactModel("John", "Doe", "jdoe@gmail.com"),
                new ContactModel("Susan", "Smith", "ssmith@hotmail.com"),
                new ContactModel("Bill", "Smith", "bsmith@aol.com"),
            };

            var mockDataAccess = new Mock<IContactsDataAccess>();

            mockDataAccess.Setup(r => r.Create(It.IsAny<ContactModel>()))
                .Returns((ContactModel contact) =>
                {
                    contact.AddId(4);
                    contacts.Add(contact);
                    return contact;
                }
                );

            mockDataAccess.Setup(r => r.Get()).Returns(contacts);

            mockDataAccess.Setup(r => r.Get(It.IsAny<string>()))
                .Returns((string name) =>
                {
                    var result = contacts.Where(x => x.LastName.ToLower() == name.ToLower()).ToList();
                    return result;
                });

            return mockDataAccess;
        }
    }
}
