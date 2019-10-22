using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    // Asynchronous programming - the operations are not
    // synchronized.When you design asynchronous solutions that use multi-threading
    // you must be very careful to ensure that uncertainty about the timings of thread
    //    activity does not affect the working of the application or the results that are
    // produced. You’ll discover how to synchronize access to resources
    // that your application uses. You will see that if access to resources is not
    // synchronized correctly it can result in programs calculating the wrong result.A
    // badly written multi-threaded application might even get stuck because two
    // processes are waiting for each other to complete. You’ll discover how to stop
    // tasks that may have got stuck and how to ensure that threads work together
    // irrespective of the order in which they are performed.
    public class ManageMultithreading
    {
        private int[] _items = Enumerable.Range(0, 50000001).ToArray();

        // When an application is spread over several asynchronous tasks, it becomes
        // impossible to predict the sequencing and timing of individual actions.You need
        // to create applications with the understanding that any action may be interrupted
        // in a way that has the potential to damage your application.
        // Let’s start with a simple application that adds up the numbers in an array.
        public void SingleTaskSumming()
        {
            long total = 0;
            for (int i = 0; i < _items.Length; i++)
                total += _items[i];
            Console.WriteLine("Total is: {0}", total);
            // Total is: 1250000025000000

            // This	is	a	single	tasking	solution	that	has	to	work	through	the	entire	array.	
            // You may	decide	to	make	use	of	the	multiple	processors	in	your	computer	and	create	a solution	that	
            // creates	a	number	of	tasks,	each	of	which	will	add	up	a	particular area	of	the	array. 
        }

        private long _sharedTotal;

        private void AddRangeOfValues(int start, int end)
        {
            while (start < end)
            {
                _sharedTotal += _items[start];
                start++;
            }
        }

        // Illustration	how	resource	synchronization	can	cause	problems	in	an	application.	
        public void BadTaskInteraction()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while (rangeStart < _items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > _items.Length)
                    rangeEnd = _items.Length;
                //	create	local	copies	of	the	parameters																
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Total: {0}", _sharedTotal);
            // Total: 1065819416863894 -- WRONG!
            // The	problem	is	caused	by	the	way	in	which	all	of	the tasks	interact	over	the	same	shared	value

            // 1.	Task	number	1	starts	performing	an	update	of	sharedTotal.	It	fetches	the contents	of	the	sharedTotal	
            //   variable	into	the	CPU	and	adds	the	contents	of	an	array	element	to	the	value	of sharedTotal.	
            //   But,	just	as	the	CPU	is	about	to	write	the	result	back	into memory,	the	operating	system	stops	task	
            //   number	1	and	switches	to	task number	2. 
            // 2.	Task	number	2	also	wants	to	update	sharedTotal.	It	fetches	the	content of sharedTotal, adds    
            //   the value   of an  array element to it, and then writes the result  back into    memory.Now the operating system  returns
            //   control to task number  1. 
            // 3.Task    number  1   writes the sharedTotal value   it was working on  from the CPU back    into memory.	This means   
            //   that the update performed   by task number 2   has been    lost.
            // This	is	called	a	race	condition.	There	is	a	race	between	two	threads,	and	the behavior	
            // of	the	program	is	dependent	on	which	threads	first	get	to	the sharedTotal	variable.	
            // It’s	impossible	to	predict	what	a	badly	written program	like	this	will	do.	
            // Remember that	the	nature	of	an	asynchronous	solution	is	that	as	programmers	we	really don’t	have	any	control	
            // over	the	order	in	which	any	parts	of	our	system	may execute. Note	that	this	threading	issue	can	arise	
            // even	if	you	use	C#	statements	that	look like	they	are	atomic (x++ - actually is not atomic - read update and store result).
            // In	the	previous	section	you	identified	a	need	for	concurrent	collections	that can	be	used	by	
            // multiple	asynchronous	tasks.	These	collections	have	been implemented	in	a	way	that	avoids	
            // problems	like	the	one	shown	
        }

        private object _sharedTotalLock = new object();

        private void AddRangeOfValuesWithLock(int start, int end)
        {
            while (start < end)
            {
                // The	lock statement	is	followed	by	a	statement	or	block	of	code	that	is	performed	in	an atomic	manner,	
                // so	it	will	not	be	possible	for	a	task	to	interrupt	the	code	protected by	the	lock
                lock (_sharedTotalLock)
                {
                    _sharedTotal += _items[start];
                }
                start++;
            }
        }

        // A	program	can	use	locking	to	ensure	that	a	given	action	is	atomic.	Atomic actions	are	performed	
        // to	completion,	so	they	cannot	be	interrupted.	Access	to	an atomic	action	is	controlled	by	a	locking	object,	
        // which	you	can	think	of	as	the keys	to	a	restroom	operated	by	a	restaurant.	To	get	access	to	the	restroom	
        // you ask	the	cashier	for	the	key.	You	can	then	go	and	use	the	restroom	and,	when finished,	hand	the	key	back	
        // to	the	cashier.	If	the	restroom	is	in	use	when	you request	the	key,	you	must	wait	until	the	person	in	
        // front	of	you	returns	the	key,	so you	can	then	go	and	use	it. 
        public void UsingLocking()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while (rangeStart < _items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > _items.Length)
                    rangeEnd = _items.Length;
                //	create	local	copies	of	the	parameters																
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfValuesWithLock(rs, re))); // method uses locking
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Total: {0}", _sharedTotal); // correct result is printed out

            // While	you	have	stopped	the	tasks	from interacting	in	a	dangerous	manner,	
            // you’ve	also	removed	any	benefit	from	using multi-tasking.	If	you	run	the	program	above	you	will	
            // discover	that	it takes	longer	to	sum	the	elements	in	the	arrays	than	the	previous	versions. 
            // This	is	because	the	tasks	are	not	executing	in	parallel	any	more.	Most	of	the
            // time tasks   are in	a queue   waiting for access to  the shared  total   value.Adding  a lock  
            // solved  the problem of contention, but it has also stopped the tasks   from executing in parallel,	because they    
            // are waiting for access to  a   variable    that    they all    need    to  use.
        }

        private void AddRangeOfValuesWithSensibleLock(int start, int end)
        {
            long subtotal = 0;

            while (start < end)
            {
                subtotal += _items[start];
                start++;
            }

            lock (_sharedTotalLock)
            {
                _sharedTotal += subtotal;
            }
        }

        // When	you	create	a	parallel	version	of	an	operation	you	need	to	be	mindful	of potential	
        // value	corruption	when	you	use	shared	variables,	and	you	should	also carefully	consider	
        // the	impact	of	any	locking	that	you	use	to	prevent	corruption. 
        // You	also	need	to	remember	that	when	a	task	is	running	code	protected	by	a	lock,
        // the	task	is	in	a	position	to	block	other	tasks.	This	is	similar	to	how	a	person taking	a	
        // long	time	in	the	restroom	will	cause	a	long	queue	of	people	waiting	to use	it.	
        // Code	in	a	lock	should	be	as	short	as	possible	and	should	not	contain	any actions	that	
        // might	take	a	while	to	complete.	
        //As	an	example,	your	program should	never	perform	input/output	during	a	locked	block	of	code. 
        public void SensibleLocking()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while (rangeStart < _items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > _items.Length)
                    rangeEnd = _items.Length;
                //	create	local	copies	of	the	parameters																
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfValuesWithSensibleLock(rs, re))); // method uses locking
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Total: {0}", _sharedTotal); // correct result is printed out, and it also does not take long

        }

        private void AddRangeOfValuesWithMonitor(int start, int end)
        {
            long subtotal = 0;

            while (start < end)
            {
                subtotal += _items[start];
                start++;
            }

            Monitor.Enter(_sharedTotalLock);
            _sharedTotal += subtotal;
            Monitor.Exit(_sharedTotalLock);
        }

        // Monitor - similar to lock, but code arranged differently. Allow program to ensure that only one thread at a time can access a praticular object.
        // Rather than controlling a statement or block of code, as the lock keyword does, the atomic code is enclosed in calls of
        // Monitor.Enter and Monitor.Exit.The Enter and Exit methods are passed a reference to an object that is used as the lock.
        public void UsingMonitors()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while (rangeStart < _items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > _items.Length)
                    rangeEnd = _items.Length;
                //	create	local	copies	of	the	parameters																
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfValuesWithMonitor(rs, re))); // method uses monitor
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Total: {0}", _sharedTotal);

            // If atomic code throws an exception, you need to be sure that any locks that have been claimed to enter the code are released.In statements managed by the
            // lock keyword this happens automatically, if you use a Monitor, make sure that the lock is released.

            Monitor.Enter(_sharedTotalLock);
            try
            {
                // some code here that might throw exception
            }
            finally
            {
                Monitor.Exit(_sharedTotalLock); // this will always be executed
            }

            // way to check whether or not it will be blocked when it tries to enter the locked segment of code.
            if (Monitor.TryEnter(_sharedTotalLock))
            {
                // code controlled by the lock
            }
            else
            {
                // do something else because the lock object is in use
            }
            // The TryEnter method attempts to enter the code controlled by the lock. If this is not possible because the lock object is in use, the TryEnter method returns false.
        }

        private object lock1 = new object();
        private object lock2 = new object();

        private void Method1()
        {
            lock (lock1)
            {
                Console.WriteLine("Method1 got lock1");
                Console.WriteLine("Method1 waiting for lock2");
                lock (lock2)
                {
                    Console.WriteLine("Method1 got lock2");
                }
                Console.WriteLine("Method1 released lock2");
            }
            Console.WriteLine("Method1 released lock1");
        }

        private void Method2()
        {
            lock (lock2)
            {
                Console.WriteLine("Method2 got lock2");
                Console.WriteLine("Method2 waiting for lock1");
                lock (lock1)
                {
                    Console.WriteLine("Method2 got lock1");
                }
                Console.WriteLine("Method2 released lock1");
            }
            Console.WriteLine("Method2 released lock2");
        }

        // a deadly embrace, where two different tasks are waiting for each other to perform an action on a shared
        // collection, which blocks from adding items when the collection is full andremoving items when the collection is empty.This situation is also called a deadlock.
        public void SequentialLocking()
        {
            Method1();
            Method2();
            Console.WriteLine("Methods complete");
            // all methods will complete. Each method gets the lock objects in turn because they are running sequentially
        }

        // You	can	change	the	program	so	that	the methods	are	performed	by	tasks.
        // 
        // 
        public void DeadLockedTasks()
        {
            Task t1 = Task.Run(() => Method1());
            Task t2 = Task.Run(() => Method2());
            Console.WriteLine("waiting	for	Task	2");
            t2.Wait();
            Console.WriteLine("Tasks	complete.	Press	any	key	to	exit."); // this will never be printed

            // The	tasks	in	this	case	never	complete.	Each	task	is	waiting	for	the	other’s	lock object,	and	neither	can	
            // continue.	Note	that	
            // this	is	not	the	same	as	creating	an infinite	loop,	in	which	a	program	repeats	a	sequence	of	statements	forever.	
        }

        private void AddRangeOfValuesInterlocked(int start, int end)
        {
            long subtotal = 0;

            while (start < end)
            {
                subtotal += _items[start];
                start++;
            }

            Interlocked.Add(ref _sharedTotal, subtotal);
            // There	is	also	a	compare	and	exchange	method	that	can	be	used	to	create	a multi-tasking	program	to	search	
            // through	an	array	and	find	the	largest	value	in that	array. 
        }

        // There’s	a	better	way of	achieving	thread	safe	access	to	the	contents	of	a	variable,	which	
        // is	to	use	the Interlocked	class.	This	provides	a	set	of	thread-safe	operations	that	can	be performed	on	a	variable.	
        // These	include	increment,	decrement,	exchange	(swap	a variable	with	another),	and	add. 
        public void InterlockTotal()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while (rangeStart < _items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if (rangeEnd > _items.Length)
                    rangeEnd = _items.Length;
                //	create	local	copies	of	the	parameters																
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfValuesInterlocked(rs, re))); // method uses monitor
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Total: {0}", _sharedTotal);

            // Volatile variables
            // The	source	of	a	C#	program	goes	through	a	number	of	stages	before	it	is	actually executed.	
            // The	compilation	process	includes	the	examination	of	the	sequence	of statements	to	discover	ways	
            // that	a	program	can	be	made	to	run	more	quickly. This	might	result	in	
            // statements	being	executed	in	a	different	order	to	the	order they	were	written.	
            // After compilation	we	may	find	that	the	order	of	statements	has	been swapped,	
            // so	that	the	value	can	be	held	inside	the	computer	processor	rather than	having	to	be	
            // re -loaded	from	memory	for	the	write	statement. In	a	single	threaded	situation	this	is	perfectly	
            // acceptable,	but	if	multiple threads	are	working	on	the	code,	this	may	result	in	unexpected	behaviors. 
            // Furthermore,	if	another	task	changes	the	value	of	variable	while	statements	are	running, and	if	the	C#	compiler	
            // caches	the	value	between	statements,	this	results	in an	out	of	date	value	being	printed.	
            // C#	provides	the	keyword	volatile,	
            // which can	be	used	to	indicate	that	operations	involving	a	particular	variable	are	not optimized	in	this	way.
            // volatile int x;
            // Operations	involving	the	variable	x	will	now	not	be	optimized,	and	the	value of	
            // x	will	be	fetched	from	the	copy	in	memory,	rather	than	being	cached	in	the processor.	
            // This	can	make	operations	involving	the	variable	x	a	lot	less	efficient. 

        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void Clock()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("Tick");
                Thread.Sleep(1000);
            }
        }

        // There	is	an	important	difference	between	threads	and	tasks,	in	that	a	Thread can	be	aborted	at	any	time,	
        // whereas	a	Task	must	monitor	a	cancellation	token so	that	it	will	end	when	told	to
        public void CancellATask()
        {
            Task.Run(() => Clock());
            Console.WriteLine("Press any key to stop clock");
            Console.ReadKey();
            _cancellationTokenSource.Cancel();
            Console.WriteLine("Clock stoped");
        }

        private void ClockWithException(CancellationToken cancellationToken)
        {
            int tickCount = 0;

            while (!cancellationToken.IsCancellationRequested && tickCount < 20)
            {
                tickCount++;
                Console.WriteLine("Tick");
                Thread.Sleep(1000);
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        // A	Task	can	indicate	that	it	has	been	cancelled	by	raising	an	exception.	
        // This	can be	useful	if	a	task	is	started	in	one	place	and	monitored	in	another.	
        public void CancellWithException()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task clock = Task.Run(() => ClockWithException(cancellationTokenSource.Token));
            Console.WriteLine("Press any key to stop the clock");
            Console.ReadKey();
            if (clock.IsCompleted)
            {
                Console.WriteLine("Clock task completed");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    clock.Wait();
                }
                catch(AggregateException ex)
                {
                    Console.WriteLine("Clock task stopped: {0}", ex.InnerExceptions[0].ToString());
                }
            }
        }

        class Counter
        {
            private int _totalValue = 0;

            public void IncreaseValue(int amount)
            {
                _totalValue += amount;
            }

            public int Total
            {
                get { return _totalValue; }
            }
        }

        // An	object	can	provide	services	to	other	objects	by	exposing	methods	for	them	to use.	
        // If	an	object	is	going	to	be	used	in	a	multi-threaded	application	it	is important	that	
        // the	method	behaves	in	a	thread	safe	manner.	Thread	safe	means that	the	method	can	be	called	from	
        // multiple	tasks	simultaneously	without producing	incorrect	results,	and	without	placing	the	object	that	
        // it	is	a	member	of into	an	invalid	state. 
        // Without	locking,	the	program	that	attempts to	use	multiple	tasks	to	sum	the	contents	of	an	array	
        // fails	because	there	is unmanaged	access	to	the	shared	total	value.	You	can	see	the	same	issues	arising when	
        // a	method	uses	the	value	of	a	member	of	an	object. 
        // Any	use	of	a	member	of	a	class	must	be	thread	safe,	and	this	must	be	done	in a	way	that	does	
        // not	compromise	multi-threaded	performance.	You’ve	seen	how adding	locks	can	make	things	thread	safe,	
        // but	you	also	saw	how	doing	this incorrectly	can	actually	make	performance	worse.	This	may	mean	that	creating	a
        // multi-tasked implementation  of a   system involves    a complete    re-write,	with processes  refactored	as	
        // either producers   or consumers   of data.
        public void UnsafeThreadMethod()
        {

        }
    }
}
