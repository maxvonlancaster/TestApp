using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    // The phrase thread safe describes code elements that work correctly when used from multiple processes(tasks) at the same time.The standard.NET collections
    // (including List, Queue and Dictionary) are not thread safe.The.NET libraries provide thread safe (concurrent) collection classes that you can use
    // when creating multi-tasking applications:
    public class ConcurrentCollections
    {
        // From a design perspective, it is best to view a task in a multi-threaded application as either a producer or a consumer of data.A task that both produces
        // and consumes data is vulnerable to “deadly embrace” situations.If task A is waiting for something produced by task B, and task B is waiting for something
        // produced by Task A, and neither task can run. The BlockingCollection<T> class is designed to be used in situations
        // where you have some tasks producing data and other tasks consuming data.It provides a thread safe means of adding and removing items to a data store.It is
        // called a blocking collection because a Take action will block a task if there are no items to be taken.A developer can set an upper limit for the size of the
        // collection.Attempts to Add items to a full collection are also blocked.
        public void UsingBlockingCollection()
        {
            // blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(5);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks
                for (int i = 0; i < 11; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added", i);
                }
                // indicate we have nothing more to add
                data.CompleteAdding();
            });
            Console.WriteLine("Reading collection");
            Task.Run(() =>
            {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });
            // output 01234 added, 01234 taken, 56789 added, 56789 taken

            // The adding task calls the CompleteAdding on the collection when it has added the last item. This prevents any more items from being added to the
            // collection.The task taking from the collection uses the IsCompleted property of the collection to determine when to stop taking items from it.The
            // IsCompleted property returns true when the collection is empty and CompleteAdding has been called. Note that the Take operation is performed
            // inside try–catch construction.The Take method can throw exception
            // The BlockingCollection class provides the methods TryAdd and TryTake that can be used to attempt an action.Each returns true if the action succeeded.
        }

        // The BlockingCollection class can act as a wrapper around other concurrent collection classes, including ConcurrentQueue, ConcurrentStack, and ConcurrentBag.
        public void BlockConcurrentStack()
        {
            BlockingCollection<int> data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);
            // If you execute this example you will see that items are added and taken from the stack on a “last in–first out” basis.If you don’t provide a collection class the
            // BlockingCollection class uses a ConcurrentQueue, which operates on a “first in-first out” basis.The ConcurrentBag class stores items in an unordered collection.
        }

        // The ConcurrentQueue class provides support for concurrent queues. The Enqueue method adds items into the queue and the TryDequeue method
        // removes them.Note that while the Enqueue method is guaranteed to work (queues can be of infinite length) the TryDequeue method will return false if
        // the dequeue fails.A third method, TryPeek, allows a program to inspect the element at the start of the queue without removing it.Note that even if the
        // TryPeek method returns an item, a subsequent call of the TryDequeue method in the same task removing that item from the queue would fail if the item is removed by another task.
        public void ConcurrentQueue()
        {
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            string str;
            if (queue.TryPeek(out str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if (queue.TryDequeue(out str))
            {
                Console.WriteLine("Dequeue: {0}", str);
            }
            // will output "A"
        }

        // The ConcurrentStack class provides support for concurrent stacks. The Push method adds items onto the stack and the TryPop method removes them.
        // There are also methods, PushRange and TryPopRange, which can be used to push or pop a number of items.
        public void ConcurrentStack()
        {
            ConcurrentStack<string> stack = new ConcurrentStack<string>();
            stack.Push("A");
            stack.Push("B");
            string str;
            if (stack.TryPeek(out str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if (stack.TryPop(out str))
            {
                Console.WriteLine("Dequeue: {0}", str);
            }
            // will output "B"
        }

        // You can use a ConcurrentBag to store items when the order in which they are added or removed isn’t important.The Add items puts things into the bag,
        // and the TryTake method removes them. There is also a TryPeek method, but this is less useful in a ConcurrentBag because it is possible that a following
        // TryTake method returns a different item from the bag.
        public void ConcurrentBag()
        {
            ConcurrentBag<string> bag = new ConcurrentBag<string>();
            bag.Add("A");
            bag.Add("B");
            string str;
            if (bag.TryPeek(out str))
            {
                Console.WriteLine("Peek: {0}", str);
            }
            if (bag.TryTake(out str))
            {
                Console.WriteLine("Dequeue: {0}", str);
            }
        }

        // A dictionary provides a data store indexed by a key. A ConcurrentDictionary can be used by multiple concurrent tasks.Actions
        // on the dictionary are performed in an atomic manner.In other words, an update action on an item in the dictionary cannot be interrupted by an action from
        // another task.A ConcurrentDictionary provides some additional methods that are required when a dictionary is shared between multiple tasks.
        public void ConcurrentDictionary()
        {
            ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();
            if (ages.TryAdd("A", 20))
            {
                Console.WriteLine("A added succesfully");
            }
            Console.WriteLine("A age: {0}", ages["A"]);
            // set age of A to 21 if it is 20
            if (ages.TryUpdate("A", 21, 20))
            {
                Console.WriteLine("Age updated succesfully");
            }
            Console.WriteLine("A age: {0}", ages["A"]);
            // Increment age automatically using factory mathod
            Console.WriteLine("Age updated to: {0}", ages.AddOrUpdate("A", 1, (name, age) => age = age + 1));
            Console.WriteLine("A age: {0}", ages["A"]);
        }
    }
}
