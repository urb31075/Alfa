// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsPalianderUnitTests.cs" company="URBLab">
//   All Right Reserved 
// </copyright>
// <summary>
//   Defines the IsPalianderUnitTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalculateLibTest
{
    using CalculateLib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The is paliander unit tests.
    /// </summary>
    [TestClass]
    public class IsPalianderUnitTests
    {
        /// <summary>
        /// The is paliander 1.
        /// </summary>
        [TestMethod]
        public void IsPaliander1()
        {
            Assert.IsTrue(TestJobOperation.IsPaliander("1234554321"));
        }

        /// <summary>
        /// The is paliander 2.
        /// </summary>
        [TestMethod]
        public void IsPaliander2()
        {
            Assert.IsFalse(TestJobOperation.IsPaliander("1234512345"));
        }

        /// <summary>
        /// The is paliander 3.
        /// </summary>
        [TestMethod]
        public void IsPaliander3()
        {
            Assert.IsTrue(TestJobOperation.IsPaliander("1 2    3 45            5 4         32        1"));
        }
    }
}
