// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyUnitTests.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   Defines the DummyUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AlfaTests
{
    using NUnit.Framework;

    /// <summary>
    /// The dummy unit tests.
    /// </summary>
    [TestFixture]
    public class DummyUnitTests
    {
        /// <summary>
        /// The failed dummy test.
        /// </summary>
        [Test]
        public void FailedDummyTest()
        {
           Assert.IsTrue(false);
        }
    }
}
