using System;

namespace ConsoleAppTest.Models
{
    public class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise tha alarm if someone has subscribed
            if(OnAlarmRaised != null)
            {
                OnAlarmRaised();
            }
        }
    }
}