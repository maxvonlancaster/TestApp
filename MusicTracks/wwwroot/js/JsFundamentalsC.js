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

    }

    EventUnderstanding() {

    }

    Clojures() {

    }

    AjaxJson() {

    }

    Es6() {

    }

    Promise() {

    }

}