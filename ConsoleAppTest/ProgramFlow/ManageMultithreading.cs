using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                int	rs	=	rangeStart;
                int	re	=	rangeEnd;
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

                // The	lock statement	is	followed	by	a	statement	or	block	of	code	that	is	performed	in	an atomic	manner,	
                // so	it	will	not	be	possible	for	a	task	to	interrupt	the	code	protected by	the	lock
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

        // 
        // 
        // 
        public void UsingMonitors()
        {

        }

        // 
        // 
        // 
        public void SequentialLocking()
        {

        }

        // 
        // 
        // 
        public void DeadLockedTasks()
        {

        }

        // 
        // 
        // 
        public void InterlockTotal()
        {

        }

        // 
        // 
        // 
        public void CancellATask()
        {

        }

        // 
        // 
        // 
        public void CancellWithException()
        {

        }

        // 
        // 
        // 
        public void UnsafeThreadMethod()
        {

        }
    }
}
