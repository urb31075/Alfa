// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationWork.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace DupelOperation
{
    /// <inheritdoc />
    /// <summary>
    /// The worker operation.
    /// </summary>
    public class OperationWork : IAbstractOperation
    {
        /// <inheritdoc />
        /// <summary>
        /// The operation 1.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string Operation1()
        {
            return "Alfa operation 1 Result";
        }

        /// <inheritdoc />
        /// <summary>
        /// The operation 2.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string Operation2()
        {
            return "Alfa operation 2 Result";
        }

        /// <inheritdoc />
        /// <summary>
        /// The operation 3.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string Operation3()
        {
            return "Alfa operation 3 Result";
        }
    }
}