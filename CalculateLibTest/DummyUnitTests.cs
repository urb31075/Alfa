// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyUnitTests.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   Defines the DummyUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalculateLibTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The dummy unit tests.
    /// </summary>
    [TestClass]
    public class DummyUnitTests
    {
        /// <summary>
        /// The failed dummy test.
        /// </summary>
        [TestMethod]
        public void FailedDummyTest()
        {
            Assert.IsTrue(true);
        }
    }
}
