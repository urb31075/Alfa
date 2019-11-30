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
