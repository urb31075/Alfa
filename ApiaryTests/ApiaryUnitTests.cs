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
    using Xunit;

    /// <summary>
    /// The apiary unit test.
    /// </summary>
    public class ApiaryUnitTests
    {
        /// <summary>
        /// The dupel test 1.
        /// </summary>
        [Fact]
        public async void DupelTest1()
        {
            var baseAddress = new Uri("https://private-97c8ab-dupel.apiary-mock.com/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
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
