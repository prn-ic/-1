using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022UserZMQPLib
{
    public class Calculations
    {
        public string[] AvailablePeriods(TimeSpan[] startTimes,
            int[] durations,
            TimeSpan beginWorkingTime,
            TimeSpan endWorkingTime,
            int consultationTime)
        {
            List<string> periods = new List<string>();
            int j = 0;
            while (beginWorkingTime < endWorkingTime)
            {
                if (j >= startTimes.Length)
                {
                    beginWorkingTime += TimeSpan.FromMinutes(consultationTime);
                    periods
                        .Add($"{beginWorkingTime - TimeSpan.FromMinutes(consultationTime)}" +
                        $" - {beginWorkingTime}");
                    continue;
                }

                if ((beginWorkingTime < startTimes[j]) &&
                    (beginWorkingTime < startTimes[j] + TimeSpan.FromMinutes(durations[j])) &&
                    (startTimes[j].Subtract(beginWorkingTime) >= TimeSpan.FromMinutes(consultationTime)))
                {
                    beginWorkingTime += TimeSpan.FromMinutes(consultationTime);
                    periods
                        .Add($"{beginWorkingTime - TimeSpan.FromMinutes(consultationTime)}" +
                        $" - {beginWorkingTime}");
                }
                else
                {
                    if (startTimes[j].Subtract(beginWorkingTime) <= TimeSpan.FromMinutes(consultationTime))
                    {
                        beginWorkingTime += TimeSpan.FromMinutes(durations[j]) + startTimes[j].Subtract(beginWorkingTime);
                    }
                    else
                    {
                        beginWorkingTime += TimeSpan.FromMinutes(durations[j]);
                    }
                    j++;
                }
            }

            return periods.ToArray(); ;
        }
    }
}
