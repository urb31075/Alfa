// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com/
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationFacke.cs" company="URBLab">
//   All Right Reserved  
// </copyright>
// <summary>
//   Defines the FackeOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
{
    /// <inheritdoc />
    /// <summary>
    /// The facke operation.
    /// </summary>
    public class OperationFacke : IAbstractOperation
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
            return "Facke operation 1 Result";
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
            return "Facke operation 2 Result";
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
            return "Facke operation 3 Result";
        }
    }
}