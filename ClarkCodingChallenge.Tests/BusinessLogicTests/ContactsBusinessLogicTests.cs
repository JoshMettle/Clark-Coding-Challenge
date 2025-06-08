using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.Models.RequestDtos;
using ClarkCodingChallenge.Tests.BusinessLogicTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private Mock<IContactsDataAccess> _mockDataAccess;
        private ContactsService _contactsService;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = MockContactsDataAccess.GetMockContactsDataAccess();
            _contactsService = new ContactsService(_mockDataAccess.Object);
        }


        [TestMethod]
        public void Create_ReturnsId()
        {
            //Arrange
            var contactDto = new CreateContactsRequestDto()
            {
                FirstName = "Sam",
                LastName = "Miller",
                Email = "smiller@gmail.com"
            };

            //Act
            var result = _contactsService.Create(contactDto);

            //Assert
            Assert.AreEqual(4, result);
            _mockDataAccess.Verify(dataAccess => dataAccess.Create(It.IsAny<ContactModel>()), Times.Once);
        }

        [TestMethod]
        public void Create_CallsDataAccess()
        {
            //Arrange
            var contactDto = new CreateContactsRequestDto()
            {
                FirstName = "Sam",
                LastName = "Miller",
                Email = "smiller@gmail.com"
            };

            //Act
            var result = _contactsService.Create(contactDto);

            //Assert
            _mockDataAccess.Verify(dataAccess => dataAccess.Create(It.IsAny<ContactModel>()), Times.Once);
        }

        [DataTestMethod]
        [DataRow("", "acs", 3)]
        [DataRow("", "desc", 3)]
        [DataRow("smith", "acs", 2)]
        [DataRow("smith", "desc", 2)]
        [DataRow("!@#R", "desc", 0)]
        public void Get_ReturnsCorrectNumberResults(string searchName, string sortOrder, int expectedResult) {
            //Arrange
            var getContactDto = new GetContactsRequestDto(searchName, sortOrder);

            //Act
            var results = _contactsService.Get(getContactDto);
            var resultCount = results.Count;
            //Assert
            Assert.AreEqual(expectedResult, resultCount);
        }

        [DataTestMethod]
        [DataRow("", "acs", "John", "Doe")]
        [DataRow("", "desc", "Susan", "Smith")]
        [DataRow("smith", "acs", "Bill", "Smith")]
        [DataRow("smith", "desc", "Susan", "Smith")]
        public void Get_ReturnsCorrectSortedResults(string searchName, string sortOrder, string expectedFirst, string expectedLast)
        {
            //Arrange
            var getContactDto = new GetContactsRequestDto(searchName, sortOrder);

            //Act
            var results = _contactsService.Get(getContactDto);
            var firstResult = results.First();
            var resultFirstName = firstResult.FirstName;
            var resultLastName = firstResult.LastName;

            //Assert
            Assert.AreEqual(expectedLast, resultLastName);
            Assert.AreEqual(expectedFirst, resultFirstName);
        }
    }
}
