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
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public interface IAbstractOperation
    {
        string Operation1();
        string Operation2();
        string Operation3();
    }

    public class WorkerOperation : IAbstractOperation
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

    public class WorkerBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Register<IAbstractOperation, FackeOperation>();
        }
    }

    public class WorkerModule : NancyModule
    {
        private readonly Func<Request, bool> hostFilter = (c) => { return c.Headers.Host == "localhost:5000"; };
        private class DebugData
        {
            public string Name { get; set; }
            public bool   Status { get; set; }
            public int    Crc { get; set; }
            public override string ToString() { return $"DebugData: {Name} {Status} {Crc}"; }
        }

        public WorkerModule(IAbstractOperation operation)
        {
            Get("/", _ =>
               {
                   Console.WriteLine(Context.Request.UserHostAddress);
                   dynamic view = new DynamicDictionary();
                   view.MyTimeStamp = DateTime.Now.ToString();
                   view.MyHost = Request.Headers.Host;
                   return View["index.html", view];
               });

            Get("/debug", _ => "wlan  host debug routine");
            Get("/debug", _ => "local host debug routine", Context => hostFilter(Context.Request));
            Get("/debugdata", _ => Response.AsJson(new DebugData() { Name="xxx", Status = true, Crc=12345 }));
            Post("/debugdata", _ =>
            {
                var debugData = this.Bind<DebugData>();
                return debugData.ToString();
            });


            Get("/index", _ => View["index"]);
            Get("/data_set_1.txt", _ => Response.AsFile("data_set_1.txt"));
            Get("/data_set_2.txt", _ => Response.AsFile("data_set_2.txt"));
            Get("/data_set_3.txt", _ => Response.AsFile("data_set_3.txt"));

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
            Get("/ArrayAsJson", _ => Response.AsJson(new string[]{ "111", "222", "333" }));
            Get("/StringAsJson", _ => Response.AsJson("String as Json"));
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
                    Console.WriteLine("Recive reqest at: " + DateTime.Now.ToLongTimeString() + " !");
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

