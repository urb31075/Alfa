// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com/
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationWork.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
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