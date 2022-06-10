using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingClock
{
      

    public class SpeakingClock
    {
        public IClock Clock { get; set; }
        public ITimeToText TimeToText { get; set; }
        public ITextToSpeech TextToSpeech { get; set; }

        public void SayTime()
        {
            DateTime dateTime = Clock.GetTime();
            string timeAsText = TimeToText.ConvertTimeToText(dateTime);
            TextToSpeech.Speak(timeAsText);
        }
    }
}
