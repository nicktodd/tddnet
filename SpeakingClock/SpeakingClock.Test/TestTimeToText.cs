namespace SpeakingClock.Test
{
    [TestClass]
    public class TestTimeToText
    {
        // fixture
        private TimeToText ttt;

        [TestInitialize]
        public void Setup()
        {
            ttt = new TimeToText();
        }


        [DataRow("midnight", 0,0)]
        [DataRow("midday", 12,0)]
        [DataTestMethod]
        public void TestTime(string expected, int hour, int minute)
        {
            DateTime time = new DateTime(2021,12,1,hour,0,0);
            // act
            string actual = ttt.ConvertTimeToText(time);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestMethod]
        public void TestMidnight()
        {
            DateTime midnight = new DateTime(2021, 12, 1, 0, 0, 0);
            // act
            string actual = ttt.ConvertTimeToText(midnight);
            // assert
            Assert.AreEqual("midnight", actual);
        }
    }
}