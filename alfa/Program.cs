// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="URBLab">
//   All Right Reserved   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
// http://localhost:5000/
// https://habr.com/ru/company/microsoft/blog/342900/
// 1 https://habr.com/ru/post/197298/
// 2 https://habr.com/ru/post/199116/
// 3 https://habr.com/ru/post/199116/
// 4 https://habr.com/ru/post/200632/
// 5 https://habr.com/ru/post/203346/
// 6 https://habr.com/ru/post/203350/
namespace Alfa
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