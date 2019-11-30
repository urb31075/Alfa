// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="URBLab">
//   All Right Reserved     
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
{
    using System;

    using Microsoft.AspNetCore.Builder;

    using Nancy.Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(buildFunc =>
                {
                    buildFunc(next => env =>
                        {
                            Console.WriteLine("Recive reqest at: " + DateTime.Now.ToLongTimeString() + " !");
                            return next(env);
                        });
                    Console.WriteLine("Start OWIN!");
                    buildFunc.UseNancy();
                });
        }
    }
}