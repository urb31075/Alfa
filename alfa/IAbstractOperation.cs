// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAbstractOperation.cs" company="URBLab">
//   All Right Reserved   
// </copyright>
// <summary>
//   The AbstractOperation interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
{
    /// <summary>
    /// The AbstractOperation interface.
    /// </summary>
    public interface IAbstractOperation
    {
        /// <summary>
        /// The operation 1.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Operation1();

        /// <summary>
        /// The operation 2.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Operation2();

        /// <summary>
        /// The operation 3.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Operation3();
    }
}