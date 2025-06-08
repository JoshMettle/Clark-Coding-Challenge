using ClarkCodingChallenge.Contracts;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.Models.RequestDtos;
using ClarkCodingChallenge.Models.ResponseDtos;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClarkCodingChallenge.Tests.ControllersTests.Mocks
{
    public static class MockContactsService
    {
        public static Mock<IContactsService> GetMockContactsService()
        {
            var contacts = new List<GetContactsResponseDto>();
         
            var mockDataAccess = new Mock<IContactsService>();

            mockDataAccess.Setup(r => r.Create(It.IsAny<CreateContactsRequestDto>())).Returns(1);

            mockDataAccess.Setup(r => r.Get(It.IsAny<GetContactsRequestDto>())).Returns(contacts);

            return mockDataAccess;
        }
    }
}
