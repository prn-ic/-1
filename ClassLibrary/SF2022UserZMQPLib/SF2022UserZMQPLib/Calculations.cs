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
            List<string> result = new List<string>();

            var temps = beginWorkingTime;
            for (int i = 0; i < startTimes.Length; i++)
            {

                if (((startTimes[i].TotalMinutes - temps.TotalMinutes)) < consultationTime && ((startTimes[i].TotalMinutes - temps.TotalMinutes)) != 0)
                {
                    var temp = (startTimes[i].TotalMinutes - beginWorkingTime.TotalMinutes) * -1;
                    beginWorkingTime += TimeSpan.FromMinutes((double)temp + durations[i]);
                    continue;
                }
                while (beginWorkingTime < startTimes[i])
                {
                    if (((startTimes[i].TotalMinutes - beginWorkingTime.TotalMinutes)) < consultationTime)
                    {
                        
                        beginWorkingTime = startTimes[i];
                        continue;
                    }
                    var temp = beginWorkingTime;
                    beginWorkingTime += TimeSpan.FromMinutes((double)consultationTime);
                    result.Add($"{temp.ToString(@"hh\:mm")}-{beginWorkingTime.ToString(@"hh\:mm")}");
                    
                }
                var tempTime = beginWorkingTime;
                
                beginWorkingTime += TimeSpan.FromMinutes((double)durations[i]);
                temps = beginWorkingTime;
                if (((startTimes[i].TotalMinutes - beginWorkingTime.TotalMinutes) * -1) < consultationTime)
                {
                    var temp = (startTimes[i].TotalMinutes - beginWorkingTime.TotalMinutes) * -1;
                    beginWorkingTime += TimeSpan.FromMinutes((double)temp + durations[i]);
                }
            }

            while (beginWorkingTime < endWorkingTime)
            {
                var temp = beginWorkingTime;
                beginWorkingTime += TimeSpan.FromMinutes((double)consultationTime);
                result.Add($"{temp.ToString(@"hh\:mm")}-{beginWorkingTime.ToString(@"hh\:mm")}");
            }

            return result.ToArray();

        }
    }
}
