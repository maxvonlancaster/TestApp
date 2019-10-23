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
        // Method that must run when the alarm is rised
        private void Listener1()
        {
            Console.WriteLine("Listener 1 called ");
        }

        private void Listener2()
        {
            Console.WriteLine("Listener 2 called ");
        }


        // Delegate - piece of data that contains a reference to a particular method in a class
        // An event publisher is given a delegate that dscribes the method in the subscriber. The publisher can then call that delegate when the event occurs
        // Action delegate - a reference to a method that does not return a result and no parameters
        public void ActionDelegate()
        {
            // Subscribers bind to publisher by using the += operator
            Alarm alarm = new Alarm();
            alarm.OnAlarmRaised += Listener1;
            alarm.OnAlarmRaised += Listener2;
            // Listeners - subscribers, Alarm - publisher

            // Raise alarm
            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised ");
            
            // The -= method is used to unsubscribe from events.
            alarm.OnAlarmRaised -= Listener1;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised ");
            // If the same subscriber is added more than once to the same publisher, it will be called a corresponding number of times when the event occurs.
        }

        // The Alarm object that we’ve created is not particularly secure. The OnAlarmRaised delegate has been made public so that subscribers can
        // connect to it.However, this means that code external to the Alarm object can raise the alarm by directly calling the OnAlarmRaised delegate. External
        // code can overwrite the value of OnAlarmRaised, potentially removing subscribers. C# provides an event construction that allows 
        // a delegate to be specified as an event. 
        class EventBasedAlarm
        {
            // The member OnAlarmRaised is now created as a data field in the Alarm class, rather than a property.
            public event Action OnAlarmRaised = delegate { };
            // However, it is now not possible for code   external to the Alarm class to assign values to OnAlarmRaised, and the
            // OnAlarmRaised delegate can only be called from within the class where it is declared.

            public void RaiseAlarm()
            {
                // no need to check whether or not the delegate has a value
                OnAlarmRaised();
            }
        }

        // The event delegates created so far have used the Action class as the type of each event. This will work, but programs that use events should use the
        // EventHandler class instead of Action.This is because the EventHandler class is the part of.NET designed to allow subscribers to be
        // given data about an event. EventHandler is used throughout the .NET framework to manage events. An EventHandler can deliver data, or it can
        // just signal that an event has taken place.
        // The EventHandler delegate refers to a subscriber method that will accept      two arguments.The first argument is a reference to the object raising the event.
        // The second argument is a reference to an object of type EventArgs that provides information about the event
        class EventHandlerAlarm
        {
            public event EventHandler OnAlarmRaised = delegate { };

            // Called to raise alarm, does not provide any event arguments
            public void RaiseAlarm()
            {
                // Raises alarm. The event handler receivers a reference to the alarm that is raising this event.
                OnAlarmRaised(this, EventArgs.Empty); 
                // the second argument is set to EventArgs.Empty, to indicate that this event does not produce any
                // data, it is simply a notification that an event has taken place.
            }
        }
        // The signature of the methods to be added to this delegate must reflect this.The AlarmListener1 method accepts two parameters and can be used with this delegate.
        private void AlarmListener(object sender, EventArgs e)
        {
            // Only the sender is valid as this event doesn't have arguments
            Console.WriteLine("Alarm Listener 1 called");
        }

        // 
        // 
        public void EventHandlerData()
        {

        }

        // 
        // 
        public void AggregatingExceptions()
        {

        }

        // 
        // 
        public void CreateDelegates()
        {

        }

        // 
        // 
        // 
        public void LambdaExpressions()
        {

        }

        // 
        // 
        public void Closures()
        {

        }

        // 
        // 
        public void BuiltInDelegates()
        {

        }

        // 
        // 
        public void LambdaExpressionTask()
        {

        }
    }
}
