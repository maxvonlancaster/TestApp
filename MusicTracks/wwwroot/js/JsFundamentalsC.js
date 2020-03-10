export default class Fundamentals {

    Cookies() {
        // Cookies are data, stored in small text files, on your computer.
        // When a web server has sent a web page to a browser, the connection is shut down, and the server forgets everything about the user.
        // Cookies were invented to solve the problem "how to remember information about the user":
        // When a user visits a web page, his / her name can be stored in a cookie.
        // Next time the user visits the page, the cookie "remembers" his / her name.
        // Cookies are saved in name-value pairs
        // When a browser requests a web page from a server, cookies belonging to the page are added to the request. 
        // This way the server gets the necessary data to "remember" information about users.

        // JavaScript can create, read, and delete cookies with the document.cookie property.
        document.cookie = "userName=John Doe";
        // You can also add an expiry date (in UTC time). By default, the cookie is deleted when the browser is closed:
        document.cookie = "userName=John Doe; expires=Thu, 18 Dec 2013 12:00:00 UTC"; 
        // With a path parameter, you can tell the browser what path the cookie belongs to. By default, the cookie belongs to the current page.
        document.cookie = "userName=John Doe; expires=Thu, 18 Dec 2013 12:00:00 UTC; path=/"; 
        // Delete a cookie -> Just set the expires parameter to a passed date: (like 1970)

        // domain=site.com -> Домен, на котором доступны наши куки.На практике, однако, есть ограничения – мы не можем указать здесь какой угодно домен.

        // Параметр куки samesite предоставляет ещё один способ защиты от таких атак, который(теоретически) не должен требовать «токенов защиты xsrf».
        // У него есть два возможных значения: 
        // Куки с samesite=strict никогда не отправятся, если пользователь пришёл не с этого же сайта.
        // samesite=lax Это более мягкий вариант, который также защищает от XSRF и при этом не портит впечатление от использования сайта.

        // Веб-сервер использует заголовок Set-Cookie для установки куки. И он может установить настройку httpOnly.
        // Эта настройка запрещает любой доступ к куки из JavaScript.Мы не можем видеть такое куки или манипулировать им с помощью document.cookie.
    }

    WebStorage() {
        // With web storage, web applications can store data locally within the user's browser.
        // Before HTML5, application data had to be stored in cookies, included in every server request.Web storage is more secure, and large 
        // amounts of data can be stored locally, without affecting website performance.
        // Unlike cookies, the storage limit is far larger(at least 5MB) and information is never transferred to the server.
        // Web storage is per origin(per domain and protocol).All pages, from one origin, can store and access the same data.

        // HTML web storage provides two objects for storing data on the client:
        // window.localStorage - stores data with no expiration date
        // window.sessionStorage - stores data for one session(data is lost when the browser tab is closed)

        // Before using web storage, check browser support for localStorage and sessionStorage:
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("lastname", "Smith");
            alert(localStorage.lastname);
            localStorage.removeItem("lastname"); // for removing the item
            // Name/value pairs are always stored as strings. Remember to convert them to another format when needed!
        } else {

        }
    }

    EventUnderstanding() {
        // HTML events are "things" that happen to HTML elements. When JavaScript is used in HTML pages, JavaScript can "react" on these events.

        // <button onclick="document.getElementById('demo').innerHTML = Date()">The time is?</button>

        // Event handlers can be used to handle, and verify, user input, user actions, and browser actions:

        // Things that should be done every time a page loads
        // Things that should be done when the page is closed
        // Action that should be performed when a user clicks a button
        // Content that should be verified when a user inputs data

        // Many different methods can be used to let JavaScript work with events:

        // HTML event attributes can execute JavaScript code directly
        // HTML event attributes can call JavaScript functions
        // You can assign your own event handler functions to HTML elements
        // You can prevent events from being sent or being handled
        // And more ...
    }

    Clojures() {
        // JavaScript variables can belong to the local or global scope. Global variables can be made local(private) with closures.
        // A local variable can only be used inside the function where it is defined. It is hidden from other functions and other scripting code.

        var add = (function () {
            var counter = 0;
            return function () { counter += 1; return counter }
        })();

        add();
        add();
        add();

        // The variable add is assigned the return value of a self - invoking function.
        // The self - invoking function only runs once.It sets the counter to zero(0), and returns a function expression.
        // This way add becomes a function.The "wonderful" part is that it can access the counter in the parent scope.
        // This is called a JavaScript closure.It makes it possible for a function to have "private" variables.
        // The counter is protected by the scope of the anonymous function, and can only be changed using the add function.

    }

    AjaxJson() {
        // AJAX = Asynchronous JavaScript And XML.
        // AJAX is not a programming language.
        // AJAX just uses a combination of:
        // A browser built -in XMLHttpRequest object(to request data from a web server)
        // JavaScript and HTML DOM(to display or use the data)

        // AJAX allows web pages to be updated asynchronously by exchanging data with a web server behind the scenes. This means that it is 
        // possible to update parts of a web page, without reloading the whole page.
    }

    Es6() {
        // The let statement allows you to declare a variable with block scope.
        var x = 10;
        // Here x is 10
        {
            let x = 2;
            // Here x is 2
        }
        // Here x is 10


        // The const statement allows you to declare a constant (a JavaScript variable with a constant value).Are similar to let variables, except 
        // that the value cannot be changed.
        var x = 10;
        // Here x is 10
        {
            const x = 2;
            // Here x is 2
        }
        // Here x is 10


        // Arrow functions allows a short syntax for writing function expressions.
        // Arrow functions do not have their own this. They are not well suited for defining object methods.
        // Arrow functions are not hoisted.They must be defined before they are used.
        // Using const is safer than using var, because a function expression is always constant value.
        // You can only omit the return keyword and the curly brackets if the function is a single statement.
        const f = (x, y) => x * y;
        alert(f(10, 10));

        // ES6 introduced classes.
        // A class is a type of function, but instead of using the keyword function to initiate it, we use the keyword class, and the properties are 
        // assigned inside a constructor() method.
        // Use the keyword class to create a class, and always add a constructor method.
        // The constructor method is called each time the class object is initialized.
        class Car {
            constructor(brand) {
                this.carName = brand;
            }
        }

        let myCar = new Car("ferrari");
        alert(myCar.carName);

        // ES6 allows function parameters to have default values.
        function myFunction(x, y = 10) {
            // y is 10 if not passed or undefined
            alert(x + y);
        }
        myFunction(5);

        // The findIndex() method returns the index of the first array element that passes a test function.


        // ES6 added the following properties to the Number object:
        // EPSILON
        // MIN_SAFE_INTEGER
        // MAX_SAFE_INTEGER
        alert(Number.EPSILON);
        alert(Number.MIN_SAFE_INTEGER);
        alert(Number.MAX_SAFE_INTEGER);


        // ES6 added 2 new methods to the Number object:
        // Number.isInteger()
        // Number.isSafeInteger() -> A safe integer is an integer that can be exactly represented as a double precision number.
        alert(Number.isSafeInteger(10));    // returns true
        alert(Number.isSafeInteger(12345678901234567890));  // returns false
        alert(Number.isInteger(10.5));      // returns false

        // ES6 also added 2 new global number methods:
        // isFinite() ->  returns false if the argument is Infinity or NaN.
        // isNaN() -> returns true if the argument is NaN. Otherwise it returns false
        alert(isFinite(10 / 0));
        alert(isNaN("Hello"));

        // The exponentiation operator (**) raises the first operand to the power of the second operand. 
        // x ** y produces the same result as Math.pow(x,y)
        alert(5 ** 3);

    }

    Promise() {
        // The Promise object represents the eventual completion (or failure) of an asynchronous operation, and its resulting value.

        // A Promise is in one of these states:
        // pending: initial state, neither fulfilled nor rejected.
        // fulfilled: meaning that the operation completed successfully.
        // rejected: meaning that the operation failed.
    }

}