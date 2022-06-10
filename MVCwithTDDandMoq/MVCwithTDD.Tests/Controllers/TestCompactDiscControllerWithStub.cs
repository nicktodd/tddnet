using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCwithTDD.Controllers;
using MVCwithTDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCwithTDD.Dto;

namespace MVCwithTDD.Tests.Controllers
{
    [TestClass]
    public class TestCompactDiscControllerWithStub
    {
        private class CompactDiscServiceStub : ICompactDiscService
        {
            public List<CompactDisc> GetAllCompactDiscs()
            {
                return null;
            }
        }

        [TestMethod]
        public void GetCompactDiscsWorksAsExpected()
        {
            // arrange
            CompactDiscsController controller = new CompactDiscsController();
            controller.Service = new CompactDiscServiceStub();

            // act
            var result = controller.Getcompact_discs();

            // assert
            Assert.IsNull(result);
        }
    }
}
