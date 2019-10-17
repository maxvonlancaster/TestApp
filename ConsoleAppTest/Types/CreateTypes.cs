using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class CreateTypes
    {
        struct StructStore
        {
            public int Data { get; set; }
        }

        class ClassStore
        {
            public int Data { get; set; }
        }

        struct Alien
        {
            public int X;
            public int Y;
            public int Lives;

            public Alien(int x, int y)
            {
                X = x;
                Y = y;
                Lives = 3;
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }

        public enum AlienState
        {
            Sleeping,
            Attacking,
            Destroyed
        }

        public enum AlienStateByte : Byte
        {
            Sleeping = 1,
            Attacking = 2,
            Destroyed = 4
        }

        class AlienClass
        {
            public int X; public int Y; public int Lives;
            public AlienClass(int x, int y) { X = x; Y = y; Lives = 3; }
            public override string ToString() { return string.Format("X:	{0}	Y:	{1}	Lives:	{2}", X, Y, Lives); }
        }

        class MyStack<T> where T : class
            // If you want to restrict it to only store reference types you can add constraint on possible types that T can represent.
        {
            int stackTop = 0;
            T[] items = new T[100];

            public void Push(T item)
            {
                if (stackTop == items.Length) throw new Exception("Stack	full");
                items[stackTop] = item; stackTop++;
            }

            public T Pop()
            {
                if (stackTop == 0) throw new Exception("Stack	empty");
                stackTop--;
                return items[stackTop];
            }

            // where	T	: new() ->   The type    T must    have a   public,	parameterless,	constructor
            // where	T	: <base	class> ->  The type    T must    be of  type	base	class or  derive from	base	class.
            // where   T	: <interface name> -> The type    T must    be or  implement the specified interface.	You can specify multiple    interfaces.
            // where T	: unmanaged ->  The type T   must not be a   reference type    or contain any members which are reference types.
        }

        class AlienClassConstr
        {
            public int X;
            public int Y;
            public int Lives;

            public AlienClassConstr() : this(1, 1, 3)
            {
                // A program can avoid   code repetition  by making  one constructor call another constructor by  use of  the keyword this.
                // 	It	forms	a	call	of	another constructor	in	the	object.	In	the	program	below	the	parameters	to	the	call	
                // of	one constructor	are	passed	into	a	call	of	another,	along	with	an	additional	lives	value. 
                // Note	that	this	means	the	actual	body	of	the	constructor	is	empty,	because	all	of the	work	is	performed	
                // by	the	call	to	the	other	constructor.	Another	way	to provide	default	values	to	a	constructor	is	to	make	
                // use	of	optional	parameters.
                // When	creating	objects	that	are	part	of	a	class	hierarchy,	a	programmer	must ensure	that	
                // information	required	by	the	constructor	of	a	parent	object	is	passed into	a	parent	constructor.
            }

            public AlienClassConstr(int x, int y)
            {
                if (x < 0 || y < 0)
                    throw new Exception("Invalid coordinates");
                X = x;
                Y = y;
                Lives = 3;
            }

            public AlienClassConstr(int x, int y, int lives)
            {
                X = x;
                Y = y;
                Lives = lives;
            }

            public override string ToString() { return string.Format("X:	{0}	Y:	{1}	Lives:	{2}", X, Y, Lives); }
        }

        // A class can contain a static constructor method. This is called once before the creation of the very first instance of the class.	
        class AlienStaticConstructor
        {
            static AlienStaticConstructor()
            {
                // When	the program	runs,	the	message	is	printed	once,	before	the	first	alien	is	created.	
                // The static	constructor	is	not	called	when	the	second	alien	is	created.
                Console.WriteLine("Static	Alien	constructor	running");
            }
            // A static constructor is a good place to load resources and initialize values  will be used by instances of the class.	
            // This	can	include	the	values	of	static members	of	the	class,	as	described	in	the	next	section. 
        }



        /// <summary>
        /// /////////////////
        /// </summary>


        // The diff between reference and value types is crucial
        public void ValueAndReferenceTypes()
        {
            StructStore xs, ys;
            ys = new StructStore();
            ys.Data = 99;
            xs = ys;
            xs.Data = 100;
            Console.WriteLine("xStruct:	{0}", xs.Data); // 100
            Console.WriteLine("yStruct:	{0}", ys.Data); // 99

            ClassStore xc, yc;
            yc = new ClassStore();
            yc.Data = 99;
            xc = yc;
            xc.Data = 100;
            Console.WriteLine("xClass:	{0}", xc.Data); // 100
            Console.WriteLine("yClass:	{0}", yc.Data); // 100
        }

        // immutable - instances can not be changed
        // 
        // 
        public void ImmutableTypes()
        {
            //	Create	a	DateTime	for	today 
            DateTime date = DateTime.Now;
            //	Move	the	date	on	to	tomorrow 
            date = date.AddDays(1); // does not change content of type - creates new date
        }

        // Value types: structures and enums
        // Structures	can	contain	methods,	data	values,	properties	and	can	have constructors.
        // The constructor must initialize all data members in structure
        // 
        public void CreateStruct()
        {
            Alien a;
            a.X = 50;
            a.Y = 50;
            a.Lives = 3;
            Console.WriteLine("a	{0}", a.ToString());

            Alien x = new Alien(100, 100);
            Console.WriteLine("x	{0}", x.ToString());

            Alien[] swarm = new Alien[100];
            Console.WriteLine("swarm	[0]	{0}", swarm[0].ToString());
            Console.ReadKey();
        }

        // Enumerated types are used in situations where the programmer wants to specify a range of values that a given type can have.	
        // Unless	specified	otherwise,	an	enumerated	type	is	based	on	the	int	type	and the	enumerated	values	are	numbered	
        // starting	at	0.	You	can	modify	this	by	adding extra	information	to	the	declaration	of	the	enum. 
        public void CreateEnum()
        {
            AlienState a = AlienState.Sleeping;
            Console.WriteLine(a); // prints	the	ToString result returned by the	AlienState variable, which	will output	the	string "Sleeping"
            // Also can use casting to int to have numeric value printed
        }

        // The	basis	of	C#	reference	types	is	the	C#	class.	A	class	is	declared	in	a	very similar	
        // manner	to	a	structure,	but	the	way	that	classes	are	manipulated	in	a program	is	significantly	different.	
        // The	use	of	the	new	keyword to	create	a	new	object	is	said	to	create	a	new	instance	of	a	class.
        public void CreateReference()
        {
            AlienClass x = new AlienClass(100, 100);
            Console.WriteLine("x	{0}", x);
            AlienClass[] swarm = new AlienClass[100];
            for (int i = 0; i < swarm.Length; i++)
                swarm[i] = new AlienClass(0, 0);

            Console.WriteLine("swarm	[0]	{0}", swarm[0]);
        }

        // Memory	to	be	used	to	store	variables	of	value	type	is	allocated	on	the	stack.	The stack	
        // is	an	area	of	memory	that	is	allocated	and	removed	as	programs	enter	and leave	blocks.	
        // Any	value	type	variables	created	during	the	execution	of	a	block are	stored	on	a	local	
        // stack	frame	and	then	the	entire	frame	is	discarded	when	the block	completes.	
        // This	is	an	extremely	efficient	way	to	manage	memory. Memory	to	be	used	to	store	variables	of	reference	type	
        // is	allocated	on	a different	structure,	called	the	heap.	The	heap	is	managed	for	an	entire application.	
        // The	heap	is	required	because,	as	references	may	be	passed	between method	calls	as	parameters,	
        // it	is	not	the	case	that	objects	managed	by	reference can	be	discarded	when	a	method	exits.	
        // Objects	can	only	be	removed	from	the heap	when	the	garbage	collection	process	determines	that	
        // there	are	no	references to	them.

        // Generic	types	are	used	extensively	in	C#	collections,	such	as	with	the	List	and Dictionary	classes.	
        // They	allow	you	to	create	a	List	of	any	type	of	data,	or a	Dictionary	of	any	type,	indexed	on	any	type.
        // Without	generic	types	you	either	have	to	reduce	the	type	safety	in	your programs	by	using	collections	that	
        // manage	only	objects,	or	you	have	to	waste	a lot	of	time	creating	different	collection	classes	for	each	
        // different	type	of	data	that you	want	to	store. 
        // 
        public void UsingGenericTypes()
        {
            MyStack<string> nameStack = new MyStack<string>();
            nameStack.Push("Rob");
            nameStack.Push("Mary");
            Console.WriteLine(nameStack.Pop());
            Console.WriteLine(nameStack.Pop());
            Console.ReadKey();
        }

        // A	constructor	allows	a	programmer	to	control	the	process	by	which	objects	are created.	
        // Constructors	can	be	used	with	value	types	(structures)	and	reference types	(classes).	
        // A	constructor	has	the	same	name	as	the	object	it	is	part	of	but does	not	have	a	return	type. 
        // Constructors	can	perform	validation	of	their	parameters	to	ensure	that	any objects	that	are	created	contain	valid	information.	
        // If	the	validation	fails,	the constructor	must	throw	an	exception	to	prevent	the	creation	of	an	invalid	object.
        public void CreateConstructors()
        {
            AlienClassConstr x = new AlienClassConstr(100, 100);
            Console.WriteLine("x	{0}", x);
            // Constructors	can	be	given	access	to	modifiers.	If	an	object	only	has	a	private	constructor	it	cannot	be instantiated	
            // unless	the	object	contains	a	public	factory	method	that	can	be	called to	create	instances	of	the	class. 
        }

        // Constructors	can	be	overloaded,	so	an	object	can	contain	multiple	versions	of a constructor with different   signatures
        public void OverloadedConstructors()
        {
            AlienClassConstr x = new AlienClassConstr(100, 100, 4);
        }

        // A static variable is a member of a type, but it is not created for each instance of a
        // type.A variable in a class is made static by using the keyword static in the
        // declaration of that variable.
        // 
        public class StaticVariables
        {
            public static int Max_Lives = 99;
            public int Lives;

            public StaticVariables(int lives)
            {
                if (lives > Max_Lives)
                    throw new Exception("Invalid value");
                Lives = lives;

                // Making a variable static does not stop it from being changed when the program runs(to achieve this use the const keyword or make the variable
                // readonly). Rather, the word static in this context means that the variable is “always present.” A program can use a static variable from a type without
                // needing to have created any instances of that type. Types can also contain static methods.These can be called without the need for an instance of the object
                // containing the method.Libraries of useful functions are often provided as static members of a library class.
            }

            // The name of a method is best expressed in a “verb-noun” manner, with an action followed by the thing that the action is acting on.Names such as
            // “DisplayMenu,” “SaveCustomer,” and “DeleteFile” are very descriptive of what the method does. When talking about the method signature and the code body of
            // a method we will talk in terms of the parameters used in the method. In the case of the call of a method we will talk in terms of the arguments supplied to the call.
            public bool RemoveLives(int livesToRemoves)
            {
                Lives -= livesToRemoves;
                if (Lives <= 0)
                {
                    Lives = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // A method is a member of a class. It has a signature and a body. The signature defines the type and number of parameters that the method will accept.
        // The body is a block of code that is performed when the method is called. If the method has a type other than void, all code paths through the body of the code
        // must end with a return statement that returns a value of the type of the method.
        public void SimpleMethods()
        {
            StaticVariables x = new StaticVariables(10);
            Console.WriteLine("x = {0}", x);
            if (x.RemoveLives(2))
            {
                Console.WriteLine("Still alive");
            }
            else
            {
                Console.WriteLine("Alien destroyed");
            }
            Console.WriteLine("x = {0}", x);
        }

        static int ReadValue(int low, int high, string prompt)
        {
            return 100;
        }

        static int ReadValueDefault(int low, int high, string prompt = "")
        {
            return 100;
        }

        // When you create a method with parameters, the signature of the method gives the name and type of each parameter in turn
        public void NamedParameters()
        {
            int x = ReadValue(low:1, high:2, prompt:"");
            // you can change the definition of the method to give a default value for the prompt parameter
            // Optional parameters must be provided after all of the required ones.
            x = ReadValueDefault(1, 2);
        }

        class IntArrayWrapper
        {
            private int[] array = new int[100];

            public int this[int i]
            {
                get { return array[i]; }
                set { array[i] = value; }
            }
        }

        // A class can use the same indexing mechanism to provide indexed property values.
        // Note that there is nothing stopping the use of other types in indexed properties.This is how the Dictionary collection is used to index on a
        // particular type of key value.
        public void IndexedProperties()
        {
            IntArrayWrapper x = new IntArrayWrapper();
            x[0] = 99;
            Console.WriteLine(x[0]);
        }

        class NamedIntArrayWrapper
        {
            private int[] array = new int[100];

            public int this[string name]
            {
                get
                {
                    switch (name)
                    {
                        case "zero":
                            return array[0];
                        case "one":
                            return array[1];
                        default:
                            return -1;
                    }
                }
                set
                {
                    switch (name)
                    {
                        case "zero":
                            array[0] = value;
                            break;
                        case "one":
                            array[1] = value;
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        // an indexer property that is extended to allow all of the elements in the integer array to be accessed by name.
        public void IndexingOnStrings()
        {
            NamedIntArrayWrapper x = new NamedIntArrayWrapper();
            x["zero"] = 99;
            Console.WriteLine(x["zero"]);
        }

    }

    // However, extension methods provide a way in which behaviors can be added to a class without needing to extend the class itself. 
    // The first parameter to the method specifies the type that the extension method should be added to, by using the keyword this followed by the name of the type.
    // Extension methods allow you to add behaviors to existing classes and use them as if they were part of that class. They are very powerful. 
    // LINQ query operations are added to types in C# programs by the use of extension methods.
    public static class ExtensionMethods
    {
        public static int LineCount(this String str)
        {
            return str.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
