// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReturnBodyUnitTests.cs" company="URBLab">
//   All Roght Reserved
// </copyright>
// <summary>
//   Defines the ShouldReturnStatusOk type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AlfaTests
{
    using DupelOperation;

    using Nancy;
    using Nancy.Testing;
    using Newtonsoft.Json;
    using NUnit.Framework;

    /// <summary>
    /// The should return status ok.
    /// </summary>
    public class ReturnBodyUnitTests
    {
        /// <summary>
        /// The should return status ok when route debug exists.
        /// </summary>
        [Test]
        public void ShouldReturnStatusOkWhenRouteExists1()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Get("/debug", with => { with.HttpRequest(); });
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
        }

        /// <summary>
        /// The should return status ok when route exists 2.
        /// </summary>
        [Test]
        public void ShouldReturnStatusOkWhenRouteExists2()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Get("/debugdataText", with => { with.HttpRequest(); });
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            var expect = new WorkerModule.DebugData { Name = "xxx", Status = true, Crc = 12345 }.ToString();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// The should return status ok when route exists 3.
        /// </summary>
        [Test]
        public void ShouldReturnStatusOkWhenRouteExists3()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Get("/debugdataJson", with => { with.HttpRequest(); });
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString().Replace(" ", string.Empty);
            var expect = JsonConvert.SerializeObject(new WorkerModule.DebugData { Name = "xxx", Status = true, Crc = 12345 }).Replace(" ", string.Empty).ToLower();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// The should return status ok when route exists 4.
        /// </summary>
        [Test]
        public void ShouldReturnStatusOkWhenRouteExists4()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Post(
                "/debugdataJson",
                with =>
                    {
                        with.HttpRequest();
                        with.FormValue("name", "xxx");
                        with.FormValue("status", "true");
                        with.FormValue("crc", "12345");
                    });

            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            var expect = new WorkerModule.DebugData { Name = "xxx", Status = true, Crc = 12345 }.ToString();
            Assert.AreEqual(expect, actual);
        }
    }
}