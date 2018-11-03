using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AND_Test.Models;
using AND_Test.Services;
using System.Collections.Generic;
using AND_Test.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;


namespace AND_Test.Tests
{
    [TestClass]
    public class PhoneNoControllerTest
    {
        [TestMethod]
        public void GetReturnsAllPhoneNos()
        {
            // Arrange

            List<PhoneNumber> t = new List<PhoneNumber>();
            t.Add(new PhoneNumber { ID = 1, CustID = 1, PhoneNo = "21213", IsActive = true });
            t.Add(new PhoneNumber { ID = 2, CustID = 44, PhoneNo = "12314", IsActive = false });

            var mockRepository = new Mock<IPhoneNoRepository>();
            mockRepository.Setup(x => x.GetAll())
                .Returns(t);

            var controller = new PhoneNoController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetAll();
            var contentResult = actionResult as OkNegotiatedContentResult<List<PhoneNumber>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count);
            Assert.AreEqual(1, contentResult.Content[0].ID);
            Assert.AreEqual(2, contentResult.Content[1].ID);
        }
        [TestMethod]
        public void GetReturnsPhoneNumbersWithSameCustomerId()
        {
            // Arrange

            List<PhoneNumber> t = new List<PhoneNumber>();
            t.Add(new PhoneNumber { ID = 1, CustID = 1, PhoneNo = "21213", IsActive = true });

            var mockRepository = new Mock<IPhoneNoRepository>();
            mockRepository.Setup(x => x.GetAllForCustomer(1))
                .Returns(t);

            var controller = new PhoneNoController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetCustomerPhones(1);
            var contentResult = actionResult as OkNegotiatedContentResult<List<PhoneNumber>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count);
            Assert.AreEqual(1, contentResult.Content[0].CustID);
        }
        [TestMethod]
        public void GetCustomerPhonesReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneNoRepository>();
            mockRepository.Setup(x => x.GetAllForCustomer(1))
                .Returns(null as List<PhoneNumber>);
            var controller = new PhoneNoController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetCustomerPhones (1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void ActivatePhoneNumberReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneNoRepository>();
            mockRepository.Setup(x => x.MakeItActive(1))
                .Returns(false);
            var controller = new PhoneNoController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.ActivatePhoneNo(1);
            var contentResult = actionResult as NegotiatedContentResult<bool>;
            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.NotFound, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }

        [TestMethod]
        public void ActivatePhoneNumberSuccess()
        {
            // Arrange
            var mockRepository = new Mock<IPhoneNoRepository>();
            mockRepository.Setup(x => x.MakeItActive(1))
                .Returns(true);
            var controller = new PhoneNoController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.ActivatePhoneNo(1);
            var contentResult = actionResult as NegotiatedContentResult<bool>;
            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }
    }
    
}
