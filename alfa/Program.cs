namespace alfa
{
    using System;
    using System.IO;
    using System.Linq;
    using Nancy;
    using Nancy.Owin;
    using Nancy.ModelBinding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using System.Collections.Generic;

    public interface IAbstractOperation
    {
        string Operation1();
        string Operation2();
        string Operation3();
    }

    public class AlfaOperation : IAbstractOperation
    {
        public string Operation1() { return "Alfa operation 1 Result"; }
        public string Operation2() { return "Alfa operation 2 Result"; }
        public string Operation3() { return "Alfa operation 3 Result"; }
    }

    public class FackeOperation : IAbstractOperation
    {
        public string Operation1() { return "Facke operation 1 Result"; }
        public string Operation2() { return "Facke operation 2 Result"; }
        public string Operation3() { return "Facke operation 3 Result"; }
    }

    public class IndexModule : NancyModule
    {
        public IndexModule(IAbstractOperation operation)
        {
            Get("/", _ => "Alfa root endpoint!");
            Get("/test/{testId:int}", parameter => { return " Test case with parameter " + (int)parameter.testId; });
            Get("/operation1", _ => operation.Operation1());
            Get("/operation2", _ => operation.Operation2());
            Get("/operation3", _ => operation.Operation3());
            //Post("/data/{dataId:int}", async(parameter, _ ) =>
            Post("/data/{dataId:int}", parameter =>
            {
                    var values = this.Bind<int[]>();
                    string summ = values.Aggregate("[", (c, next) => c + next + " ", c => c.Trim() + "]");
                    Console.WriteLine("/data/{dataId:int}" + summ.Trim());

                    var dataId = (int)parameter.dataId;
                    return "Data with " + dataId;
                });
            Get("/dupel", _ => new List<string>(){ "111", "222", "333" });
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(buildFunc =>
            {
                buildFunc(next => env =>
                {
                    Console.WriteLine("Recive reqest at: " + DateTime.Now.ToLongTimeString() + "!");
                    return next(env);
                });
                Console.WriteLine("Start OWIN!");
                buildFunc.UseNancy();
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}

