using Fynance;
using MeijerCodeAssignment.Functions;
using MeijerCodeAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;

namespace Tests
{
    [TestClass]
    public class GetStockDataTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            GetStockData function = new GetStockData();
            var expectedData = new StockData()
            {
                Symbol = "AMC",
                Open = 57.16,
                Price = 54.27,
                Volume = 160962654,
                High = 63.12,
                Low = 47.15,
                Profile = new Profile()
                {
                    Name = "AMC Entertainment Holdings, Inc. (AMC)",
                    Description = "AMC Entertainment Holdings, Inc., through its subsidiaries, involved in the theatrical exhibition business. The company owns, operates, or has interests in theatres. As of March 12, 2021, it operated approximately 1000 theatres and 10,700 screens in the United States and internationally. The company was founded in 1920 and is headquartered in Leawood, Kansas.",
                    Industry = "Entertainment"
                }
            };
            var request = new Mock<HttpRequest>();
            request.Setup(_ => _.Query["Symbol"])
            .Returns("AMC");
            var response = function.Run(request.Object, null).Result;
            var data = JsonConvert.DeserializeObject<StockData>(response.Content.ReadAsStringAsync().Result);


            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expectedData.High, data.High);
            Assert.AreEqual(expectedData.Low, data.Low);
            Assert.AreEqual(expectedData.Open, data.Open);
            Assert.AreEqual(expectedData.Price, data.Price);
            Assert.AreEqual(expectedData.Symbol, data.Symbol);
            Assert.AreEqual(expectedData.High, data.High);
            Assert.AreEqual(expectedData.Profile.Name, data.Profile.Name);
            Assert.AreEqual(expectedData.Profile.Industry, data.Profile.Industry);
            Assert.AreEqual(expectedData.Profile.Description, data.Profile.Description);
        }
    }
}
