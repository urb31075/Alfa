// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiaryUnitTests.cs" company="URBLab">
//   All Right Reserved
// </copyright>
// <summary>
//   The apiary unit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ApiaryTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Polly;
    using Polly.Retry;

    using Xunit;

    /// <summary>
    /// The apiary unit test.
    /// </summary>
    public class ApiaryUnitTests
    {
        /// <summary>
        /// The base address.
        /// </summary>
        private static readonly Uri ApiaryBaseAddress = new Uri("https://private-97c8ab-dupel.apiary-mock.com/");

        /// <summary>
        /// The exponential retry policy.
        /// </summary>
        private static readonly AsyncRetryPolicy ExponentialRetryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(
            3,
            attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));

        /// <summary>
        /// The dupel test 1.
        /// </summary>
        [Fact]
        public async void DupelTest1()
        {
            using (var httpClient = new HttpClient { BaseAddress = ApiaryBaseAddress })
            {
                using (var response = await httpClient.GetAsync("test"))
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<DupelData>>(responseData);
                    Assert.Equal("aaa", data[0].Data1);
                    Assert.Equal("bbb", data[0].Data2);
                    Assert.Equal("ccc", data[0].Data3);
                }
            }

            Assert.True(true);
        }

        /// <summary>
        /// The dupel test 2.
        /// </summary>
        [Fact]
        public async void DupelTest2()
        {
            using (var httpClient = new HttpClient { BaseAddress = ApiaryBaseAddress })
            {
                await ExponentialRetryPolicy.ExecuteAsync(
                    async () =>
                        {
                            using (var response = await httpClient.GetAsync("test"))
                            {
                                var responseData = await response.Content.ReadAsStringAsync();
                                var data = JsonConvert.DeserializeObject<List<DupelData>>(responseData);
                                Assert.Equal("aaa", data[0].Data1);
                                Assert.Equal("bbb", data[0].Data2);
                                Assert.Equal("ccc", data[0].Data3);
                            }
                        });
            }

            Assert.True(true);
        }

        /// <summary>
        /// The dupel sub data.
        /// </summary>
        public class DupelSubData
        {
            /// <summary>
            /// Gets or sets the Mykey.
            /// </summary>
            public string Mykey { get; set; }

            /// <summary>
            /// Gets or sets the Votes.
            /// </summary>
            public int Votes { get; set; }
        }

        /// <summary>
        /// The dupel data.
        /// </summary>
        public class DupelData
        {
            /// <summary>
            /// Gets or sets the data 1.
            /// </summary>
            public string Data1 { get; set; }

            /// <summary>
            /// Gets or sets the data 2.
            /// </summary>
            public string Data2 { get; set; }

            /// <summary>
            /// Gets or sets the data 3.
            /// </summary>
            public string Data3 { get; set; }

            /// <summary>
            /// Gets or sets the data arr.
            /// </summary>
            public List<DupelSubData> DataArr { get; set; }
        }
    }
}
