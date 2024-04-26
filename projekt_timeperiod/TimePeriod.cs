using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_lab
{
    public struct TimePeriod
    {
        private readonly int totalSeconds;

        public int TotalSeconds => totalSeconds;

        public TimePeriod(int hours, int minutes, int seconds)
        {
            totalSeconds = hours * 3600 + minutes * 60 + seconds;
        }

        public override string ToString()
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
    }
}
