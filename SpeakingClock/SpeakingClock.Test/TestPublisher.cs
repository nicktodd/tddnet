using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace SpeakingClock.Test
{
    
    class SubscriberSpy : ISubscriber
    {
        public string ReceivedMessage
        {
            get;
            set;
        }
        public void ReceiveMessage(string message)
        {
            ReceivedMessage = message;
        }
    }

    class ExtendedPublisher : Publisher
    {
        public ISubscriber GetLastSubscriber()
        {
            return subscribers.Last();
        }
    }
    [TestClass]
    public class TestPublisher
    {

        [TestMethod]
        public void TestCanAddSubcriber()
        {
            // arrange
            ExtendedPublisher publisher = new ExtendedPublisher();
            // act
            ISubscriber sub = new SubscriberSpy();
            publisher.AddSubcriber(sub);
            // assert
            Assert.AreSame(sub, publisher.GetLastSubscriber());
        }
        [TestMethod]
        public void TestPublisherCanPublishMessages()
        {
            // arrange
            Publisher publisher = new Publisher();
            SubscriberSpy sub = new SubscriberSpy();
            publisher.AddSubcriber(sub);
            // act
            string message = "hello world";
            publisher.PublishMessage(message);
            // assert
            Assert.AreEqual(message, sub.ReceivedMessage);
        }
        [TestMethod]
        public void TestPublisherCanPublishMessagesUsingMoq()
        {
            // arrange
            string message = "hello world";
            Publisher publisher = new Publisher();
            var mockSubscriber = new Mock<ISubscriber>();
            publisher.AddSubcriber(mockSubscriber.Object);
            // act
            publisher.PublishMessage(message);
            // assert
            mockSubscriber.Verify(sub => sub.ReceiveMessage(message), Times.Once());
            
        }


    }
}
