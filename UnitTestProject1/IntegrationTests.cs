using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Infotrack.UnitTests
{
    [TestClass]
    class IntegrationTests
    {

        static readonly HttpClient client = new HttpClient();
        const string url = "https://localhost:44304/";


        [TestMethod]
        [Test]
        public async Task Controller_Test()
        {

            //var mockWeatherForecaster = new Mock<IData>();
            //var test = mockWeatherForecaster.Setup(w => w.GoogleURL()).Returns(null).ToString;
            //test.retur
            //Assert.AreEqual(test, "https://www.google.co.uk/search?num=100&q=land+registry+search");

            HttpResponseMessage response = await client.GetAsync(url + "Scraper/Calc");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);



        }


    }
}
