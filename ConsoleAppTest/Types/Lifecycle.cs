using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAppTest.Types
{
    // the	.NET framework	that	underpins	C#	programs	provides	a	managed	environment	for	our programs	that	perform	memory	management	
    // in	the	form	of	a	garbage	collection process	that	will	remove	unwanted	objects	without	us	having	to	do	anything.
    // When	writing	programs	in	unmanaged	languages,	such	as	C++,	you	need	to include	code	to	create	and	dispose	of	any	objects	that	
    // programs	use.	If	this	is	not done	properly	one	of	two	things	will	happen.	A	program	will	try	to	use	a memory	object	that	
    // has	been	deleted	which	will	cause	the	program	to	crash,	or	a program	will	fail	to	dispose	of	memory	correctly,	leading	to	a	
    // “memory	leak,” which	will	eventually	cause	the	program	to	run	out	of	available	memory. You	might	think	that	the	fact	that	C#	
    // is	based	on	the	.NET	framework,	which provides	automatic	memory	management,	would	make	this	a	very	short	skill;	but it	
    // turns	out	that	our	programs	must	also	deal	with	“unmanaged”	resources.	For example,	a	program	might	create	an	object	
    // that	contains	a	handle	to	a	file	or	a database	connection	that	connect	it	to	a	particular	resource.	The	program	must make	
    // sure	that	when	this	object	is	destroyed,	any	resources	connected	to	the object	must	be	released	in	a	managed	way.	
    // C#	provides	a	finalization	process that	allows	code	in	an	object	to	get	control	as	it	is	being	removed	from	memory. 
    // C#	also	allows	an	object	to	implement	an	IDisposable	interfac
    public class Lifecycle
    {
        class PersonBig
        {
            long[] personArray = new long[1000000];
        }

        // The precise way that memory is managed in a .NET application has a significant bearing on how to create objects that manage resources correctly.	
        public void GarbageCollection()
        {
            // Consider	the	following	two	C#	statements.	The	first	statement	declares	a Person	reference	called	p	and	makes	the	reference	
            // refer	to	a	new	Person
            // instance.The second  statement assigns the reference   p to  a   new Person instance.These two statements will    
            // cause work    for the garbage collector.The first   Person  object  that    was created can play    no  further part	in	the program 
            // as there is no way of  accessing   it.
            Person p = new Person();
            p = new Person();
            // You	get	a	similar	situation	when	a	reference	variable	goes	out	of	scope.	This block	of	code	that	follows	also	
            // creates	work	for	the	garbage	collector.	When	the program	exits	from	the	block	the	Person	object	that	was	created	it	is	
            // no	longer accessible	because	the	reference	person	no	longer	exists.	However,	the	Person	object will	still	be	occupying	memory. 
            {
                Person person = new Person();
            }

            // A	process	has	a	particular	amount	allocated	to	it.	Garbage	collection	only occurs	when	the	amount	of	memory	
            // available	for	new	objects	falls	below	a threshold.	
            for (long i = 0; i < 100000000000; i++)
            {
                PersonBig personBig = new PersonBig();
                Thread.Sleep(3);
            }

            // The	heap	is	the	area of	memory	where	an	application	stores	objects	that	are	referred	to	by	reference. 
            // The	contents	of	value	types	are	stored	on	the	stack.	The	stack	automatically grows	and	contracts	as	programs	run.	
            // Upon	entry	to	a	new	block	the	.NET runtime	will	allocate	space	on	the	stack	for	values	that	are	declared	local	
            // to	that block.	When	the	program	leaves	the	block	the	.NET	runtime	will	automatically contract	the	stack	space,	
            // which	removes	the	memory	allocated	for	those variables.	The	following	block	will	not	make	any	work	for	the	
            // garbage	collector as	the	value	99	will	be	stored	in	the	local	stack	frame. 
            {
                int i = 99;
            }

            // When	an	application	runs	low	on	memory	the	garbage	collector	will	search	the heap	for	any	objects	that	are	no	longer	
            // required	and	remove	them.	The	.NET runtime	contains	an	index	of	all	the	objects	that	have	been	created	since	the 
            // program	started,	the	job	of	the	garbage	collector	is	to	decide	which	of	them	are
            // still   in	use,	remove them    from memory, and then compact the remaining   objects so  that the area of  free memory  is a single  
            // large area, rather  than a   number of smaller,	free areas. The first   phase of  garbage collection  is marking all of the objects that    
            // are in use by  the program.	The garbage collector starts  by clearing    a flag    on each object in	the heap.	It then    searches
            // through all the variables   in	use in	the program and follows all the references  in	these variables   to the objects they    refer to  
            // and sets    the flag    on that    object.After   this    “mark”	phase the garbage collector   can now move on  to the	“compact”	phase of 
            // the collection, where   it works   through memory  removing all the objects that have    not had their flag    set.The final   phase of  
            // the garbage collection is the “compaction”	of the heap.The objects still   in	use must    be moved   down memory  so that    the available   
            // space on the stack   is  in	one large   block,	rather than    a large   number of  holes where   unused objects  have been    removed.
            // All managed threads are suspended   while   the garbage collector   is running.This means   that your    application will    stop responding 
            // to inputs  while   the garbage collection  is performed.It is possible to  invoke the garbage collector manually  if  there   are points	in	
            // your application when you know a   large number of objects have been    released.The garbage collector attempts    to determine   which objects 
            // are long lived, and which are short lived(ephemeral).	It does    this    by adding  a generation  counter to each object on  the heap.	
            // Objects start   at generation  0.If  they survive a garbage collection the counter is advanced to  generation  1.Surviving   a second  
            // garbage collection  promotes an  object to  generation  2,	the highest generation.The garbage collector will    collect different  
            // generations,	depending on  circumstances.A    “level  2”	garbage collection  will involve all objects.	A   “level  0”	garbage collection 
            // will target  newly created objects.The garbage collector can run in	“workstation”	or  “server”	modes,	depending on    the role   
            // of the host system.	There is also an  option to  run garbage collection concurrently on a   separate thread.	However,	this   
            // increases the amount of memory used    by the garbage collector   and the loading on  the host    processor.

            // Modern	applications	run	in	systems	with	large	amounts	of	memory	available. The	garbage	collection	process	has	been	
            // optimized	over	the	various	generations of	.NET	and	is	now	highly	efficient	and	responsive.	My	strong	advice	
            // on garbage	collection	is	not	to	worry	about	it	until	you	have	a	problem.	There	is	no
            // need to  spend your    time worrying    about the memory usage   of your    application when    your system  will almost  
            // certainly have    enough memory  and processor performance.You can use the displays produced    by Visual  Studio to  
            // watch how your application uses memory, there   are also    profiling tools   that allow   you to identify the objects that   
            // are affected    by garbage collection.If you find that    the garbage collection process is becoming intrusive   you can force a 
            // garbage collection  by calling the Collect method on  the garbage collector as shown   below.

            GC.Collect();

            // The enforced    garbage collection  can be  performed at  points  in	your application    where you know large   objects have    just been  
            // released,	for example at the  end of  a   transaction or  upon    exit    from a large   and complex user    interface dialog.	
            // However,	under normal  circumstances I   would strongly    advise you to let the garbage collector look    after itself.
            // It  is	rather good    at doing   that.

        }

        // The	.NET	framework	will	take	care	of	the	creation	and	destruction	of	our objects,	but	we	need	to	manage	the	
        // resources	that	our	objects	use.	For	example, if	an	application	creates	a	file	handle	and	stores	it	in	an	object,	when	
        // then	object is	destroyed	the	file	handle	will	be	lost.	If	the	file	connected	to	the	handle	is	not closed	properly	
        // before	the	object	is	destroyed,	the	file	the	handle	is	connected	to will	not	be	usable. There	are	two	mechanisms	that	we
        // can	use	that	allow	us	to	get	control	at	the point	an	object	is	being	destroyed	and	tidy	up	any	resources	that	
        // the	object	may be	using.	They	are	finalization	and	disposable. 


        // The	finalization	of	an	object	is	triggered	by	the	garbage	collection	process.	An object	can	contain	a	finalizer	method	
        // that	is	invoked	by	the	garbage	collector	in advance	of	that	object	being	removed	from	memory.	This	method	gets	
        // control and	can	release	any	resources	that	are	being	used	by	that	object.	The	finalizer method	is	given	as	a	
        // type	less	method	with	the	name	of	the	class	pre-ceded	by	a tilde	(~)	character. 	in	an	application	you would	use	this	
        // method	to	release	any	resources	that	the	Person	object	had allocated.
        // When	the	garbage	collector	is	about	to	remove	an	object,	it	checks	to	see	if	the object	contains	a	finalizer	method.	
        // If	there	is	a	finalizer	method	present,	the garbage	collector	adds	the	object	to	a	queue	of	objects	waiting	to	
        // be	finalized. Once	all	of	these	objects	have	been	identified,	the	garbage	collector	starts	a thread	to	execute	all	the	
        // finalizer	methods	and	waits	for	the	thread	to	complete. Once	the	finalization	methods	are	complete	the	garbage	collector	
        // performs another	garbage	collection	to	remove	the	finalized	objects.	There	are	no guarantees	as	to	when	the	finalizer	
        // thread	will	run.	Objects	waiting	to	be finalized	will	remain	in	memory	until	all	of	the	finalizer	methods	have 
        // completed	and	the	garbage	collector	has	made	another	garbage	collection	pass	to remove	them. A	slow-running	finalizer	
        // can	seriously	impair	the	garbage	collection	process. 
        public class PersonFinalizable
        {
            long[] personArray = new long[1000000];

            ~PersonFinalizable()
            {
                //	This	is	where	the	person	would	be	finalized								
                Console.WriteLine("Finalizer	called");

                //	This	will	break	the	garbage	collection	process	as	it	slows	it	down							
                //	so	that	it	can't	complete faster	than	objects	are	being	created												
                Thread.Sleep(100);
            }

            // Another	problem	with	finalization	is	that	there	is	no	guarantee	that	the  finalizer method  will ever    be called.
            // If  the program never runs    short of  memory, it might   not need    to initiate    garbage collection.	This means   that an  
            // object waiting for	deletion may remain  in memory until   the program completes
        }

        public class PersonDisposable : IDisposable
        {
            //	Flag	to	indicate	when	the	object	has	been	disposed							
            bool disposed = false;

            public void Dispose()
            {
                //	Call	dispose	and	tell	it	that	it	is	being	called	from	a	Dispose	call
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public virtual void Dispose(bool disposing)
            {
                //	Give	up	if	already	disposed												
                if	(disposed)
                    return;
                if (disposing)
                {                                                               
                    //	free	any	managed	objects	here												
                }
                //	Free	any	unmanaged	objects	here								
            }

            ~PersonDisposable()
            {
                // Dispose	only	of	unmanaged	objects
                Dispose(false);
            }
        }

        // An	object	can	implement	the	IDisposable	interface,	which means	it	must	provide	a	Dispose	method	that	can	be	called	within	
        // the application	to	request	that	the	object	to	release	any	resources	that	it	has allocated.	Note	that	the	Dispose	method	
        // does	not	cause	the	object	to	be deleted	from	memory,	nor	does	it	mark	the	object	for	deletion	by	the	garbage collector	
        // in	any	way.	Only	objects	that	have	no	references	to	them	are	deleted. Once	Dispose	has	been	called	on	an	object,	
        // that	object	can	no	longer	be	used in	an	application. Objects	that	implement	IDisposable	can	be	used	in	conjunction	with	
        // the using	statement,	which	will	provide	an	automatic	call	of	the	Dispose	method when	execution	leaves	the	block	that	
        // follows	the	using	statement. The	Dispose	method	is	called	by	the	application	when	an	object	is	required to	release	all	the
        // resources	that	it	is	using.	This	is	a	significant	improvement	on	a finalizer,	in	that	your	application	can	control
        // exactly	when	this	happens.
        // If	you	want	to	create	an	object	that	contains	both	a	finalizer	and	a	Dispose method	you	need	to	exercise	
        // some	care	to	avoid	the	object	trying	to	release	the same	resource	more	than	once,	and	perhaps	failing	as	a	
        // result	of	this.	The SuppressFinalize	method	can	be	used	to	identify	an	object,	which	will	not be	finalized	
        // when	the	object	is	deleted.	This	should	be	used	by	the	Dispose method	in	a	class	to	prevent	instances	being	
        // disposed	more	than	once.	A	dispose pattern can be used    to allow   an object to  manage its disposal.
        public void TheDisposaPattern()
        {
            PersonDisposable personDisposable = new PersonDisposable();
            personDisposable.Dispose();
        }

        // Note	that	the	using	statement	ensures	that	Dispose	is	called	on	an	object in	the	event	of	exceptions	being	thrown.	
        // If	you	don’t	use	the	using	statement	to manage	calls	of	Dispose	in	your	objects,	make	sure	that	your	
        // application	calls Dispose	appropriately.	The	dispose	pattern	above	results	in	a	disposal behavior	that	is	tolerant	of	
        // multiple	calls	of	Dispose

        public void ManageFinalizationAndGarbageCollection()
        {
            // After the collection has been performed, a   program can then be  made to  wait until   all the finalizer methods have completed:
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // Overloads of the Collect method allow you to specify which generation of objects to garbage collect and set other garbage collection options. 

            object p = new object();
            // You	have	seen	that	the	garbage	collector	can	be	ordered	to	ignore	the	finalizer	on an	object.	The	statement	below	
            // prevents	finalization	from	being	called	on	the object	referred	to	by	p. 
            GC.SuppressFinalize(p);
            // To	later	re-enable	finalization	you	can	use	the	ReRegisterforFinalize method: 
            GC.ReRegisterForFinalize(p);
        }
    }
}
