// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationWork.cs" company="URBLab">
//   All Right Reserved   
// </copyright>
// <summary>
//   Defines the OperationWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DupelOperation
{
    /// <inheritdoc />
    /// <summary>
    /// The worker operation.
    /// </summary>
    public class OperationWork : IAbstractOperation
    {
        /// <summary>
        /// The operation 1.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Operation1()
        {
            return "Alfa operation 1 Result";
        }

        /// <summary>
        /// The operation 2.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Operation2() { return "Alfa operation 2 Result"; }
        public string Operation3() { return "Alfa operation 3 Result"; }
    }
}