using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingClock
{
    public class TimeToText
    {
        public string ConvertTimeToText(DateTime timeToConvert)
        {
            if (timeToConvert.Hour == 12 && timeToConvert.Minute == 0)
            { 
                return "midday";
            }
            else if (timeToConvert.Hour == 0 && timeToConvert.Minute == 0)
            {
                return "midnight";
            }
            else
            {
                return null;
            }
        }
    }
}
