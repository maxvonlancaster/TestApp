using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Types
{
    // One definition of the word encapsulate is to “enclose in a capsule.”

    // You	can	think	of	encapsulation	as	a	technique	that	provides	active	program safety.	Use	encapsulation	to	reduce	
    // the	possibility	of	program	errors	occurring. Encapsulation	lets	you	hide	the	elements	that	actually	implement	
    // the	behaviors of	an	object,	so	that	the	object	only	exposes	the	behaviors	that	it	provides	by	a well-defined	interface. 
    // Encapsulation	provides	protection	against	accidental	damage,	where	a programmer	directly	changes	an	internal	
    // element	of	an	object	without	having	a proper	understanding	of	the	effect	of	the	change.	
    // Encapsulation	also	provides protection	against	malicious	attacks	on	an	application,	where	code	is	
    // written with	the	intent	to	corrupt	or	damage	the	contents	of	an	object.	

    // C#	allows	objects	to	encapsulate	data	and	methods	by	providing	programmers with	the	ability	to	mark	
    // members	of	a	type	with	access	modifiers	that	control access	to	them.

    // There	are	a	number	of	different	access	modifiers,	and	you	can	start	by considering	public	and	private.	
    // A	member	of	a	type	given	the	public	access modifier	can	be	accessed	by	code	that	is	outside	that	type,	
    // whereas	a	private member	of	a	type	can	only	be	accessed	by	code	running	inside	the	type.
    public class Encapsulation
    {
        class Customer
        {
            private string _nameValue;
            // This	value	is	called
            // the backing value of  the property.If  you just    want to  implement a   class member as	a property,
            // but don’t want    to get control when    the property	is	accessed,	you can use auto-implemented properties.
            // The statement here    creates an  integer property    called Age.	The C#	compiler	automatically	creates	the	backing	values.
            // If	you	want	to	add	get	and	set	behaviors	and	your	own	backing	value	later,	you can	do	this. 

            public int Age { get; set; }

            public string Name;

            public string NameValue
            {
                get => _nameValue;
                set
                {
                    if (value == string.Empty)
                        throw new Exception("Invalid value");
                    _nameValue = value;
                }
            }
        }

        // A	property	in	an	object	provides	a	way	that	a	programmer	can	encapsulate	data. 
        // Let’s	start	by	considering	how	public	data	is	accessed	in	a	class.
        public void PublicDataMembers()
        {
            Customer c = new Customer();
            c.Name = "Rob";
            Console.WriteLine("Customer	name:	{0}", c.Name);
            // This	program	works	well,	but	it	doesn’t	provide	any	control	over	the	contents of	the	customer	name.	
            // The	name	of	a	customer	can	be	set	to	any	string, including	an	empty	string.	
            // You	should	stop	users	of	the	Customer	object	from setting	a	customer	name	to	an	empty	string.	
            // We	call	this	“enforcing	business rules”	on	our	applications.	You	may	have	other	rules	to	enforce,	
            // which	restrict the	characters	that	can	be	used	in	a	name	and	set	limits	for	the	minimum	and maximum	length	
            // of	a	customer	name.	But	for	now,	
            // we will just focus on how to manage access to the name of a customer and invalid customer names from being created. 
        }

        // Shown below is how	to	create	a	NameValue	property	in	the Customer	class	that	performs	validation	of	the	name.	
        // A	property	is	declared	as having	a	get	behavior	and	a	set	behavior.	
        // The	set	behavior	is	used	when	a program	sets	a	value	in	the	property	and	the	get	behavior	
        // is	used	when	a program	gets	a	value	from	the	property.	The	get	behavior	for	the	Name property	
        // returns	the	value	of	a	private	class	member	variable	called _nameValue,	which	holds	the	value	of	the	name	of	the	customer.
        // Within	the set	behavior	for	the	Name	property	keyword	value	represents	the	value	being assigned	to	the	property.	
        // If	this	value	is	an	empty	string	the	set	behavior	throws an	exception	to	prevent	an	empty	string	begin	
        // set	as	a	Name.	If	the	value	is valid,	the	set	behavior	sets	_nameValue	to	the	incoming	name.	
        // Note	that there is a C#	convention	that	private	members	of	a	class	have identifiers that start with an	underscore (_) character.
        public void UsingAProperty()
        {
            Customer c = new Customer();
            c.NameValue = "Rob";
            Console.WriteLine("Customer	name:	{0}", c.Name);
            //	the	following	statement	will	throw	an	exception 
            c.NameValue	= "";

            // Properties	provide	a	powerful	way	to	enforce	encapsulation,	which	is	very natural	in	use.	
            // The	user	of	a	property	might	not	even	be	aware	that	code	is running	when	they	perform	what	
            // seems	like	a	simple	assignment.	You	can provide	“read	only”	properties	by	creating	properties	that	only	
            // contain	a	get behavior.	These	are	useful	if	you	want	to	expose	multiple	views	of	the	data	in	an object,	
            // for	example	a	Thermometer	class	can	provide	different	properties	that give	the	temperature	value	in	Fahrenheit	and	Centigrade.
            // You	can	also	create “write	only	properties”	by	only	providing	the	set	behavior,	although	this	
            // ability is	less	frequently	used.	It	is	also	possible	to	set	different	access	modifiers	for	the get	and	set	behaviors,	
            // so	that	a	get	behavior	can	be	public	for	anyone	to	read,	
            // but the	set	behavior	is	private	so	that	only	code	running	inside	the	class	can	assign values	to	the	property.
        }

        class BankAccount
        {
            private decimal _accountBalance = 0; // Can not be accessed in the code outside the BankAccount class

            public void PayInFunds(decimal amountToPayIn) // Code outside the BankAccount class can access these methods
            {
                _accountBalance = _accountBalance + amountToPayIn;
            }

            public bool WithdrawFunds(decimal amountToWithdraw)
            {
                if (amountToWithdraw > _accountBalance)
                    return false;
                _accountBalance = _accountBalance - amountToWithdraw;
                return true;
            }

            public decimal GetBalance()
            {
                return _accountBalance;
            }

            // , from a design perspective, making a class member private and only providing public methods that allow access to that
            // member is a good first step to creating secure code, but you also may also have
            // to make sure that you provide a secure workflow that manages access to the data.
        }

        // As a general rule, data held within a type should be made private and methods
        // (which allow managed access to data inside the type) should be made public.
        // Properties provide a way to manage access to individual values in a class, so you
        // can consider how to use accessor methods to provide access to elements in a class.
        public void CreateAccessorMethods()
        {
            BankAccount a = new BankAccount();
            a.PayInFunds(50);
            a.WithdrawFunds(10);
            Console.WriteLine(a.GetBalance());
        }

        // If you don’t specify an access modifier for a member of a type, the access to that member will default to private. In other words, if you want to make a
        // member visible outside the type, it must be done explicitly by adding public.This means that you don’t actually have to add the access modifier private to
        // your private members, but I strongly advise you to do this.

        // Making a member of a class private will prevent code in any external class from having access to that data member.The protected access modifier
        // makes a class member useable in any classes that extend the parent(base) class in which the member is declared.
        // 
        public void ProtectedAccess()
        {
            
        }

        // 
        // 
        //
        public void ProtectedClass()
        {

        }

        // 
        // 
        // 
        public void PrintingInterface()
        {

        }
    }
}
