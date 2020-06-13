export default class AmcQuestions {
    // Name all data types in JavaScript.
    DataTypes() {
        // The number type represents both integer and floating point numbers.
        let n = 12;
        n = 12.34;
        console.log(1 / 0) // infinity -> also a number
        let a = 'a';
        console.log(a / 2); // not a number -> NaN

        // A BigInt is created by appending n to the end of an integer literal:
        let m = 10932857493752843756243876134758623198065987256876n;

        // strings:
        let s = 's';
        s = "s";
        s = `s`;

        // booleans:
        let b = 1 > 4;

        // In JavaScript, null is not a “reference to a non-existing object” or a “null pointer” like in some other languages.
        let n = null;

        // The meaning of undefined is “value is not assigned”.
        let x;
        console.log(x);

        // Objects and Symbols

        // The typeof operator returns the type of the argument. 
        console.log(typeof undefined); // "undefined"
        console.log(typeof 0); // "number"
        console.log(typeof 10n); // "bigint"
        console.log(typeof true); // "boolean"
        console.log(typeof "foo"); // "string"
        console.log(typeof Symbol("id")); // "symbol"
        console.log(typeof Math); // "object"  (1)
        console.log(typeof null); // "object"  (2)
        console.log(typeof alert); // "function"  (3)
    }

    // Compare the reference types and primitive types.
    //A variable can hold one of two value types: primitive values or reference values.
    //  Primitive values are data that are stored on the stack.
    //  Primitive value is stored directly in the location that the variable accesses.
    //  Reference values are objects that are stored in the heap.
    //  Reference value stored in the variable location is a pointer to a location in memory where the object is stored.
    //  Primitive types include Undefined, Null, Boolean, Number, or String.
    //The Basics:
    //Objects are aggregations of properties.A property can reference an object or a primitive.Primitives are values, they have no properties.
    //Updated:
    //JavaScript has 6 primitive data types: String, Number, Boolean, Null, Undefined, Symbol(new in ES6).With the exception of null and undefined,
    //all primitives values have object equivalents which wrap around the primitive values, e.g.a String object wraps around a string primitive.
    //All primitives are immutable.


    // Describe the ways of checking data types.What are the possible difficulties of determining the data type ?
    CheckingDataTypes()
    {
        // USE TYPEOF TO CHECK THE TYPE OF A VARIABLE AT RUNTIME
        let b = true;
        console.log(typeof b);

        console.log(typeof foo);
    }

    // Describe the difference between Abstract Equality Comparison and Strict Equality Comparison.


    // Describe the process of the type coercion and rules of comparing the same and different data types.


    // Name the built -in and native types.Describe wrappers / boxing.


    // Name the data types that can and cannot contain values / types of objects.Name the ways to detect them.


    // What is the practical use of the Symbol data type ?


    //********************************************************************************************************************************



    // Describe the statements and expressions.What are the side effects of expressions ?
    // Define Operator Precedence.Specify the usage of logical and binary operators.
    // Explain what Objects and Arrays destructuring is.
    // Specify loops, conditions, and the execution context.
    // Describe the error handling process in JavaScript.
    // How / when to use the Use strict directive ? How does it affect the JavaScript execution ?
    //********************************************************************************************************************************



    // Describe all variable declaration types and the difference between them.
    // Is there any way to determine whether the variable is declared in a specific scope ?
    // What is scope ? What scope types exist in JavaScript ? What is the difference between the function and block scopes ?
    // What are a hoisting and temporal dead zone ?
    // Scope chain, lexical environment, and variable name resolution.
    // What is closure ?
    // Describe the Memory Lifecycle in the context of the closure.
    //********************************************************************************************************************************



    // Name all the approaches to declare and invoke functions in JavaScript and describe how they affect their execution.
    // What does it mean: the functions in JavaScript are first - class objects?
    // What is the difference between the execution context, scope, and static properties ?
    // What does this keyword refer to in JavaScript ?
    // Provide a description of the partial application of functions vs.currying.
    // Describe the practice of the borrowing method.
    //********************************************************************************************************************************



    // Describe the OOP principles and their implementation in JavaScript.
    // What is the difference between the classical and prototypal inheritance ?
    // Name all the possible ways to create an object and object`s property in JavaScript.
    // Describe the attributes of the object and the object`s property.
    // Do access modifiers exist in JavaScript ? Is it possible to simulate them, and how ?
    // What are the pros and cons of functional programming vs.object - oriented programming ?
    // What is functional programming ?
    // What is a high - order function?
    // What is a pure function?
    // What is currying ?
    // What does favor object composition over class inheritance mean ?
    // Compare the imperative programming and declarative programming.
    // Describe SOLID and JavaScript.Provide an example of dependency injection and inversion of control in JavaScript.Are they related ?
    //********************************************************************************************************************************



    // What are two - way data binding and one - way data flow ? How do they differ ?
    // What are the pros and cons of monolithic and microservice architectures ?
    //********************************************************************************************************************************



    // What are the ways to handle the async code ?
    AsyncCode()
    {

    }

    // What is a callback hell, and how can you avoid it ?
    CallbackHell()
    {

    }

    // Describe how async / await works.
    // Describe the generators and iterators and their possible usage in async JavaScript.
    // Provide yield - delegation examples and generators concurrency.
    // Describe Web Workers, Shared Workers.
    // Describe the micro and macro tasks in the context of the event loop ?
    //********************************************************************************************************************************



    // Name the most commonly used Array methods.
    ArrayMethods()
    {
        let fruits = ["Orange", "Apple", "Banana", "Mango"]
        console.log(fruits.toString()); // converts an array to a string of (comma separated) array values

        console.log(fruits.join(" * ")); // method also joins all array elements into a string, but in addition you can specify the separator

        // removes the last element from an array, returns the value that was "popped out"
        console.log(fruits.pop());

        // adds a new element to an array (at the end), returns new array length
        console.log(fruits.push("Kiwi"));

        // Shifting is equivalent to popping, working on the first element instead of the last.
        console.log(fruits.shift());

        // unshift() method adds a new element to an array (at the beginning), returns new array length:
        console.log(fruits.unshift("Peach"));

        // Since JavaScript arrays are objects, elements can be deleted by using the JavaScript operator delete
        delete fruits[0];

        // splice() method can be used to add new items to an array
        fruits.splice(2, 0, "Lemon", "Apricot"); // where to add, how many el-s to remove; can be used to remove el-s

        // The concat() method creates a new array by merging (concatenating) existing arrays:

        fruits.sort();        // First sort the elements of fruits
        fruits.reverse();     // Then reverse the order of the elements
        // can be provided with compare function

    }

    // Describe how the reduce method works.What is the difference between slice and splice ?
    // Describe Map, Set, WeakMap, and WeakSet.
    // What traditional data structures do you know ? How do they correspond with data structures available in JavaScript ?
    //********************************************************************************************************************************



    // What is the NodeJS event loop ?
    // What are the pros and cons of NodeJS ? In what cases should NodeJS be used and when should it not ?
    // What are streams in Node.js ?
    // Explain different types of streams in NodeJS.
    // Describe multithreading in NodeJS.
    // How to utilize multiple cores in a single NodeJS application ?
    // Explain the difference between programming in JS for NodeJS and browsers.
    // Suggest an application structure / architecture for NodeJS based REST API server.
    //********************************************************************************************************************************



    // Name the most common test types and explain the difference between them.
    // Describe TDD / BDD.
    // What are the best practices of code testing in JavaScript ?
    //********************************************************************************************************************************

}