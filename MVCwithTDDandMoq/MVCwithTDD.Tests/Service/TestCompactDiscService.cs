using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCwithTDD.Repository;
using MVCwithTDD.Service;


namespace MVCwithTDD.Tests.Service
{
    [TestClass]
    public class TestCompactDiscService
    {
      
        [TestMethod]
        public void CanGetAllCompactDiscs()
        {
            // arrange

            //set up some moq data
            var data = new List<compact_discs>

            {
                new compact_discs() { title = "Abba Gold", id=1, price=(decimal)12.99, artist="Abba" },
                new compact_discs() { title = "Thriller", id=2, price=(decimal)12.99, artist="Michael Jackson" },
                new compact_discs() { title = "Dark Side of the Moon", id=3, price=(decimal)8.99, artist="Pink Floyd" },
            }.AsQueryable();

            // set up a mock dbset
            var mockSet = new Mock<DbSet<compact_discs>>();
            mockSet.As<IQueryable<compact_discs>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<compact_discs>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<compact_discs>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<compact_discs>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // mock the dbcontext object
            var mockContext = new Mock<musicEntities>();
            mockContext.Setup(c => c.compact_discs).Returns(mockSet.Object);

            // create the service layer and inject the mock dbcontext
            var service = new CompactDiscService() {Context = mockContext.Object};
            
            // act
            // now retrieve all the cds from the service which should use the mock
            var discs = service.GetAllCompactDiscs();


            // assert
            // now assert that the correct data is returned
            Assert.AreEqual(3, discs.Count);
            Assert.AreEqual("Abba", discs[0].Artist);
            Assert.AreEqual("Thriller", discs[1].Title);
            Assert.AreEqual("Pink Floyd", discs[2].Artist);


        }
    }
}
