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

    }

    FunctionsContextScopes()
    {

    }

    Arrays()
    {

    }

    WebBrowserAndDom()
    {

    }
}

