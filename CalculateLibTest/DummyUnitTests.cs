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
            Assert.IsTrue(false);
        }
    }
}
