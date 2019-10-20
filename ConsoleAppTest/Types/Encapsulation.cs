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
            public string Name;
        }

        // A	property	in	an	object	provides	a	way	that	a	programmer	can	encapsulate	data. 
        // Let’s	start	by	considering	how	public	data	is	accessed	in	a	class.
        public void PublicDataMembers()
        {
            Customer c = new Customer();
            c.Name = "Rob";
            Console.WriteLine("Customer	name:	{0}", c.Name);
        }

        // 
        // 
        // 
        public void UsingAProperty()
        {

        }

        // 
        // 
        // 
        public void CreateAccessorMethods()
        {

        }

        // 
        // 
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
