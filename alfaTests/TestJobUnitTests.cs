// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestJobUnitTests.cs" company="URBLab">
//   All Roght Reserved
// </copyright>
// <summary>
//   Defines the ShouldReturnStatusOk type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AlfaTests
{
    using Nancy;
    using Nancy.Testing;
    using NUnit.Framework;

    /// <summary>
    /// The should return status ok.
    /// </summary>
    [TestFixture]
    public class TestJobUnitTests
    {
        /// <summary>
        /// The should return status ok when route exists 4.
        /// </summary>
        [Test]
        public void SummEverySecondOdd1()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Post(
                "/testjob1",
                with =>
                {
                    with.HttpRequest();
                    with.Header("content-type", "application/json");
                    with.Body("{ \"Val\" : [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] }");
                });

            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            Assert.AreEqual("28", actual);
        }

        /// <summary>
        /// The summ list 1.
        /// </summary>
        [Test]
        public void SummList1()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Post(
                "/testjob2",
                with =>
                    {
                        with.HttpRequest();
                        with.Header("content-type", "application/json");
                        with.Body("{ \"Val1\" : [100, 200, 300] \"Val2\" : [1, 2, 3] }");
                    });

            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            Assert.AreEqual("0", actual);
        }

        /// <summary>
        /// The is paliander 1.
        /// </summary>
        [Test]
        public void IsPaliander1()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Post(
                "/testjob3",
                with =>
                    {
                        with.HttpRequest();
                        with.Header("content-type", "application/json");
                        with.Body("{ \"Val\" : \"zopaapoz\" }");
                    });

            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            Assert.AreEqual("True", actual);
        }

        /// <summary>
        /// The is paliander 2.
        /// </summary>
        [Test]
        public void IsPaliander2()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);
            var result = browser.Post(
                "/testjob3",
                with =>
                    {
                        with.HttpRequest();
                        with.Header("content-type", "application/json");
                        with.Body("{ \"Val\" : \"1234512345\" }");
                    });

            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
            var actual = result.Result.Body.AsString();
            Assert.AreEqual("False", actual);
        }
    }
}