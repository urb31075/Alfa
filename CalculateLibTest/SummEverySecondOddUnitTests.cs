// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummEverySecondOddUnitTests.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   Defines the TestJobOperationUnitTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalculateLibTest
{
    using CalculateLib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The test job operation unit test.
    /// </summary>
    [TestClass]
    public class SummEverySecondOddUnitTests
    {
        /// <summary>
        /// The summ every second odd 1.
        /// </summary>
        [TestMethod]
        public void SummEverySecondOdd1()
        {
            var result = TestJobOperation.SummEverySecondOdd(new[] { 1 });
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// The summ every second odd 2.
        /// </summary>
        [TestMethod]
        public void SummEverySecondOdd2()
        {
            var result = TestJobOperation.SummEverySecondOdd(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(6, result);
        }

        /// <summary>
        /// The summ every second odd 3.
        /// </summary>
        [TestMethod]
        public void SummEverySecondOdd3()
        {
            var result = TestJobOperation.SummEverySecondOdd(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.AreEqual(28, result);
        }

        /// <summary>
        /// The summ every second odd 4.
        /// </summary>
        [TestMethod]
        public void SummEverySecondOdd4()
        {
            var result = TestJobOperation.SummEverySecondOdd(new[] { 1, 2, 3, 4, -45, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.AreEqual(22, result);
        }
    }
}
