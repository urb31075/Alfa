// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkerModule.cs" company="URBModel">
//   All Right Reserved  
// </copyright>
// <summary>
//   Defines the WorkerModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using CalculateLib;

    using Nancy;
    using Nancy.Extensions;
    using Nancy.ModelBinding;

    /// <inheritdoc />
    /// <summary>
    /// The worker module.
    /// </summary>
    public sealed class WorkerModule : NancyModule
    {
        /// <summary>
        /// The host filter.
        /// </summary>
        private readonly Func<Request, bool> hostFilter = c => c.Headers.Host == "localhost:5000" || c.Headers.Host == "127.0.0.1:5000";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Alfa.WorkerModule" /> class.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        public WorkerModule(IAbstractOperation operation)
        {
            this.Post(
                "/testjob1",
                parameter => // { "Val" : [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] }
                {
                    var text = this.Context.Request.Body.AsString();
                    Console.WriteLine(text);
                    var data = this.Bind<TestJob1Data>();
                    if (data.Val == null)
                    {
                        return this.Response.AsText("Data format error!");
                    }

                    var result = TestJobOperation.SummEverySecondOdd(data.Val);
                    return this.Response.AsText(result.ToString());
                });

            this.Post(
                "/testjob2",
                parameter => // { "Val1" : [100, 200, 300] "Val2" : [1, 2, 3]  }
                {
                    var text = this.Context.Request.Body.AsString();
                    Console.WriteLine(text);
                    var data = this.Bind<TestJob2Data>();
                    if (data.Val1 == null || data.Val2 == null)
                    {
                        return this.Response.AsText("Data format error!");
                    }

                    var result = TestJobOperation.SummList(data.Val1, data.Val2);
                    return this.Response.AsText(result.ToString());
                });

            this.Post(
                "/testjob3",
                parameter => // { "Val" : "zopaapoz" }
                {
                    var text = this.Context.Request.Body.AsString();
                    Console.WriteLine(text);
                    var data = this.Bind<TestJob3Data>();
                    if (data.Val == null)
                    {
                        return this.Response.AsText("Data format error!");
                    }

                    var result = TestJobOperation.IsPaliander(data.Val);
                    return this.Response.AsText(result.ToString());
                });

            this.Get(
                "/",
                _ =>
                {
                    Console.WriteLine(this.Context.Request.UserHostAddress);
                    dynamic view = new DynamicDictionary();
                    view.MyTimeStamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    view.MyHost = this.Request.Headers.Host;
                    return this.View["index.html", view];
                });

            this.Get("/debug", _ => "Wlan  host debug routine");
            this.Get("/debug", _ => "Local host debug routine", context => this.hostFilter(context.Request));
            this.Get(
                "/debugdataText",
                _ => this.Response.AsText(new DebugData { Name = "xxx", Status = true, Crc = 12345 }.ToString()));
            this.Get(
                "/debugdataJson",
                _ => this.Response.AsJson(new DebugData { Name = "xxx", Status = true, Crc = 12345 }));
            this.Get(
                "/debugdataXml",
                _ => this.Response.AsXml(new DebugData { Name = "xxx", Status = true, Crc = 12345 }));
            this.Post(
                "/debugdataJson",
                _ => // json {"name":"xxx","status":true,"crc":12345} 
                {
                    var debugData = this.Bind<DebugData>();
                    return debugData.ToString();
                });

            this.Post(
                "/debugdataurl",
                _ => // x-www-form-urlencoded  Name=aaa&Status=false&Crc=555
                {
                    var debugData = new DebugData { Name = this.Request.Form.Name, Status = this.Request.Form.Status, Crc = this.Request.Form.Crc };
                    return debugData.ToString();
                });

            this.Get("/index", _ => this.View["index"]);
            this.Get("/data_set_1.txt", _ => this.Response.AsFile("data_set_1.txt"));
            this.Get("/data_set_2.txt", _ => this.Response.AsFile("data_set_2.txt"));
            this.Get("/data_set_3.txt", _ => this.Response.AsFile("data_set_3.txt"));

            this.Get("/test/{testId:int}", parameter => " Test case with parameter " + (int)parameter.testId);
            this.Get("/operation1", _ => operation.Operation1());
            this.Get("/operation2", _ => operation.Operation2());
            this.Get("/operation3", _ => operation.Operation3());

            // Post("/data/{dataId:int}", async(parameter, _ ) =>
            this.Post(
                "/data/{dataId:int}",
                parameter =>
                {
                    var values = this.Bind<int[]>();
                    var summ = values.Aggregate("[", (c, next) => c + next + " ", c => c.Trim() + "]");
                    Console.WriteLine("/data/{dataId:int}" + summ.Trim());

                    var dataId = (int)parameter.dataId;
                    return "Data with " + dataId;
                });
            this.Get("/ArrayAsJson", _ => this.Response.AsJson(new[] { "111", "222", "333" }));
            this.Get("/StringAsJson", _ => this.Response.AsJson("String as Json"));
            this.Get("/DoubleIntArrayAsJson", _ => this.Response.AsJson(new[] { new[] { 111, 222, 333 }, new[] { 1, 2, 3 } }));
        }

        /// <summary>
        /// The debug data.
        /// </summary>
        public class DebugData
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            // ReSharper disable once MemberCanBePrivate.Local
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether status.
            /// </summary>
            // ReSharper disable once MemberCanBePrivate.Local
            public bool Status { get; set; }

            /// <summary>
            /// Gets or sets the crc.
            /// </summary>
            // ReSharper disable once MemberCanBePrivate.Local
            public int Crc { get; set; }

            /// <summary>
            /// The to string.
            /// </summary>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public override string ToString()
            {
                return $"DebugData: {this.Name} {this.Status} {this.Crc}";
            }
        }

        /// <summary>
        /// The operation 1 data.
        /// </summary>
        // ReSharper disable once ClassNeverInstantiated.Local
        private class TestJob1Data
        {
            /// <summary>
            /// Gets or sets the val.
            /// </summary>
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public IEnumerable<int> Val { get; set; }
        }

        /// <summary>
        /// The operation 2 data.
        /// </summary>
        // ReSharper disable once ClassNeverInstantiated.Local
        private class TestJob2Data
        {
            /// <summary>
            /// Gets or sets the val 1.
            /// </summary>
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public IEnumerable<int> Val1 { get; set; }

            /// <summary>
            /// Gets or sets the val 2.
            /// </summary>
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public IEnumerable<int> Val2 { get; set; }
        }

        /// <summary>
        /// The operation 3 data.
        /// </summary>
        // ReSharper disable once ClassNeverInstantiated.Local
        private class TestJob3Data
        {
            /// <summary>
            /// Gets or sets the val.
            /// </summary>
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string Val { get; set; }
        }
    }
}