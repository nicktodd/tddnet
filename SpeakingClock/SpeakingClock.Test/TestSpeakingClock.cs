using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace SpeakingClock.Test
{
    [TestClass]
    public class TestSpeakingClock
    {
        [TestMethod]
        public void TestSpeakingClockUsesCollaborators()
        {
            DateTime midday = new DateTime(2022, 12, 1, 12, 0, 0);
            string middayText = "midday";

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

            clock.Setup(cl => cl.GetTime()).Returns(midday);
            timeAsText.Setup(tt => tt.ConvertTimeToText(midday)).Returns(middayText);
            //speech.Setup(sp => sp.Speak(middayText));

            // configure the clock to return midnight time
            // configure the timetotext to return "midnight"


            // act
            speakingClock.SayTime();

            // assert
            // did the speaking clock ask the clock what time it is?
            clock.Verify(cl => cl.GetTime(), Times.Once());
            // did the speaking clock ask the timetotext to convert the time?
            timeAsText.Verify(tt => tt.ConvertTimeToText(midday), Times.Once());
            // did the speaking clock ask the speech engine to speak the time?
            speech.Verify(sp => sp.Speak(middayText), Times.Once());
        }

    }
}
