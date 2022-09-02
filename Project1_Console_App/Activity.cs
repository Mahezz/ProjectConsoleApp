using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Console_App
{
    internal class Activity
    {
        public string ActivityName { get; set; }
        public int DayStart { get; set; }
        public int DayFinish { get; set; }
        public int Duration { get; set; }

        public Activity(string activityName, int dayStart, int dayFinish, int duration)
        {
            ActivityName = activityName;
            DayStart = dayStart;
            DayFinish = dayFinish;
            Duration = duration;
        }
    }
}
