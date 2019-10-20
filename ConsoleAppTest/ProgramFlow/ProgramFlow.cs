using ConsoleAppTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.ProgramFlow
{
    public class ProgramFlow
    {
        private static int _counter;

        static void Initalize()
        {
            Console.WriteLine("Initialize	called");
            _counter = 0;
        }

        static void Update()
        {
            Console.WriteLine("Update	called");
            _counter++;
        }

        static bool Test()
        {
            Console.WriteLine("Test	called");
            return _counter < 5;
        }

        // While - will perform a given stetement while true. The condition is tested bfore statements are obeyed ->
        // -> while(false) will produce compiler warning (unreachable) 
        // Do while -> the condition is tested after the code has been performed once. Will always work atleast once
        // useful to fetch data untill the valid one is fetched
        public void Loops()
        {
            while (false)
            {
                Console.WriteLine("The end of the world has come");
            }

            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine("While loop: {0}", counter);
                counter -= -1; // No rules No masters
            }

            do
            {
                Console.WriteLine("Hello there!");
            } while (false);
        }

        // For Loop - not infinite, 3 parts - initialization, test (if should continue) and update to be performed each time action performed
        // May be performed 0 times
        // 
        // 
        public void ForLoop()
        {
            for (Initalize(); Test(); Update())
            {
                Console.WriteLine("Hello for loop! {0} ", _counter);
                // Init test hello 0 update test hello 1 update ...
                // Do not do this actually
            }

            // i -> local variable to the code to be repeated, created within the loop.
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello {0}", i);
            }

            // Iterate with for through a collection of items
            string[] names = { "Alan", "Bob", "Calvin", "Dylan", "Elliot", "Frank" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        // The	foreach	construction	makes	iterating	through	a	collection	much	easier. 
        // Each	time	around	the loop,	the	value	of	name	is	loaded	with	the	next	name	in	the	collection.
        // 
        public void IterateWithForeach()
        {
            string[] names = { "Alan", "Bob", "Calvin", "Dylan", "Elliot", "Frank" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            // Note	how	the	type	of	the	iterating	value	must	match	the	type	of	the	items	in the	collection.

            // It	isn’t	possible	for	code	in	a	foreach	construction	to	modify	the	iterating value.	
            // The	following	code,	which	attempts	to	convert	the	list	of	names	to	upper case,	does	not	compile.
            foreach (string name in names)
            {
                //name = name.ToUpper();
            }

            // If	the	foreach	loop	is	working	on	a	list	of	references	to	objects,	
            // the	objects on	the	ends	of	those	references	can	be	changed.	
            // The	code below	works through a   list of  Person objects, changing    the Name    property of  each person	in the list    
            // to upper	case.	This compiles    and runs    correctly.
            User[] users = new User[]
            {
                new User(){ Name = "alan" },
                new User(){ Name = "bob" }
            };

            foreach (var user in users)
            {
                user.Name = user.Name.ToUpper();
            }

            // The	foreach	construction can iterate through any object	which implements the IEnumerable interface.	
            // These	objects	expose	a	method	called GetIterator().	This	method	must	return	an	object	that	
            // implements	the System.Collections.IEnumerator	interface.	This	interface	exposes methods	that	the	foreach	construction	
            // can	use	to	get	the	next	item	from	the enumerator	and	determine	if	there	any	more	items	in	the	collection.	
            // Many collection	classes,	including	lists	and	dictionaries,	implement	the IEnumerable	interface.	
            // Note	that	the	iteration	can	be	implemented	in	a	“lazy”	way;	the	next	item	to	be iterated	only	needs	to	be	
            // fetched	when	requested.	The	results	of	database	queries can	be	returned	as	objects	that	implement	the	IEnumerable	
            // interface	and	then only	fetch	the	actual	data	items	when	needed.	It	is	important	that	the	item	being iterated	
            // is	not	changed	during	iteration,	if	the	iterating	code	tried	to	remove items	from	the	list	it	was	iterating	
            // through	this	would	cause	the	program	to	throw an	exception	when	it	ran. 
        }

        // Any	of	the	above	loop	constructions	can	be	ended	early	by	the	use	of	a	break statement.	
        // When	the	break	statement	is	reached,	the	program	immediately exits	the	loop
        // A	loop	can	many	break	statements,	but	from	a	design	point	of	view	this	is	to be	discouraged	because	it	
        // can	make	it	much	harder	to	discern	the	flow	through the	program. 
        public void UsingBreak()
        {
            string[] names = { "Alan", "Bob", "Calvin", "Dylan", "Elliot", "Frank" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
                if (names[i] == "Calvin")
                    break;
            }
        }

        // The	continue	statement	does	not	cause	a	loop	to	end.	Instead,	it	ends	the current	pass	
        // through	the	code	controlled	by	the	loop.	
        // The	terminating	condition is	then	tested	to	determine	if	the	loop	should	continue.	
        public void UsingContinue()
        {
            string[] names = { "Alan", "Bob", "Calvin", "Dylan", "Elliot", "Frank" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
                if (names[i] == "Calvin")
                    continue;
            }
        }

        // As program runs, it can make decisions. Two program constructions that can be used to conditionally execute code: the if construction and the switch construction. 
        // An	if	construction	allows	the	use	of	a	logical	expression	to	control	the execution	of	a	statement	or	block	of	code.	
        // A	logical	expression	is	one	that evaluates	to	the	Boolean	value	true	or	the	Boolean	value	false.	
        // When	the logical	expression	is	true	the	statement	is	obeyed.	
        // An	if	construction	can	have an	else	element	that	contains	code	that	is	to	be	executed	when	the	Boolean
        // expression evaluates   to	false.
        public void IfConstruction()
        {
            if (true)
            {
                Console.WriteLine("It is always printed");
            }
            else
            {
                Console.WriteLine("It is never printed");
            }

            // The	else	element	of	an	if	construction is	optional.	It is possible to “nest” if constructions inside one another.
            if (true)
            {
                if (true)
                {
                    Console.WriteLine("It is always printed");
                }
                else
                {
                    Console.WriteLine("It is never printed");
                }
            }

            // Not all if  constructions are required to have else elements.There is never any confusion about which if condition 
            // a given else binds to, since it is always the “nearest”	one.
            // A	logical	expression	evaluates	to	a	logical	value,	which	is	either	true	or	false.
            // We’ve	seen	that	true	and	false	are	Boolean	literal	values	and	can	be	used	in conditions,	although	
            // this	is	not	terribly	useful.	A	logical	expression	can	contain operators	used	to	compare	values.	
            // Relational	operators	are	used	to	compare	two values
            // < > <= >=
            // Relational	operators	can	be	used	between	numeric	variables	and	strings.	In	the context	of	a	string,	less	
            // than	and	greater	than	are	evaluated	alphabetically,	as	in “Abbie”	is	less	than	“Allen.”
            // A	program	can	use	equality	operators	to	compare for	equality  == !=
            // These	can	be	used	between	numeric	variables	and	strings,	but	they	should	not be	used	when	testing	floating	point	(float	and	double)	values	as	the	nature of	number	storage	on	a	computer	means	that	values	of	these	types	are	not	held exactly.	A	program	should	not	test	to	see	if	two	floating	point	values	are	equal, instead	it	should	subtract	one	from	the	other	and	determine	if	the	absolute	value of	the	result	is	less	than	a	given	tolerance	value. 
            // Logical	values	can	be	combined	using	logical	operators 
            // & (and), | (or), ^ (exclusive or)
        }

        private int mOne()
        {
            Console.WriteLine("mOne() called");
            return 1;
        }

        private int mTwo()
        {
            Console.WriteLine("mTwo() called");
            return 2;
        }

        // The	&	and	|	operators	have	conditional	versions:	&&	and	||.	
        // These	are	only evaluated	until	it	can	be	determined	whether	the	result	of	the	expression	is	true or	false.	
        // In	the	case	of	&&,	if	the	first	operand	is	false,	the	program	will	not evaluate	the	second	operand	since	
        // it	is	already	established	that	the	result	of	the expression	is	false.	In	the	case	of	||,	if	the	first	operand	is
        // true	the	second operand	will	not	be	evaluated	as	it	is	already	established	that	the	result	of	the expression	is	true.
        // This	is	also	referred	to	as	short	circuiting	the	evaluation	of the	expression.
        public void LogicalExpressions()
        {
            if (mOne() == 2 && mTwo() == 1)
            {
                Console.WriteLine("It will not be printed");
            }
            // When	the	program	runs,	it	only	outputs	a	message	from	the	method	mOne. 
            // The	method	mTwo	is	never	called,	even	though	it	is	in	the	expression.	
        }

        // The	switch	construction	let’s	a	program	use	a	value	to	select	one	of	a	number of	different	options.	
        // It	replaces	a	long	sequence	of	if–then–else	constructions that	would	otherwise	be	required.	
        // The	switch	keyword	is	followed	by	an expression	that	controls	the	switch.
        // At	run	time	the	program	will	look	for	a matching	value	on	a	particular	case	clause,	
        // which	identifies	the	code	to	be executed	for	that	value.	The	code	controlled	by	the	case	continues	
        // until	a break	statement,	which	marks	the	end	of	that	clause.	A	switch	can	contain	a default	clause,	
        // identifying	a	clause	to	be	performed	if	the	control	value doesn’t	match	any	case. 
        public void SwitchConstruction()
        {
            Console.WriteLine("Enter a command, commrade: ");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Console.WriteLine("Command 1 chosen, commrade!");
                    break;
                case 2:
                    Console.WriteLine("Command 2 chosen, commrade!");
                    break;
                case 3:
                    Console.WriteLine("Command 3 chosen, commrade!");
                    break;
                default:
                    Console.WriteLine("Please enter a valid command, commrade!");
                    break;
            }
        }

        // The	switch	construction	will	switch	on	character,	string	and	enumerated values,	and	it	is	possible	
        // to	group	cases,	as	shown	below,	which	allows a	user	to	select	a	command	by	entering	a	string.	
        // Note	that	the	string	that	is entered	is	converted	into	lower	case,	and	that	both	a	long	form	
        // (save)	and	a	short form	of	the	command	(s)	can	be	used.
        public void SwitchOnStrings()
        {
            Console.Write("Enter	command:	");
            string commandName = Console.ReadLine().ToLower();

            switch (commandName)
            {
                case "save":
                case "s":
                    Console.WriteLine("Save	command");
                    break;
                case "load":
                case "l":
                    Console.WriteLine("Load	command");
                    break;
                case "exit":
                case "e":
                    Console.WriteLine("Exit	command");
                    break;
                default:
                    Console.WriteLine("Please	enter	save,	load	or	exit");
                    break;
            }
            // In	C#	it	is	not	permissible	for	a	program	to	“fall	through”	from	the	end	of	one case	clause	into	another.	
            // Each	clause	must	be	explicitly	ended	with	a	break,	a return,	or	by	the	program	throwing	an	exception. 
            // Switches	are	a	nice	example	of	a	“luxury”	C#	feature	in	that	they	don’t actually	make	something	
            // possible	that	you	can’t	do	any	other	way.	You	can create	C#	programs	without	using	any	switch	statements,	
            // but	they	make	it	easier to	create	code	that	selects	one	behavior	based	on	the	value	in	a	control	variable. 
        }

        // C#	expressions	are	comprised	of	operators	and	operands.	Operators	specify	the action	to	be	performed,	
        // and	are	either	literal	values	(for	example	the	number	99) or	variables.	You	have	seen	examples	of	operators	
        // and	operands	in	use	in	the logical	expressions	that	control	the	if	constructions	in	previous	sections.	
        // An operator	can	work	on	one	operand,	and	such	operands	are	called	unary	or monadic. 
        // Monadic	operators	are	either	prefix	(given	before	the	operand)	or	postfix (given	after	the	operand).	
        // Alternatively,	an	operand	can	work	on	two	(binary),	or in	the	case	of	the	conditional	operator	?:	
        // three	(ternary)	operands. The	context	of	the	use	of	an	operator	determines	the	actual	behavior	that	the operator	
        // will	exhibit.	For	example,	the	addition	operator	can	be	used	to	add	two
        // numeric operands    together,	or concatenate two strings together.The use of an incorrect context(for	example adding  a number 
        // to a   string) will be  detected by the compiler    and cause   a compilation error.
        // Each operator    has	a priority    or precedence  that determines  when it	is performed during  expression evaluation.	
        // This precedence  can be  overridden by the use of parenthesis;	
        // elements enclosed    in parenthesis are evaluated first. Operators also    have an  associability, which gives   the order   
        // (left to  right   or right to left)   in	which they    are evaluated	if	a number  of them    appear together.
        public void ExpressionEvaluation()
        {
            int i = 0;  //	create	i	and	set	to	0
                        //	Monadic	operators	-	one	operand 
            i++;    //	monadic	++	operator	increment	-	i	now	1 
            i--;    //	monadic	--	operator	decrement	-	i	now	0
                    //	Postfix	monadic	operator	-	perform	after	value	given 
            Console.WriteLine(i++); //	writes	0	and	sets	i	to	1 
                                    //	Prefix	monadic	operator	-	perform	before	value	given 
            Console.WriteLine(++i); //	writes	2	and	sets	i	to	2
                                    //	Binary	operators	-	two	operands 
            i	=	1	+	1;  //	sets	i	to	2 
            i	=	1	+	2	*	3;  //	sets	i	to	7	because	*	performed	first 
            i	=	(1	+	2)	*	3;	//	sets	i	to	9	because	+	performed	first
            string str = "";
            str = str + "Hello";    //	+	performs	string	addition
                                    //	ternary	operators	-	three	operands 
            i	=	true	?	0	:	1;	//	sets	i	to	0	because	condition	is	true; 

            // Full	details	https://docs.microsoft.com/en-us/dotnet/csharp/programmingguide/statements-expressions-operators/operators.
        }
    }
}
