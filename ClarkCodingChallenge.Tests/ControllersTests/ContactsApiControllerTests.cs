using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Controllers;
using ClarkCodingChallenge.Tests.ControllersTests.Mocks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClarkCodingChallenge.Tests.ControllersTests
{
    [TestClass]
    public class ContactsApiControllerTests
    {
        private Mock<IContactsService> _mockContactService;
        private ContactsApiController _contactsController;

        [TestInitialize]
        public void Setup()
        {
            _mockContactService = MockContactsService.GetMockContactsService();
            _contactsController = new ContactsApiController(_mockContactService.Object);
        }

        [DataTestMethod]
        [DataRow("Smith", "asc", 200)]
        [DataRow("", "ascending", 400)]

        public void Get_ReturnsCorrectStatusResult(string searchName, string sortOrder, int expectedStatus)
        {
            //Arrange

            //Act
            var result = _contactsController.GetContacts(searchName, sortOrder);
            var resultCode = ((IStatusCodeActionResult)result).StatusCode;
            //Assert
            Assert.AreEqual(expectedStatus, resultCode);
        }
    }
}
