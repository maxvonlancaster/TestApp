using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppTest.Models;

namespace ConsoleAppTest.ProgramFlow
{
    // Events - when u want an object to notify another object that something has happened. Components - loosely coupled
    // An obj can be made to publish events to which other obj-s can subscribe.
    public class Events
    {
        private void Listener1()
        {
            Console.WriteLine("Listener 1 called ");
        }

        private void Listener2()
        {
            Console.WriteLine("Listener 2 called ");
        }


        // Delegate - piece of data that contains a reference to a particular method in a class
        // An event publisher is given a delegate that dscribes the method in the subscriber. The publisher can then call that delegatewhen the event occurs
        // Action delegate - a reference to a method that does not return a result and no parameters
        public void ActionDelegate()
        {
            // Subscribers bind to publisher by using the += operator
            Alarm alarm = new Alarm();
            alarm.OnAlarmRaised += Listener1;
            alarm.OnAlarmRaised += Listener2;

            // Raise alarm
            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised ");

            alarm.OnAlarmRaised -= Listener1;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised ");
        }
    }
}
