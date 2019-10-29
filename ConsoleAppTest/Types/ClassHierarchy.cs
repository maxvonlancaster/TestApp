using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    public class ClassHierarchy
    {

        // 2-33 The IPrintable interface (design and implement interface)
        // An interface in a C# program specifies how a software component could be  used by another software component.So, instead of starting to build an
        // application by designing classes.you should instead be thinking about describing their interfaces (what each software component will do). How the
        // component performs its function can be encapsulated inside the component.A C# interface contains a set of method signatures. If a class contains an  
        // implementation of all of the methds described in the interface it can be defined as “implementing” that interface. Interfaces allow a program to regard objects in
        // terms of their abilities(or the interfaces that they implement), rather than what type an object actually is.
        interface IPrintable
        {
            string GetText(int pageWidth, int pageHeight);
            string GetTitle();
        }

        class Protocol : IPrintable
        {
            public string GetText(int pageWidth, int pageHeight)
            {
                return "Report Text";
            }

            public string GetTitle()
            {
                return "Report Title";
            }
        }

        void PrintItem(IPrintable printable)
        {
            printable.GetText(10, 10);
            printable.GetTitle();
        }

        // 2-34 The IAccountInterface (Design interface)
        // You	can	build	your	knowledge	of	interfaces	
        // by considering how to create	an interface to describe the behavior of a class that will implement a bank account. 
        public interface IAccount
        {
            void PayInFunds(decimal amount);
            bool WithdrawFunds(decimal amount);
            decimal GetBalance();
            // Note	that at the interface level we are not saying how any of these tasks should be performed, but we are just identifying the tasks. 
        }
        // An	interface	is	placed	in	a	source	file	just	like	a	class,	and	compiled	in	the same	way.	
        // It	sets	out	a	number	of	methods	that	relate	to	a	particular	task	or	role, which	in	this	case	
        // is	what	a	class	must	do	to	be	considered	a	bank	account.	There is	a	convention	in	C#	programs	
        // that	the	name	of	an	interface	starts	with	the	letter I.	It	is	interesting	to	note	that	one	of	the	refactoring	
        // tools	available	in	Visual Studio	is	one	that	will	extract	the	method	signatures	from	a	class	and	create	an 
        // interface that    contains those   methods.

        class BankAccount : IAccount
        {
            protected decimal _balance = 0;

            // 	these methods are only exposed when the BankAccount object is referred to by a reference of type IAccount.
            decimal IAccount.GetBalance()
            {
                return _balance;
            }

            void IAccount.PayInFunds(decimal amount)
            {
                _balance += amount;
            }

            bool IAccount.WithdrawFunds(decimal amount)
            {
                if (_balance < amount)
                {
                    return false;
                }
                _balance = _balance - amount;
                return true;
            }

            public virtual bool WithdrowVirtual(decimal amount)
            {
                return false;
            }
        }
        // So,	with	interfaces	you	are	moving	away	from	considering	classes	in	terms	of what	they	are,	
        // and	starting	to	think	about	them	in	terms	of	what	they	can	do.	In the	case	of	your	
        // bank,	this	means	that	you	want	to	deal	with	objects	in	terms	of IAccount,	
        // (the	set	of	account	abilities)	rather	than	BankAccount	(a particular	account	class). 
        public void InterfaceDesign()
        {
            IAccount account = new BankAccount();
            account.PayInFunds(50);
            Console.WriteLine("Balance:	" + account.GetBalance());
        }


        // 2-35 BabyAccount (Inherit from a base class)
        // One	of	the	fundamental	principles	of	software	development	is	to	ensure	that	you create	every	piece	of	code	
        // in	an	application	precisely	once.	Rather	than	copying code	from	one	part	of	a	program	to	another,	
        // you	would	create	a	method	and	then call	that	method. The	reason	to	do	this	is	quite	simple.	If	you	find	
        // a	bug	in	a	piece	of	your program	you	only	want	to	have	to	fix	the	bug	once.	You	don’t	want	to	have	
        // to search	through	the	program	looking	for	all	of	the	places	where	you	have	used	a particular	lump	of	code.	
        // If	you	have	to	do	this,	you	may	miss	one	place	and	end up	with	a	program	that	is	mostly	fixed,	but	will	
        // still	fail	sometimes.	A	class hierarchy	is	a	great	way	to	reuse	code	so	that	you	only	have	to	create	
        // a	behavior in	one	place	and	can	then	reuse	the	behavior	everywhere	it	makes	sense	to	do this. A	class	hierarchy	
        // is	used	when	you	have	an	application	that	must	manipulate items	that	are	part	of	a	particular	group.

        // What	you	really	want	to	do	is	pick	up	all	the	behaviors	in	the	BankAccount and	then	just	change	the	one	method	that	
        // needs	to	behave	differently.	This	can	be done	in	C#	using	inheritance.	
        class BabyAccount : BankAccount, IAccount
        {
            // BankAccount	is	called	the	base	or	parent	class	of	BabyAccount.


        }

        public void InheritanceFromBaseClass()
        {
            IAccount account = new BabyAccount();
            account.PayInFunds(50);
            // This	works	because,	although	BabyAccount	does	not	have	a	PayInFunds method,	the	base	class	does.	
            // This	means	that	the	PayInFunds	method	from	the BankAccount	class	is	used	at	this	point. 
            // Instances	of	the	BabyAccount	class	have	abilities	which	they	pick	up	from their	base	class.	
            // In	fact,	at	the	moment,	the	BabyAccount	class	has	no behaviors	of	its	own;	it	gets	everything	from	its	base	class. 

            // A	program	can	use	the	is	and	as	operators	when	working	with	class	hierarchies and	interfaces.	
            // The	is	operator	determines	if	the	type	of	a	given	object	is	in	a particular	class	hierarchy	or	implements	
            // a	specified	interface.	You	apply	the	is operator	between	a	reference	variable	and	a	type	or	
            // interface	and	the	operator returns	true	if	the	reference	can	be	made	to	refer	to	objects	of	that	type. 
            if (account is IAccount)
            {
                Console.WriteLine("acc is IAccount");
            }


        }


        // 2-36 Overriding
        // Overriding replaces    a method	in	a	base	class with    a version   that provides    the behavior    appropriate to  a child   class.	
        // In the	case	of the
        // BabyAccount,	you want    to change  the behavior    of the one method  that you are interested	in.	
        // You want    to replace the WithdrawFunds   method with    a new one.
        // The	keyword	override	means	“use this	version	of	the	method	in	preference	to	the	one	in	the	base	class.”
        public class BankAccountOverride : IAccount
        {
            protected decimal _balance = 0;
            public virtual bool WithdrawFunds(decimal amount)
            {
                if (_balance < amount)
                {
                    return false;
                }
                _balance = _balance - amount;
                return true;
            }

            void IAccount.PayInFunds(decimal amount)
            {
                _balance = _balance + amount;
            }

            decimal IAccount.GetBalance()
            {
                return _balance;
            }
        }

        class BabyAccountOverride : BankAccount, IAccount
        {
            public override bool WithdrowVirtual(decimal amount)
            {
                if (amount > 10)
                {
                    return false;
                }
                if (_balance < amount)
                {
                    return false;
                }
                _balance = _balance - amount;
                return true;
            }
        }
        // The	C#	compiler	needs	to	know	if	a	method	is	going	
        // to	be	overridden.	This is	because	it	must	call	an	overridden	method	in	a	slightly	different	way	from a	“normal”	one.	
        // 


        // 2-37 Using base method
        // The	word	base	in	this	context	means	“a	reference	to	the	thing	which	has been	overridden.”
        class BabyAccountBase : BankAccount
        {
            public override bool WithdrowVirtual(decimal amount)
            {
                if (amount > 10)
                {
                    return false;
                }
                else
                {
                    return base.WithdrowVirtual(amount);
                }
            }
        }
        // It’s	important	to	understand	what	we’re	doing	here,	and	why	we’re	doing	it: I	don’t	want	to	have	to	write	
        // the	same	code	twice I	don’t	want	to	make	the	_balance	value	visible	outside	the	BankAccount class. 
        // The	use	of	the	word	base	to	call	the	overridden	method	solves	both	of	these
        // problems rather  beautifully.Because the method call    returns a   bool result  you can just send    whatever it  delivers.
        // By making	this	change you can put the _balance    back to  private	in	the BankAccount because it	is	not accessed by the 
        // WithdrawFunds method.Note    that there   are other   useful spin-offs here.	If I   need to  fix a   bug in the behavior    of the 
        // WithDrawFunds method  I just fix it once, in the top-level class, and then it is fixed for all the classes which call back to it.

        // Replacing	methods	in	base	classes
        // C#	allows	a	program	to	replace	a	method	in	a	base	class	by	simply	creating	a new	method	in	the	child	class.	In	
        // this	situation	there	is	no	overriding,	you	have just	supplied	a	new	version	of	the	method.	In	fact,	the	C#	compiler	
        // will	give	you a	warning	that	indicates	how	you	should	provide	the	keyword	new	to	indicate this
        class BabyAccountBaseNew : BankAccount
        {
            public new bool WithdrowVirtual(decimal amount)
            {
                return true;
            }
        }
        // Note	that	a	replacement	method	is	not	able	to	use	base	to	call	the	method that	it	has	overridden,	because	
        // it	has	not	overridden	a	method,	it	has	replaced	it.

        // Stopping	overriding 
        // Overriding	is	very	powerful.	It	means	that	a	programmer	can	just	change	one tiny	part	of	a	
        // class	and	make	a	new	one	with	all	the	behaviors	of	the	parent.	This
        // goes well    with a   design process, so	as	you move    down the	“family tree”	of classes  you get more and more specific    
        // implementations.However,	overriding/replacing	is	not always  desirable.
        // you	need	a	way	to	mark	some methods	as	not	being	able	to	be	overridden.	C#	does	this	by	giving	us	a	sealed keyword	
        // which	means	“You	can’t	override	this	method	any	more”. You	can	only	seal	an	overriding	method	and	sealing	a	method	
        // does	not prevent	a	child	class	from	replacing	a	method	in	a	parent.	However,	you	can	also mark	a	class	as	sealed.	
        class BabyAccountBaseNewSealed : BankAccount
        {
            public override sealed bool WithdrowVirtual(decimal amount)
            {
                return true;
            }
        }


        // 2-38 Constructors and class hierarchies
        // A constructor is a method which gets control during the process of object creation.It is used to allow initial values to be set into an object.
        public class BankAccountConstructor : IAccount
        {
            private decimal _balance;

            public BankAccountConstructor(decimal balance)
            {
                // You can now set the initial balance of an account when one is created
                _balance = balance;
            }

            public decimal GetBalance()
            {
                throw new NotImplementedException();
            }

            public void PayInFunds(decimal amount)
            {
                throw new NotImplementedException();
            }

            public bool WithdrawFunds(decimal amount)
            {
                throw new NotImplementedException();
            }
        }
        // Unfortunately, adding a constructor like this to a base class in a class hierarchy has the effect of breaking all the child classes.The reason for this is
        // that creating a child class instance involves creating an instance of the base class. When the program tries to create a BabyAccount it must first create a
        // BankAccount.Creating a BankAccount involves the use of its constructor to set the initial balance of the BankAccount. The BabyAccount class must
        // contain a constructor that calls the constructor in the parent object to set that up
        public class BabyAccountConstructor : BankAccountConstructor
        {
            public BabyAccountConstructor(decimal balance) : base(balance)
            {
            }
        }

        // Abstract classes
        // You can provide a virtual “default” method in the BankAccount class and        then rely on the programmers overriding this with a more specific message, but
        // you then have no way of making sure that they really do perform the override.C# provides a way of flagging a method as abstract. This means that the method
        // body is not provided in this class, but will be provided in a child class
        public abstract class BankAccountAbstract
        {
            // abstract methods are valid only in abstract classes, otherwise - compile error
            public abstract string WarningLetterString();

            public int GetSquere(int x)
            {
                return x * x;
            }
        }
        // The fact that the BankAccount class contains an abstract method means that the class itself is abstract (and must be marked as such). It is not possible to
        // make an instance of an abstract class. If you think about it this is sensible.An instance of BankAccount would not know what to do if the
        // WarningLetterString method was ever called.An abstract class can be thought of as a kind of template.If you want to make
        // an instance of a class based on an abstract parent you must provideimplementations of all the abstract methods given in the parent.
        // You might decide that an abstract class looks a lot like an interface. This is true,in that an interface also provides a “shopping list” of methods which must be
        // provided by a class. However, abstract classes are different in that they cancontain fully implemented methods alongside the abstract ones.This can be
        // useful because it means you don’t have to repeatedly implement the samemethods in each of the components that implement a particular interface.
        // A class can only inherit from one parent, so it can only pick up the behaviorsof one class. Some languages support multiple inheritance, where a class can
        // inherit from multiple parents.C# does not allow this.


        // 2-39 IComparable
        // The	IComparable	interface	is	used	by	.NET	to	determine	the	ordering	of objects	when	they	are	sorted.	Below	is	the	definition	
        // of	the	method	from	the	C# .NET library.You can see that the interface contains    a single  method, CompareTo,	which compares	this	object 
        // with    another.The CompareTo method returns an integer.If  the value   returned    is	less than	0	it indicates   that    this object should  
        // be placed  before the one it	is	being compared    with.If the value returned	is	zero, it indicates   that    this object should  be placed  at 
        // the same position as	the one it  is	being compared    with and	if	the value   returned    is	greater than	0	it means    that    this object 
        // should  be placed  after the one it	is	being compared    with.
        // You	can	allow	your	bank	accounts	to	be	sorted	in	order	of	balance	by	making the	BankAccount	class	implement	the	IComparable	
        // interface	and	adding	a CompareTo	method	to	the	BankAccount	class. 
        public class BankAccountComparable : IComparable, IAccount
        {
            private int _balance;

            public BankAccountComparable(int balance)
            {
                _balance = balance;
            }

            public int CompareTo(object obj)
            {
                // if we are comparaed with lower object:
                if (obj == null)
                    return 1;
                //	Convert	the	object	reference	into	an	account	reference
                BankAccountComparable bank = obj as BankAccountComparable;
                //	as	generates	null	if	the	conversion	fails
                if (bank == null)
                    throw new Exception("Not an account");
                //	use	the	balance	value	as	the	basis	of	the	comparison
                throw new NotImplementedException();
            }

            public decimal GetBalance()
            {
                throw new NotImplementedException();
            }

            public void PayInFunds(decimal amount)
            {
                throw new NotImplementedException();
            }

            public bool WithdrawFunds(decimal amount)
            {
                throw new NotImplementedException();
            }
        }

        // Once	the	BankAccount	has	been	made	to	implement	the	IComparable interface,	you	can	use	the	Sort	behaviors	provided	by	
        // collection	types.
        public void Comparables()
        {
            //	Create	20	accounts	with	random	balances 
            List<IAccount>	accounts	=	new	List<IAccount>();
            Random	rand	=	new	Random(1);
            for (int	i=0;	i<20;	i++)
            {
                IAccount	account	=	new BankAccountComparable(rand.Next(0,	10000));
                accounts.Add(account);
            }
            //	Sort	the	accounts 
            accounts.Sort();
        }

        // 2-40 Typed	IComparable
        // The	IComparable	interface	uses	a	CompareTo	method	that	accepts	an object	reference	as	a	parameter.	This	reference	should	
        // refer	to	an	object	of	the same	type	as	the	object	that	is	doing	the	comparing,	i.e.	the	CompareTo method	in	type	x	
        // should	be	supplied	with	a	reference	to	type	x	as	a	parameter. 
        // There	is	another	version	of	the	IComparable	interface	that	accepts	a	type. This	can	be	used	to	create	a	CompareTo	
        // that	only	accepts	parameters	of	a specified	type.	
        public class BankAccountComparableTyped : IComparable<IAccount>, IAccount
        {
            public int CompareTo(IAccount other)
            {
                throw new NotImplementedException();
            }

            public decimal GetBalance()
            {
                throw new NotImplementedException();
            }

            public void PayInFunds(decimal amount)
            {
                throw new NotImplementedException();
            }

            public bool WithdrawFunds(decimal amount)
            {
                throw new NotImplementedException();
            }
        }

        // 2-41 IEnumerable
        // Programs	spend	a	lot	of	time	consuming	lists	and	other	collections	of	items.	This is	called	iterating	or	enumerating. You	
        // might	think	of	iteration	as	something	that	is	performed	on	lists	and	arrays of	values,	with	a	program	working	through	
        // each	element	in	turn.	However, iteration	is	much	more	than	this.	Any	C#	object	can	implement	the IEnumerable	interface	that	
        // allows	other	programs	to	get	an	enumerator	from that	object.	The	enumerator	object	can	then	be	used	to	enumerate	
        // (or	iterate)	on the	object. 
        public void GetAnEnumerator()
        {
            //	Get	an	enumerator	that	can	iterate	through	a	string
            var stringEnumerator = "Hello wrod".GetEnumerator();
            while (stringEnumerator.MoveNext())
            {
                Console.WriteLine(stringEnumerator.Current);
            }
        }
        // 	prints	out	the	“Hello	world”	string	one	character at	a	time.


        // 2-42 IEnumerator using foreach
        // You	can	consume	all	the iterators	in	this	way,	but	C#	makes	life	easier	by	providing	the	foreach construction,	
        // which	automatically	gets	the	enumerator	from	the	object	and	the works	through	it.	
        public void UsingForeeach()
        {
            foreach (char ch in "Hello	world")
                Console.Write(ch);
        }


        // 2-43 Making	an	object	enumerable 
        // The	IEnumerable	interface	allows	you	to	create	objects	that	can	be enumerated	within	your	programs,	for	example	by	the	foreach	
        // loop construction.	Collection	classes,	and	results	returned	by	LINQ	queries  implement this    interface.
        class EnumeratorThing : IEnumerator<int>, IEnumerable
        {
            int count;
            int limit;

            public EnumeratorThing(int limit)
            {
                this.count = 0;
                this.limit = limit;
            }

            public int Current
            {
                get
                {
                    return count;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return count;
                }
            }

            public void Dispose()
            {
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                if (++count == limit)
                    return false;
                else
                    return true;
            }

            public void Reset()
            {
                count = 0;
            }
        }

        public void UsingEnumerable()
        {
            // You	can	use	an	EnumeratorThing	instance	in	a	foreach	loop: 
            EnumeratorThing e = new EnumeratorThing(10);
            foreach (int i in e)
                Console.WriteLine(i);
        }

        // 2-44 Using	yield 
        // 	To	make	it	easier	to	create	iterators	C#	includes	the	yield keyword. 
        // The	keyword	yield	is followed	by	the	return	keyword	and	precedes	the	value	to	be	returned	for	the current	iteration.	
        // The	C#	compiler	generates	all	the	Current	and	MoveNext behaviors	that	make	the	iteration	work,	and	also	records	the	state	
        // of	the	iterator method	so	that	the	iterator	method	resumes	at	the	statement	following	the yield	statement	when	the	next	
        // iteration	is	requested.	
        // The	yield	keyword	does	two	things.	It	specifies	the	value	to	be	returned	for a	given	iteration,	and	it	also	returns
        // control	to	the	iterating	method.
        public class EnumeratorThingWithYield : IEnumerator<int>, IEnumerable
        {
            private int _limit;

            public EnumeratorThingWithYield(int limit)
            {
                _limit = limit;
            }

            public int Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < 10; i++)
                {
                    yield return i;
                }
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        // You can express iterator that returns values as follows:
        public IEnumerator<int> GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }



        // 2-45 Using	IDisposable 
        // C#	provides	memory	management	for	applications,	but	it	can’t	control	how programs	use	other	resources	such	as	file	handles,	
        // database	connections	and	lock objects.	While	an	object	can	get	control	when	it	is	removed	by	the	garbage collector	
        // it	is hard	for	a	developer	to	know	precisely	when	this	happens.	It	may	not	even happen	until	the	program	ends. 
        // The	IDisposable	interface	provides	a	way	that	an	object	can	indicate	that it	contains	an	explicit	Dispose	method	that	
        // can	be	used	to	tidy	up	an	object when an  application has finished    using	it.	A	disposed object may exist	in memory,	but 
        // any attempts to  use it  will result  in	the ObjectDisposedException being thrown.
        // Note	that	the	action	of	the	Dispose	method	depends	entirely	on	the	needs	of the	application.	Note	also	that	the	Dispose	
        // method	is	not	called	automatically when	an	object	is	deleted	from	memory.	There	are	two	ways	to	make	sure	that Dispose	
        // is	called	correctly;	you	can	call	the	method	yourself	in	your application,	or	you	can	make	use	of	the	C#	using	construction. 
        // The	C#	using	construction	is	a	good	way	to	ensure	that	Dispose	is	called correctly	because	it	incorporates	exception	
        // handling	so	that	if	an	exception	is thrown	by	the	code	using	the	object	the	Dispose	method	is	automatically called	on	the
        // object	being	used.	If	you	have	a	number	of	objects	that	need	to	be disposed	you	can	nest	using	blocks	inside	each	other. 
        class CrucialConnection : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose Called!");
            }
        }

        public void UsingDisposable()
        {
            using (CrucialConnection c = new CrucialConnection())
            {
                // Do something with this class
            }
        }

        // 	In	the	COM	world	the	IUnknown	interface	is	the	means	by	which	one object	describes	the	interfaces	that	it	makes	available	
        // for	use	by	others.	The IUnknown	interface	provides	a	means	by	which	.NET	applications	can interoperate	with	
        // COM	objects	at	this	level.	You	use	it	when	connecting	C# applications	to	COM	objects.	
        // https://docs.microsoft.com/en-us/dotnet/framework/interop/.
    }
}
