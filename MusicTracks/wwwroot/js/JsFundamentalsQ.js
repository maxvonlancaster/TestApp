export default class Fundamentals
{
    Variables()
    {
        // variables are declared using var keyword, declare before u-ng:
        var i;
        var sum;
        // multiple declaration:
        var a, b;
        // combine declaration with initialization:
        var i = 0, j = 0, k = 0;
        // if not initialized -> undefined
        // variable can hold any type of value:
        var d = 0;
        d = "message";
        // may be add scopes later
    }

    TypeConversion()
    {
        // js is flexible about types of values. Some convert to true, some to false, if converted to boolean 
        console.log(null == undefined); // These two values are treated as equal.
        console.log("0" == 0); // String converts to a number before comparing.
        console.log(0 == false); // Boolean converts to number before comparing.
        console.log("0" == false); // Both operands convert to numbers before comparing.  === does not perform conversion before testing        // all of above are logged true        // Explisit conversions -> to make code cleaner:
        var i = Number("3"); // => 3
        i = String(false); // => "false" Or use false.toString()
        i = Boolean([]); // => true
        i = Object(3); // => new Number(3)
        i = i + "" // Same as String(x)
        i = +i // Same as Number(x). You may also see x-0
        i = !!i // Same as Boolean(x). Note double !
        var n = 17;
        console.log(n.toString());
        // converting to strings with precisions:
        n = 123456.789;
        console.log(n.toFixed(0)); // "123457"
        console.log(n.toFixed(2)); // "123456.79"
        console.log(n.toFixed(5)); // "123456.78900"
        console.log(n.toExponential(1)); // "1.2e+5"
        console.log(n.toExponential(3)); // "1.235e+5"
        console.log(n.toPrecision(4)); // "1.235e+5"
        console.log(n.toPrecision(7)); // "123456.8"
        console.log(n.toPrecision(10)); // "123456.7890"

        parseInt("3 blind mice") // => 3
        parseFloat(" 3.14 meters") // => 3.14
        parseInt("-12.34") // => -12
        parseInt("0xFF") // => 255
        parseInt("0xff") // => 255
        parseInt("-0XFF") // => -255
        parseFloat(".1") // => 0.1
        parseInt("0.1") // => 0
        parseInt(".1") // => NaN: integers can't start with "."
        parseFloat("$72.47"); // => NaN: numbers can't start with "$"
        // parseInt() also accepts second argument speciying the base (radix) of number to be parsed -> between 2 and 36:
        parseInt("11", 2); // => 3 (1*2 + 1)
        parseInt("ff", 16); // => 255 (15*16 + 15)
        parseInt("zz", 36); // => 1295 (35*36 + 35)
        parseInt("077", 8); // => 63 (7*8 + 7)
        parseInt("077", 10); // => 77 (7*10 + 7)
    }

    Operators()
    {
        // Operators used in arithmetic expressions, comparison, logical expression, assignements and more
        // unary, binary, ternary operators

    }

    ControlAndLoopConstructions()
    {
        var n = Math.floor(Math.random() * 4);
        // if else - evaluete expression
        if (n == 0) {
            console.log("Zero");
        }
        else if (n == 1) {
            console.log("One");
        }
        else if (n == 2) {
            console.log("Two");
        }
        else {
            console.log("Else");
        }
        // switch:
        switch (n) {
            case 0:
                console.log("Zero");
                break;
            case 1:
                console.log("One");
                break;
            case 2:
                console.log("Two");
                break;
            default:
                break;
        }

        // Loops -> while, do-while(is always execurted at least once, tested at the end), for, for-in
        var c = 0;
        while (c < 5) {
            console.log(c);
            c++;
        }

        do {
            console.log("do-while:", c);
            c--;
        } while (i > 0);

        var sum = 0;
        for (var i = 0; i < 10; i++ )
        {
            sum += i * i;
        }
        console.log("sum=", sum);

        var a = { 1: "a", 2: "b", 3: "c" };
        for (i in a) {
            console.log("for in:",i);
        };
    }

    FunctionsContextScopes()
    {
        // Varible scope: region of program in which it is defined. Global(everywhere defined) and local (func. parameters)
        // Within the body of a function local var takes precedence over global
        var v = "global";
        function check()
        {
            var v = "local";// use var to local var-s, otherwise -> owerwrite global ones
            return v;
        }
        console.log(check());

        // nested scope:
        var n = "global";
        function check()
        {
            var n = "local";
            function checkN()
            {
                var n = "nested"; // variables are visible withinf function they are defined in and nested in them
                return n;
            }
            return checkN();
        }
        console.log(check());


        // FUNCTIONS
        function factorial(x) {
            if (x <= 1) return 1;
            return x * factorial(x - 1);
        }
        console.log("10!=",factorial(10));
        // assign to variable:
        var squere = function (x) { return x * x; }
        console.log(squere(21));
        var g = factorial;
        console.log("5!=",g(5));

        // method - function, that is stored as a property of object
        var calc = {
            a: 1,
            b: 1,
            add: function () {
                this.result = 1 + 1;
            }
        }
        calc.add();
        console.log("1+1=",calc.result);

        function f(x) {
            console.log("f:", x);
            arguments[0] = null; // arguments object within the body of a function
            console.log(x); // x is now null
        }

        var o = new Object();
        o.m = f; // m is now property of object o -> method
        o.m(1);

        // callee property:
        var factorialNew = function (x) {
            if (x <= 1) return 1;
            return x * arguments.callee(x - 1);
        }

        var a = [function (x) { return x * x; }, 20];
        console.log(a[0](a[1])); // functions dont require names 

        // Using functions as data:
        function operate(operator, a) {
            return operator(a);
        }
        console.log("operate: ",operate(g, 2));
    }

    Arrays()
    {
        // Array -> ordered collection of data. 0-based. Dynamic(no fixed size), and sparsed(may have gaps)
        var empty = [];
        var primes = [2, 3, 5, 7, 11];
        var misc = [1.1, true, "a"]; // differend types
        // the values may not be constants, but any expressions
        var undefs = [, ,]; // An array with 2 elements, both undefined.        var base = 1024;
        var table = [base, base + 1, base + 2, base + 3];
        var a = new Array(10); // array of length 10

        // reading writting:
        var a = ["w"];
        var val = a[0];
        a[1] = 3.14;
        i = 2;
        a[i] = 3;
        a[i + 1] = "h";
        a[a[i]] = a[0];
        console.log(a);
        // arrays -> specific kind of objects
        var o = {};
        o[1] = "1";

        // Sparse arrays:
        a = []; // Create an array with no elements and length = 0.
        a[1000] = 0; // Assignment adds one element but sets length to 1001.

        // Length
        a = [1, 2, 3, 4, 5]; // Start with a 5-element array.
        a.length = 3; // a is now [1,2,3].
        a.length = 0; // Delete all elements. a is [].
        a.length = 5; // Length is 5, but no elements, like new Array(5)        a.push("p"); // adds elements to the end of array
        a.push("a", "b");

        // Deleting:
        a = [1, 2, 3];
        delete a[1]; // a now has no element at index 1
        console.log(1 in a); // => false: no array index 1 is defined
        a.length; // => 3: delete does not affect array length

        // Iterating:
        for (var i = 0; i < a.length; i++) {
            console.log(a[i]);
        }

        for (var i in a) {
            console.log(i); // will print indexes present in a
            console.log(a[i]);
        }

        // Joining:
        a = [1, 2, 3];
        console.log(a.join()) // "1,2,3"
        console.log(a.join(" ")) // "1 2 3"
        console.log(a.join("")) // "123"
        var b = new Array(10);
        console.log(b.join("-")) // "---------"

        // Reverse:
        a.reverse().join() // => "3,2,1" 

        // Sort:
        a = ["b", "a", "c"];
        var s = a.sort();
        console.log(s.join(", "));

        // Concat -> adds elements to the end of array:
        a = [1, 2, 3]
        a.concat(4, 5, 6);

        // Slicing:
        a.slice(1, 3);
        a.slice(1, -1); // [2,3,4,5]

        // Push and Pop -> to work with arrays as stacks
        var stack = [];
        stack.push(1,2);
        console.log(stack.pop()); // 2

        // Following are for ECMAScript 5:
        // Foreach:
        var data = [1, 2, 3, 6, 7, 8];
        var sum = 0;
        data.forEach(function (value) { sum += value });
        console.log(sum);

        // Map - processes a-y and returns new array
        var b = data.map(function (x) { return x * x; });

        // Filter:
        var smallones = data.filter(function (x) { return x < 3; });

        // IndexOf:
        a = [0, 1, 2, 1, 0];
        console.log(a.indexOf(1)); // 1
        console.log(a.lastIndexOf(1)); // 3
        console.log(a.indexOf(3)); // -1

        // Strings as arrays:
        var s = "test";
        console.log(s[1]);
    }

    WebBrowserAndDom()
    {

    }
}

