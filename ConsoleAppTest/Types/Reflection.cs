using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static ConsoleAppTest.Types.ClassHierarchy;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq.Expressions;

namespace ConsoleAppTest.Types
{
    public class Reflection
    {
        // All objects expose GetType method, that returns a reference to the type that defines the object
        // Type contains all the fields of an object along with metadata describing it
        // methods and objects in System.Reflection namespace to work with Type obj-s
        // 
        public void InvestigateType()
        {
            Type type;
            Person person = new Person();
            type = person.GetType();
            Console.WriteLine("Person type: {0}", type.ToString());

            foreach (MemberInfo member in type.GetMembers())
            {
                // Printing all the members of Person type
                Console.WriteLine(member.ToString());
            }
        }

        // call method -> finding MethodInfo and calling the invoke on that reference
        // Invoke method is supplied with reference to Person and array of object references that will be used as parameters
        // will be slower
        // 
        public void ReflectionMethodCall()
        {
            Type type;
            Person person = new Person();
            type = person.GetType();

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(person, new object[] { "F" });
            Console.WriteLine(person.Name); // will print out "F"
        }

        // to        implement plugins you need to be able to search the classes in an assembly and
        // find components that implement particular interfaces.This behavior is the basis of the Managed Extensibility Framework(MEF). 
        // Find more at :  https://docs.microsoft.com/en-us/dotnet/framework/mef/
        // Find all classes that implement IAccount
        public void FindComponents()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            List<Type> AccountTypes = new List<Type>();
            foreach (Type t in thisAssembly.GetTypes())
            {
                if (t.IsInterface)
                    continue;
                if (typeof(IAccount).IsAssignableFrom(t))
                {
                    AccountTypes.Add(t);
                }
            } // BabyAccount and BankAccount will be added
        }

