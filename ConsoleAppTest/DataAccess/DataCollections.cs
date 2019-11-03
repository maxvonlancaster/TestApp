using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ConsoleAppTest.DataAccess
{
    // Collections are a different way of grouping data. Collections are how to store a large number of objects that are usually all the same type

    // The type of collection to use normally falls naturally from the demands of the application. If you need to store a list of values, use a List in preference 
    // to an array or ArrayList. An array is fixed in size and an ArrayList does not provide type safety. A List can only contain objects of the list type and can 
    // grow and contract. It is also very easy to remove a value from the middle of a list or insert an extra value. Use an array if you are concerned about 
    // performance and you are holding value types, since the data will be accessed more quickly. The other occasion where arrays are useful is if a program 
    // needs to store two-dimensional data (for example a table of values made up of rows and columns). In this situation you can create an object that implements	
    // a row (and contains a List of elements in the row) and then stores a List of these objects. If there is an obvious value in an object upon which it can be
    // indexed (for example an account number or username), use a dictionary to store the objects and then index on that value. A dictionary is less useful 
    // if you need to locate a data value based on different elements, such as needing to find a customer based on their customer ID, name, or address. In that	
    // case, put the data in a List and then use LINQ queries on the list to locate items. Sets can be useful when working with tags. Their built-in operations 
    // are much easier to use than writing your own code to match elements together. Queues and stacks are used when the needs of the application require FIFO	
    // or LIFO behavior. 
    public class DataCollections
    {
        // 55 An array is the simplest way to create a collection of items of a particular type. An array is assigned a size when it is created and the elements	
        // in the array are accessed using an index or subscript value. An array instance is a C# object that is managed by reference. A program creates an	array
        // by declaring the array variable and then making the variable refer to an array instance. Square brackets ([ and ]) are used to declare the array and	
        // also create the array instance.
        // An array of value types (for example an array of integers) holds the values themselves within the array, whereas for an array of reference types 
        // (for example an array of objects) each element in the array holds a reference to the object. When an array is created, each element in the array 
        // is initialized to the default value for that type. Numeric elements are initialized to 0, reference elements to null, and Boolean elements to false.
        // Arrays implement the IEnumerable interface, so they can be enumerated using the foreach construction. Once created, an array has a fixed length that	
        // cannot be changed, but an array reference can be made to refer to a new array object. An array can be initialized when it is created. An array 
        // provides a Length property that a program can use to determine the length of the array. 
        // Any array that uses a single index to access the elements in the array is called a one dimensional array.
        public void ArrayExample()
        {
            // array of integers
            int[] intArray = new int[5];
            intArray[0] = 99;
            intArray[4] = 100;

            // use index to work through the array
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            // use foreach
            foreach (int elem in intArray)
            {
                Console.WriteLine(elem);
            }

            // initialize new array
            intArray = new int[] { 1, 2, 3, 4 };

            // Multidimansional arrays
            string[,] compass = new string[3, 3]
            {
                { "NW", "N", "NE" },
                { "W", "C", "E" },
                { "SW", "S", "SE" }
            };
            Console.WriteLine(compass[0, 0]); // prints NW
            Console.WriteLine(compass[2, 2]); // prints SE

            // Jagged arrays
            // You can view a two-dimensional array as an array of one dimensional arrays. A “jagged array” is a two-dimensional array in which each 
            // of the rows are a different length.
            int[][] jaggedArray = new int[][]
            {
                new int[]{ 1, 2, 3, 4, 4 },
                new int[]{ 5, 6},
                new int[]{ 0, 0, -1, 300, 300, 100, 0, 0, 0 }
            };
        }

        // 56 The usefulness of an array is limited by the way you must decide in advance the number of items that are to be stored in the array. The size of	
        // an array cannot be changed once it has been created (although you can use a variable to set the dimension of the array if you wish). The ArrayList 
        // class was created to address this issue. An ArrayList stores data in a dynamic structure that grows as more items are added to it. 
        // Items in an ArrayList are managed by reference and the reference that is used is of type	object. This means that an ArrayList can hold references	
        // to any type of object, since the object type is the base type of all of the types in C#. However, this can lead  some programming difficulties.	
        public void UseArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add("string");
            arrayList.Insert(index: 4, value: "value");

            foreach (var elem in arrayList)
            {
                Console.WriteLine(elem);
            }
        }


        // 57 The List type makes use of the “generics” features of C#.
        // When a program creates a List the type of data that the list is to hold is specified using C# generic notation. Only references of the specified type 
        // can be added to the list, and values obtained from the list are of the specified type. The List type implements the ICollection and IList interfaces.
        public void UseList()
        {
            List<string> names = new List<string>();
            names.Add("Adam");
            names.Add("Bob");

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            names[0] = "Fred";
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }


        // 58 A Dictionary allows you to access data using a key. The name Dictionary is very appropriate.If you want to look up a definition of a word, you find    
        // the word in a dictionary and read the definition.In the case of an application, the key might be an account number or a username. The data can be a 
        // bank account or a user record.
        public void DictionaryExample()
        {
            string a1 = "Account 1";
            string a2 = "Account 2";
            Dictionary<int, string> bank = new Dictionary<int, string>();
            bank.Add(1, a1);
            bank.Add(2, a2);

            Console.WriteLine(bank[1]);
            if (bank.ContainsKey(2))
                Console.WriteLine("Account located");
        }

        // 59 how to use a dictionary to count the frequency of words in a document.
        public void WordCounter()
        {
            // Writing to a file
            FileStream outputStream = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string outPutMessageString = @"Did you ever hear the Tragedy of Darth Plagueis the wise? I thought not. It's not a story the Jedi would tell you. 
                                            It's a Sith legend. Darth Plagueis was a Dark Lord of the Sith, so powerful and so wise he could use the Force to 
                                            influence the midichlorians to create life... He had such a knowledge of the dark side that he could even keep the 
                                            ones he cared about from dying. The dark side of the Force is a pathway to many abilities some consider to be 
                                            unnatural. He became so powerful... the only thing he was afraid of was losing his power, which eventually, 
                                            of course, he did. Unfortunately, he taught his apprentice everything he knew, then his apprentice killed him 
                                            in his sleep. It's ironic he could save others from death, but not himself.";
            byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outPutMessageString);
            outputStream.Write(outputMessageBytes);
            outputStream.Close();

            Dictionary<string, int> counters = new Dictionary<string, int>();
            string text = File.ReadAllText("input.txt");
            string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string lowWord = word.ToLower();
                if (counters.ContainsKey(lowWord))
                    counters[lowWord]++;
                else
                    counters.Add(lowWord, 1);
            }

            var items = from pair in counters
                        orderby pair.Value descending
                        select pair;
            foreach (var pair in items)
            {
                Console.WriteLine("{0}:	{1}", pair.Key, pair.Value);
            }
        }

        // 60 A set is an unordered collection of items. Each of the items in a set will be present only once. You can use a set to contain tags or attributes	
        // that might be applied to a data item.	
        // Some programming languages, such as Python and Java, provide a set type that is part of the language. C# doesn’t have a built-in set type, but the 
        // HashSet class can be used to implement sets
        public void SetExample()
        {
            HashSet<string> listOne = new HashSet<string>();
            listOne.Add("a");
            listOne.Add("b");
            listOne.Add("c");
            listOne.Add("f");

            HashSet<string> listTwo = new HashSet<string>();
            listTwo.Add("d");
            listTwo.Add("e");
            listTwo.Add("f");

            HashSet<string> search = new HashSet<string>();
            search.Add("d");
            search.Add("e");

            if (search.IsSubsetOf(listOne))
            {
                Console.WriteLine("subset of listOne"); // will not be printed
            }

            if (search.IsSubsetOf(listTwo))
            {
                Console.WriteLine("subset of listTwo"); // will be printed
            }
            // Another set methods can be used to combine set values to produce unions, differences, and to test supersets and subsets. 
        }

        // 61 A queue provides a short term storage for data item. It is organized as a first-infirst-out (FIFO) collection. Items can be added to the queue using	
        // the Enqueue method and read from the queue using the Dequeue method. There is also a Peek method that allows a program to look at an item at the top of	
        // the queue without removing it from the queue.A program can iterate through the items in a queue and a queue also provides a Count property that will 
        // give the number of items in the queue.
        public void QueueExample()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");

            Console.WriteLine(queue.Dequeue()); // A
            Console.WriteLine(queue.Dequeue()); // B
        }

        // 62 A	stack is very similar in use to a queue. The most important difference is that a stack is organized as last-in-first-out (LIFO). A program can	
        // use the Push method to push items onto the top of the stack and the Pop method to remove items from the stack.	
        public void StackExample()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");

            Console.WriteLine(stack.Pop()); // B
            Console.WriteLine(stack.Pop()); // A
        }

        // 63 The examples that you have seen have added values to collections by calling the collection methods to add the values. For example, use the Add 
        // method to add items to a List. However, there are quicker ways to initialize each type of object.
        public void CollectionInitialization()
        {
            int[] arrayInt = { 1, 2, 3, 4 };
            ArrayList arrayList = new ArrayList { 1, "string", new ArrayList(), true };
            List<int> listInt = new List<int> { 1, 2, 3, 4 };
            Dictionary<int, string> dictionary = new Dictionary<int, string>
            {
                { 1, "A" },
                { 2, "B" }
            };
            HashSet<string> set = new HashSet<string> { "A", "B", "C" };
            Queue<string> queue = new Queue<string> ( new string[] { "A", "B", "C" } );
            Stack<string> stack = new Stack<string>(new string[] { "A", "B", "C" });
        }

        // 64 The array class does not provide any methods that can add or remove elements. The size of an array is fixed when the array is created. The only 
        // way to modify the size of an existing array is to create a new array of the required type and then copy the elements from one to the other. The array 
        // class provides a CopyTo method that will copy the contents of an array into another array. The first parameter of CopyTo is the destination array. 
        // The second parameter is the start position in the destination array for the copied values.	
        public void GrowAnArray()
        {

        }

        // 65 
        public void ListModification()
        {

        }

        // 66 
        public void DictionaryModification()
        {

        }

        // 67 
        public void SetModification()
        {

        }

        // 68 
        public void CustomCollection()
        {

        }

        // 69 
        public void ICollectionInterface()
        {

        }
    }
}
