using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq

namespace SpeakingClock.Test
{
    [TestClass]
    public class TestSpeakingClock
    {
        [TestMethod]
        public void TestSpeakingClockUsesCollaborators()
        {
            // arrange
            var clock = new Mock<IClock>();
            var speech = new Mock<ITextToSpeech>();
            var timeAsText = new Mock<ITimeToText>();
            // connect the mocks to the speaking clock
            SpeakingClock speakingClock = new SpeakingClock()
            {
                Clock = clock.Object,
                TimeToText = timeAsText.Object,
                TextToSpeech = speech.Object
            };

            // configure the clock to return midnight time
            // configure the timetotext to return "midnight"


            // act
            speakingClock.SayTime();

            // assert
            // did the speaking clock as the clock what time it is?
            // did the speaking clock ask the timetotext to convert the time?
            // did the speaking clock ask the speech engine to speak the time?

        }

    }
}
