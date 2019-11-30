// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="URBLab">
//   All Right Reserved   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DupelOperation
{
    using System;
    using System.IO;

    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Start informer!");
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}