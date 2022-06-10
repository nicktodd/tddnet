using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCwithTDD.Controllers;
using MVCwithTDD.Service;

namespace MVCwithTDD.Tests.Controllers
{
    [TestClass]
    public class TestCompactDiscController
    {
        [TestMethod]
        public void GetAllCompactDiscsInvokesServiceLayerCorrectly()
        {
            // arrange
            var mockServiceLayer = new Mock<ICompactDiscService>();
            var controllerUnderTest = new CompactDiscsController();
            controllerUnderTest.Service = mockServiceLayer.Object;

            mockServiceLayer.Setup(mock => mock.GetAllCompactDiscs());
            // act
            controllerUnderTest.Getcompact_discs();

            // assert??
            mockServiceLayer.Verify(mock => mock.GetAllCompactDiscs(), Times.Once);
        }
    }
}
