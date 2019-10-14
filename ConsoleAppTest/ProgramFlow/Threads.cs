using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAppTest.ProgramFlow
{
    // Threads	are	a	lower	level	of	abstraction	than	tasks.	A	Task	object	represents	an item	of	work	to	be	performed,	
    // whereas	a	Thread	object	represents	a	process running	within	the	operating	system. 

    // Threads	are	created	as	foreground	processes	(although	they	can	be	set	to	run in	the	background).	
    // The	operating	system	will	run	a	foreground	process	to completion,	which	means	that	an	application	will	not	terminate	
    // while	it contains an  active foreground  thread.A foreground  process that    contains an infinite loop    will execute forever,	
    // or until   it throws  an uncaught    exception or    the operating   system terminates  it.Tasks are created	as	background processes. 
    // This    means that    tasks can be terminated  before they    complete    if all the foreground threads in an application complete. 
    // Threads have    a priority    property that    can be  changed during  the lifetime    of the  thread. 
    // It  is	not possible    to set the priority    of a   task.This gives   a thread  a higher    priority request so a   greater portion of available   
    // processor time	is allocated.A thread  cannot deliver a result  to another thread.Threads must communicate by  using	shared	variables,	
    // which can introduce synchronization   issues.It	is	not possible    to create  a continuation    on a   thread.
    // Instead,	threads provide a method  called a   join,	which allows  one thread  to pause   until another   completes.
    // It	is	not possible    to aggregate   exceptions over    a number  of threads.An exception thrown  inside a   thread must   
    // be caught  and dealt   with by  the code in that thread.	Tasks provide exception aggregation, but threads don’t.
    public class Threads
    {
        private void ThreadHello()
        {
            Console.WriteLine("Hello	from	the	thread");
            Thread.Sleep(2000);
        }

        // The	Thread	class	is	located	in	the	System.Threading	namespace.	
        // When you	create	a	Thread	you	can	pass	the	constructor	the	name	of	the	method	the thread	will	run.	
        // Once	the	thread	has	been	created,	you	can	call	the	Start method	on	the	thread	to	start	it	running.	
        public void CreateThreads()
        {
            Thread thread = new Thread(ThreadHello);
            thread.Start();
        }

        // Note	that earlier versions of .NET required the creation	of a ThreadStart delegate to specify the method to be executed by the thread.	
        // The	ThreadStart	delegate	is	no	longer	required. 
        public void CreateThreadStart()
        {
            ThreadStart ts = new ThreadStart(ThreadHello);
            Thread thread = new Thread(ts);
            thread.Start();
        }

        // It	is	possible	to	start	a	thread	using	a	lambda	expression	to	specify	the	action	of the	thread
        // 
        public void CreateThreadWithLambda()
        {
            Thread thread = new Thread(() => 
            {
                Console.WriteLine("Hello	from	the	thread");
                Thread.Sleep(1000);
            });
            thread.Start();
            Console.WriteLine("Press	a	key	to	end.");
        }
    }
}