        // You can simplify the identification of the types by using a LINQ query
        public void LinqComponents()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            var AccountTypes = from type in thisAssembly.GetTypes()
                               where typeof(IAccount).IsAssignableFrom(type) && !type.IsInterface
                               select type;
            // It is possible to load an assembly from a file by using the Assembly.Load method.The statement below would load all the types in a file called
            // BankTypes.dll.This means that at its start an application could search aparticular folder for assembly files, load them and then search for classes that
            // can be used in the application.
            Assembly bankTypes = Assembly.Load("BankTypes.dll");
        }

        // Now	that	you	know	that	an	entire	application	can	be	represented	by	objects	such as	Assembly	and	Type,	the	next	thing	to	
        // discover	is	how	to	programmatically add	your	own	elements	to	these	objects	so	that	your	applications	can	create	code at	
        // runtime.	You	can	use	this	technology	to	automate	the	production	of	code.	It	is used	in	situations	where	you	have	to	create	
        // objects	that	will	have	to	interact	with services	providing	a	particular	data	schema	or	when	you’re	automatically
        // generating	code	in	a	design	tool.
        // A	document	object	model	is	a	way	of	representing	the	structure	of	a	particular type	of	document.	The	object	contains	
        // collections	of	other	objects	that	represent the	contents	of	the	document.	There	are	document	object	models	for	XML, JSON	
        // and	HTML	documents,	and	there	is	also	one	that	is	used	to	represent	the structure	of	a	class.	This	is	called	a	
        // CodeDOM	object. A	CodeDOM	object	can	be	parsed	to	create	a	source	file	or	an	executable assembly.	The	constructions	that	
        // are	used	in	a	CodeDOM	object	represent	the logical	structure	of	the	code	to	be	implemented	and	are	independent	of	the
        // syntax of  the high-level language    that	is	used to  create the document.In other words,	you can create either  Visual Basic.NET   
        // or C#	source	files	from	a	given CodeDOM	object	and	you	can	create	CodeDOM	objects	using	either	language. 
        public void CodeDomObject()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            //	Create	a	namespace	to	hold	the	types	we	are	going	to	create 
            CodeNamespace personnelNameSpace = new CodeNamespace("Personnel");
            //	Import	the	system	namespace 
            personnelNameSpace.Imports.Add(new CodeNamespaceImport("System")); //	Create	a	Person	class 
            CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
            personClass.IsClass = true;
            personClass.TypeAttributes = System.Reflection.TypeAttributes.Public;
            //	Add	the	Person	class	to	personnelNamespace 
            personnelNameSpace.Types.Add(personClass);
            //	Create	a	field	to	hold	the	name	of	a	person 
            CodeMemberField nameField = new CodeMemberField("String", "name");
            nameField.Attributes = MemberAttributes.Private;
            //	Add	the	name	field	to	the	Person	class 
            personClass.Members.Add(nameField);
            //	Add	the	namespace	to	the	document 
            compileUnit.Namespaces.Add(personnelNameSpace);

            // Once	the	CodeDOM	object	has	been	created	you	can	create	a CodeDomProvider	to	parse	the	code	document	
            // and	produce	the	program	code from	it.	

            //	Now	we	need	to	send	our	document	somewhere 
            //	Create	a	provider	to	parse	the	document 
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            //	Give	the	provider	somewhere	to	send	the	parsed	output 
            StringWriter s = new StringWriter();
            //	Set	some	options	for	the	parse	-	we	can	use	the	defaults 
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            //	Generate	the	C#	source	from	the	CodeDOM 
            provider.GenerateCodeFromCompileUnit(compileUnit, s, options);
            //	Close	the	output	stream 
            s.Close();
            //	Print	the	C#	output 
            Console.WriteLine(s.ToString());

            // There	are	a	range	of	types	that	can	be	created	and	added	to	a	document	to allow	you	to	programmatically	
            // create	enumerated	types	expressions,	method calls,	properties	and	all	the	elements	of	a	complete	program.	
            // Note	that	you would	normally	create	such	a	document	model	on	the	basis	of	some	data structure	that	
            // you	were	parsing. 
        }

        // A	lambda	expression	is	a	way	of expressing	a	data	processing	action	(a	value	goes	in	and	a	result	comes	out).	
        // You can	express	a	single	action	in	a	program	by	the	use	of	a	single	lambda expression.	More	complex	actions	can	be	expressed	
        //in	expression	trees.	If	you think	about	it,	the	structure	of	a	CodeDOM	object	is	very	like	a	tree,	in	that	the root	
        // object	contains	elements	that	branch	out	from	it.	The	elements	in	the	root object	can	also	contain	other	elements,	leading	to	
        // a	tree	like	structure	that describes	the	elements	in	the	program	that	is	being	created.	Expression	trees	are widely	used	
        // in	C#,	particularly	in	the	context	of	LINQ.	The	code	that	generates the	result	of	a	LINQ	query	will	be	created	as	an	expression	tree. 
        public void LambdaExpressionTree()
        {
            //	build	the	expression	tree:													
            Expression<Func<int, int>> squareExp = num => num * num;
            //	The	parameter	for	the	expression	is	an	integer												
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            //	The	opertion	to	be	performed	is	to	square	the	parameter												
            BinaryExpression squareOperation = Expression.Multiply(numParam, numParam);
            //	This	creates	an	expression	tree	that	describes	the	square	operation												
            Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(squareOperation, new ParameterExpression[] { numParam });
            //	Compile	the	tree	to	make	an	executable	method	and	assign	it	to	a	dele												
            Func<int, int> doSquare = square.Compile();
            //	Call	the	delegate												
            Console.WriteLine("Square	of	2:	{0}", doSquare(2));

            // The	System.Linq.Expressions	namespace	contains	a	range	of	other types	that	can	be	used	to	represent	other	code	elements	
            // in	lambda	expressions, including	conditional	operation,	loops	and	collections. 
        }

        public class MultiplyToAdd : ExpressionVisitor
        {
            public Expression Modify(Expression expression)
            {
                return Visit(expression);
            }

            protected override Expression VisitBinary(BinaryExpression expression)
            {
                if (expression.NodeType == ExpressionType.Multiply)
                {
                    Expression left = this.Visit(expression.Left);
                    Expression right = this.Visit(expression.Right);
                    //	Make	this	binary	expression	an	Add	rather	than	a	multiply	operation.													
                    return	Expression.Add(left,	right);								
                }
                return base.VisitBinary(expression);
            }
        }

        // An	expression	tree	is	immutable,	which	means	that	the	elements	in	the expression	cannot	be	changed	once	the	expression	
        // has	been	created.	To	modify an	expression	tree	you	must	make	a	copy	of	the	tree	which	contains	the	modified 
        // behaviors. 
        public void ModifyingExpressionTree()
        {
            Expression<Func<int, int>> squareExp = num => num * num;
            MultiplyToAdd m = new MultiplyToAdd();
            Expression<Func<int, int>> addExpression = (Expression<Func<int, int>>)m.Modify(squareExp);
            Func<int, int>    doAdd = addExpression.Compile();
            Console.WriteLine("Double	of	4:	{0}", doAdd(4));
        }

        // 
        // 
        // 
        // 
        public void AssemplyObject()
        {

        }

        // 
        // 
        // 
        // 
        public void PropertyInfo()
        {

        }

        // 
        // 
        // 
        // 
        public void MethodInfoReflection()
        {

        }
    }
}
