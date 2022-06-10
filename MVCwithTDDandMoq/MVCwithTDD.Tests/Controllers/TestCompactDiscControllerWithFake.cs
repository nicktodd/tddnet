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
    public class FakeCompactDiscService : ICompactDiscService
    {
        public List<CompactDisc> GetAllCompactDiscs()
        {
            List<CompactDisc> discs = new List<CompactDisc>();
            discs.Add(new CompactDisc() { Title = "Best of the 20's", Artist = "Cliff Richard", Id = 1, Price = (decimal)12.99 });
            return discs;
        }
    }


    [TestClass]
    public class TestCompactDiscControllerWithFake
    {
        [TestMethod]
        public void GetCompactDiscsWorksWithFake()
        {
            // arrange
            CompactDiscsController controller = new CompactDiscsController();
            controller.Service = new FakeCompactDiscService();

            // act
            List<CompactDisc> discs =controller.Getcompact_discs();

            // assert
            Assert.AreEqual("Best of the 20's", discs[0].Title);
        }
    }
}
