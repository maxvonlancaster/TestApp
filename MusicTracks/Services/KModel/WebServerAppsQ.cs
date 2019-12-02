using Microsoft.Extensions.DependencyInjection;
using MusicTracks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Services.KModel
{
    public class WebServerAppsQ
    {
        // Asp net core fundamentals
        static public IServiceCollection AppStartup(IServiceCollection services)
        {
            // The Startup class is where:
            // Services required by the app are configured.
            // The request handling pipeline is defined.
            // Services are components that are used by the app. For example, a logging component is a service. Code to configure(or register) 
            // services is added to the Startup.ConfigureServices method.

            services.AddScoped<IConsumeData, ConsumeData>();
            services.AddScoped<IValidateAppInput, ValidateAppInput>();
            return services;
        }

        public void DependencyInjection()
        {

        }

        public void Routing()
        {

        }


        // Asp net core MVC
        // MVC basics(Model, View, Controller, DI)
        public void MvcBasics()
        {

        }

        //Model Binding
        public void ModelBinding()
        {

        }

        //Security and Identity(concepts understanding)
        //Authentification
        public void Authentication()
        {

        }

        //Using identity
        public void UsingIdentity()
        {

        }

        //Authorization with roles
        public void AuthorizationWithRoles()
        {

        }

        //Bundle and Minify assets
        public void BundleAndMinifyAssets()
        {

        }
    }
}
