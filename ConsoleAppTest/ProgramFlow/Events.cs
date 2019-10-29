using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        /// <summary>
        /// 
        /// </summary>

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

        /// <summary>
        /// 
        /// </summary>

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

        /// <summary>
        /// 
        /// </summary>
        class AlarmEventArgs : EventArgs
        {
            // You	now	have	your	own	type	that	can	be	used	to	describe	an	event	which	has occurred.	
            public AlarmEventArgs(string location)
            {
                Location = location;
            }

            public string Location { get; set; }
        }

        class AlarmEventData
        {
            //	Delegate	for	the	alarm	event
            public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };

            //	Called	to	raise	an	alarm
            public void RaiseAnAlarm(string location)
            {
                OnAlarmRaised(this, new AlarmEventArgs(location));
            }
        }

        static void AlarmListenerData(object sender, AlarmEventArgs args) 
        {
            Console.WriteLine("AlarmListenerData called");
            Console.WriteLine("location: {0}", args.Location);
        }

        // It	is	useful	if	subscribers	can	be	given information	about	the	alarm. You	can	do	this	by	creating	a	class	that	
        // can	deliver	this	information	and	then use	an	EventHandler	to	deliver	it.	
        public void EventHandlerData()
        {
            AlarmEventData alarmEventData = new AlarmEventData();
            alarmEventData.OnAlarmRaised += AlarmListenerData;
            alarmEventData.RaiseAnAlarm("Hello there!");
            // Note	that	a	reference	to	the	same	AlarmEventArgs	object	is	passed	to	each of	the	subscribers	to	the	OnAlarmRaised	event.	
            // This	means	that	if	one	of	the subscribers	modifies	the	contents	of	the	event	description,	subsequent subscribers	will	
            // see	the	modified	event.	This	can	be	useful	if	subscribers	need	to signal	that	a	given	event	has	been	dealt	
            // with,	but	it	can	also	be	a	source	of unwanted	side	effects. 
        }


        /// <summary>
        /// 
        /// </summary>

        class AlarmWithExceptions
        {
            public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate{};

            public void RaiseAlarm(string location)
            {
                List<Exception> exceptions = new List<Exception>();
                foreach (Delegate handler in OnAlarmRaised.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(this, new AlarmEventArgs(location));
                    }
                    catch (TargetInvocationException e)
                    {
                        exceptions.Add(e.InnerException);
                    }
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }

        static void AlarmListenerWithException1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("AlarmListenerWithException1 called");
            Console.WriteLine("location: {0}", args.Location);
            throw new Exception("Boom");
        }

        static void AlarmListenerWithException2(object source, AlarmEventArgs args)
        {
            Console.WriteLine("AlarmListenerWithException2 called");
            Console.WriteLine("location: {0}", args.Location);
            throw new Exception("Bang");
        }


        // A	number	of	programs	can	subscribe	to	an event.	They	do	this	by	binding	a	delegate	
        // to	the	event.	The	delegate	serves	as	a reference	to	a	piece	of	C#	code	which	the	subscriber	wants	to	run	when	the	event 
        // occurs.	This	piece	of	code	is	called	an	event	handler. In	our	example	programs	the	event	is	an	alarm	being	triggered.	
        // When	the alarm	is	triggered	the	event	will	call	all	the	event	handlers	that	have	subscribed to	the	alarm	event.	
        // But	what	happens	if	one	of	the	event	handlers	fails	by throwing	an	exception?	If	code	in	one	of	the	subscribers	throws	
        // an	uncaught exception	the	exception	handling	process	ends	at	that	point	and	no	further subscribers	will	be	notified.	
        // This	would	mean	that	some	subscribers	would	not be	informed	of	the	event. To	resolve	this	issue	each	event	
        // handler	can	be	called	individually	and	then	a single	aggregate	exception	created	which	contains	all	the	details	of	
        // any exceptions	that	were	thrown	by	event	handlers.	
        public void AggregatingExceptions()
        {
            AlarmWithExceptions alarm = new AlarmWithExceptions();
            alarm.OnAlarmRaised += AlarmListenerWithException1;
            alarm.OnAlarmRaised += AlarmListenerWithException2;
            try
            {
                alarm.RaiseAlarm("Earth");
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>

        delegate int IntOperation(int a, int b);
        // The	IntOperation	delegate	can	refer	to	any	operation	that takes	in	two	integer	parameters	and	returns	an	integer	result.	

        static int Add(int a, int b)
        {
            Console.WriteLine("Add called");
            return a + b;
        }

        static int Substract(int a, int b)
        {
            Console.WriteLine("Substract called");
            return a - b;
        }

        // Up	until	now	we	have	used	the	Action	and	EventHandler	types,	which provide	pre-defined	delegates.	We	can,	however,	
        // create	our	own	delegates.	Up until	now	the	delegates	that	we	have	seen	have	maintained	a	collection	of method	references.	
        // Our	applications	have	used	the	+=	and	-=	operators	to	add method	references	to	a	given	delegate.	You	can	also	
        // create	a	delegate	that	refers to	a	single	method	in	an	object. A	delegate	type	is	declared	using	the	delegate
        // keyword.	
        public void CreateDelegates()
        {
            IntOperation op;
            //	Explicitly	create	the	delegate
            op = new IntOperation(Add);
            Console.WriteLine(op(2,3));

            //	Delegate	is	created	automatically from method
            op = Substract;
            Console.WriteLine(op(2, 3));

            // 	a	program	can	explicitly create	an	instance	of	the	delegate	class.	The	C#	compiler	will	automatically generate	the	code	
            // to	create	a	delegate	instance	when	a	method	is	assigned	to	the delegate	variable. Delegates	can	be	used	
            // in	exactly	the	same	way	as	any	other	variable.	You	can have	lists	and	dictionaries	that	contain	delegates	
            // and	you	can	also	use	them	as parameters	to	methods. 
        }
        // It	is	important	to	understand	the	difference	between	delegate	(with	a	lowercase	d)	and	Delegate	(with	an	upper-case	D).	The	word	
        // delegate	with	a lower-case	d	is	the	keyword	used	in	a	C#	program	that	tells	the	compiler	to create	a	delegate	type
        // The	word	Delegate	with	an	upper-case	D	is	the	abstract	class	that	defines the	behavior	of	delegate	instances.	
        // Once	the	delegate	keyword	has	been	used to	create	a	delegate	type,	objects	of	that	delegate	type	will	be	realized	as
        // Delegate instances.


        /// <summary>
        /// Lambda expressions
        /// </summary>

        // Delegates	allow	a	program	to	treat	behaviors	(methods	in	objects)	as	items	of data.	A	delegate	is	an	item	of	data	
        // that	serves	as	a	reference	to	a	method	in	an object.	This	adds	a	tremendous	amount	of	flexibility	for	programmers.	
        // However, delegates	are	hard	work	to	use.	The	actual	delegate	type	must	first	be	declared and	then	made	to	
        // refer	to	a	particular	method	containing	the	code	that	describes the	action	to	be	performed. Lambda	expressions	are	a	
        // pure	way	of	expressing	the	“something	goes	in, something	happens	and	something	comes	out”	part	of	behaviors.	The	types	
        // of the	elements	and	the	result	to	be	returned	are	inferred	from	the	context	in	which the	lambda	expression	is	used.	
        // The	operator	=>	is	called	the	lambda	operator.	The	items	a	and	b	on	the	left of	the	lambda	expression	are	mapped	onto	
        // method	parameters	defined	by	the delegate.	The	statement	on	the	right	of	the	lambda	expression	gives	the	behavior of	the	expression,	
        // and	in	this	case	adds	the	two	parameters	together. When	describing	the	behavior	of	the	lambda	expression	you	can	use	the phrase	
        // “goes	into”	to	describe	what	is	happening.	In	this	case	you	could	say	“a and	b	go	into	a	plus	b.”	The	name	
        // lambda	comes	from	lambda	calculus
        public void LambdaExpressions()
        {
            IntOperation add = (a, b) => a + b;

            add = (a, b) =>
            {
                Console.WriteLine("Add called");
                return a + b;
            };

            Console.WriteLine(add(2,2));
        }


        /// <summary>
        /// 
        /// </summary>

        delegate int GetValue();

        static GetValue getLocalInt;

        static void SetLocalInt()
        {
            // Local variable set to 99
            int localInt = 99;
            // set the delegate getLocalInt to the lambda expression that returns the value of the localInt
            getLocalInt = () => localInt;
            // The	compiler	makes	sure	that	the localInt	variable	is	available	for	use	in	the	lambda	
            // expression	when	it	is subsequently	called	from	the	Closure	method.	
        }

        // The	code	in	a	lambda	expression	can	access	variables	in	the	code	around	it. These	variables	must	be	available	when	
        // the	lambda	expression	runs,	so	the compiler	will	extend	the	lifetime	of	variables	used	in	lambda	expressions. 
        // This	extension	of	variable	life	is called	a	closure.
        public void Closures()
        {
            SetLocalInt();
            Console.WriteLine("Value of the localInt: {0}", getLocalInt());
        }


        /// <summary>
        /// 
        /// </summary>

        // 	There are	a	number	of	“built-in”	delegate	types	that	we	can	use	to	provide	a	context	for a	lambda	expression. 
        // The	Func	types	provide	a	range	of	delegates	for	methods	that	accept	values and	return	results.
        // There	are	versions	of	the	Func	type  that accept  up to 16	input items.
        // If	the	lambda	expression	doesn’t	return	a	result,	you	can	use	the	Action	type 
        // The	Predicate	built	in	delegate	type	lets	you	create	code	that	takes	a	value of	a	particular	
        // type	and	returns	true	or	false
        public void BuiltInDelegates()
        {
            Func<int, int, int> add = (a, b) => a + b;

            Action<string> log = (message) => Console.WriteLine(message);

            Predicate<int> isDivisibleByThree = (i) => i % 3 == 0;
        }


        /// <summary>
        /// Anonymous methods
        /// </summary>

        // Up	until	now	we	have	been	using	lambda	expressions	that	are	attached	to delegates.	The	delegate	provides	a	name	
        // by	which	the	code	in	the	lambda expression	can	be	accessed.	However,	a	lambda	expression	can	also	be	used directly	
        // in	a	context	where	you	just	want	to	express	a	particular	behavior.	
        // A	lambda	expression	used	in	this	way	can	be	described	as	an	anonymous method;	because	it	is	a	piece	of	functional	code	
        // that	doesn’t	have	a	name. 
        public void LambdaExpressionTask()
        {
            Task.Run(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            });
            Console.WriteLine("Task running ...");
        }
    }
}
