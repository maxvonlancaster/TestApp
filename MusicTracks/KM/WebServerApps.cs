using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.KM
{
    public class WebServerApps
    {
        // ASP.NET Core
        // ASP.NET Core fundamentals:
        // Application startup
        public void ApplicationStartUp() 
        {
            // The Startup class is where:
            // Services required by the app are configured.
            // The request handling pipeline is defined.
            // Services are components that are used by the app.For example, a logging component is a service. Code to configure(or register) 
            // services is added to the Startup.ConfigureServices method.
            // The request handling pipeline is composed as a series of middleware components. For example, a middleware might handle requests 
            // for static files or redirect HTTP requests to HTTPS.Each middleware performs asynchronous operations on an HttpContext and then 
            // either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is 
            // added to the Startup.Configure method.

            // The Startup class is specified when the app's host is built. The Startup class is typically specified by calling the 
            // WebHostBuilderExtensions.UseStartup<TStartup> method on the host builder.

        }

        // Dependency injection(services)
        public void DependencyInjection() 
        {
            // ASP.NET Core has a built-in dependency injection (DI) framework that makes configured services available to an app's classes. 
            // One way to get an instance of a service in a class is to create a constructor with a parameter of the required type. The 
            // parameter can be the service type or an interface. The DI system provides the service at runtime.

            // Transient objects are always different. A new instance is provided to each service request and client request.
            // Scoped objects are the same within a client request but different across client requests.
            // Singleton objects are the same for every object and every request regardless of whether an instance is provided in 
            // Startup.ConfigureServices.

            // Only the following service types can be injected into the Startup constructor when using the Generic Host (IHostBuilder):
            // IWebHostEnvironment
            // IHostEnvironment
            // IConfiguration
        }

        // Routing
        public void Routing() 
        {
            // A route is a URL pattern that is mapped to a handler. The handler is typically a Razor page, an action method in an MVC 
            // controller, or a middleware. ASP.NET Core routing gives you control over the URLs used by your app.


            // Matches request to an endpoint.
            //app.UseRouting();

            // Endpoint aware middleware. 
            // Middleware can use metadata from the matched endpoint.
            //app.UseAuthorization();

            // Execute the matched endpoint.
            //app.UseEndpoints(endpoints =>
            //{
            // Configuration of app endpoints.
            //endpoints.MapRazorPages();
            //endpoints.MapGet("/", context => context.Response.WriteAsync("Hello world"));
            //endpoints.MapHealthChecks("/healthz");
            //});

            // The ASP.NET Core middleware needs a way to determine if a given HTTP request should go to a controller for processing or not.
            // The MVC middleware will make this decision based on the URL and some configuration information we provide.
            // This approach is often referred to as the convention - based routing.

            // routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"); 
        }

        // ASP.NETCore MVC
        // MVC basics (Model, View, Controller, DI)
        // MVC (Model-View-Controller) is a pattern for building web applications that's used in almost every web framework (Ruby on Rails and 
        // Express are popular examples), plus frontend JavaScript frameworks like Angular. Mobile apps on iOS and Android use a variation of 
        // MVC as well.
        // As the name suggests, MVC has three components: models, views, and controllers.Controllers handle incoming requests from a client 
        // or web browser and make decisions about what code to run.Views are templates (usually HTML plus a templating language like Handlebars, 
        // Pug, or Razor) that get data added to them and then are displayed to the user.Models hold the data that is added to views, or data 
        // that is entered by the user.
        // There are two separate model classes that need to be created: a model that represents a item stored in the database (sometimes 
        // called an entity), and the model that will be combined with a view (the MV in MVC) and sent back to the user's browser.


        // Model Binding
        // Controllers and Razor pages work with data that comes from HTTP requests. For example, route data may provide a record key, and posted 
        // form fields may provide values for the properties of the model. Writing code to retrieve each of these values and convert them from 
        // strings to .NET types would be tedious and error-prone. Model binding automates this process. The model binding system:
        // Retrieves data from various sources such as route data, form fields, and query strings.
        // Provides the data to controllers and Razor pages in method parameters and public properties.
        // Converts string data to.NET types.
        // Updates properties of complex types.


        // Security and Identity (concepts understanding)
        // Authentification


        // Using identity


        // Authorization with roles


        // Bundle and Minify assets










        ////////////
        // COMPENENT

        // ASP.NET Core Fundamentals
        // Application Startup


        // Middleware


        // Working with Static Files


        // Routing


        // Error Handling


        // Globalization and localization


        // Configuration


        // Logging


        // File Providers


        // Dependency Injection


        // Working with Multiple Environments


        // Hosting


        // Managing Application State


        // Servers


        // Request Features


        // Open Web Interface for .NET(OWIN)


        // ASP.NET Core MVC
        // Model binding and validation


        // View(Razor, compilation, Layout, Tag Helpers, Partial Views, DI, View components)


        // Controllers(Route to actions, File uploads, )


        // Develop ASP.NET Core MVC apps


        // Advanced topics for ASP.NET Core MVC
        // Application model


        // Filters


        // Areas


        // Application Parts


        // Custom Model Building


        // IActionConstraint (7)


        // Host and deploy ASP.NET Core


        // Open Web Interface for .NET (OWIN) with ASP.NET Core


        // Web server implementations in ASP.NET Core(ASP.NET Core Module, Kestrel, http.sys)


        // Migrate from ASP.NET to ASP.NET Core


        // Troubleshoot ASP.NET Core projects


    }
}
