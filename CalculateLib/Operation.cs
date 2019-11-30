// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="URBLab">
//   All Right Reserved   
// </copyright>
// <summary>
//   Defines the Operation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CalculateLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The operation.
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// The summ every second odd.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int SummEverySecondOdd(IEnumerable<int> val)
        {
            // сложения каждого второго нечетного числа из массива чисел тела запроса и вернёт их сумму по модулю.
            return Math.Abs(val.Where(c => c % 2 != 0).Where((с, index) => index % 2 != 1).Aggregate((summ, x) => summ + x));
        }

        /// <summary>
        /// The summ list.
        /// </summary>
        /// <param name="val1">
        /// The val 1.
        /// </param>
        /// <param name="val2">
        /// The val 2.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int SummList(IEnumerable<int> val1, IEnumerable<int> val2)
        {
            // сложение двух непустых связанных списков, представляющих два неотрицательных целых и больших нуля числа.
            // Цифры хранятся в обратном порядке, и каждый из их узлов содержит одну цифру. Сложите два числа и верните
            // их в виде связанного списка.
            
            // Текст задания полная дичь, постановщик был пьян ?
            return 0;
        }

        /// <summary>
        /// The is paliander.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsPaliander(string val)
        {
            // определения входящий строки является ли она палиндромом.
            var valByCheck = val.Replace(" ", string.Empty);
            return valByCheck.SequenceEqual(valByCheck.Reverse());
        }
    }
}
