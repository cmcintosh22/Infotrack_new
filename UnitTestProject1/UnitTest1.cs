using Infotrack.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Infotrack.Services;

using Moq;
using Infotrack;
using Microsoft.Extensions.Logging;
using Infotrack.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Infotrack.UnitTests
{
    [TestClass]
    public class ScraperTests
    {
        private Mock<IData> _data;

        private Mock<ScraperContext> _sc;
        private Mock<ScraperController> scraperControllerM_;
        Mock<ScraperController> scraperControllerM = new Mock<ScraperController>();
        
        private string yx;
        private string y;
        Services.Data _datatest = new Services.Data();

        private readonly Mock<IData> _mockIdata = new Mock<IData>();
        private readonly Mock<ScraperContext> _mockSc = new Mock<ScraperContext>();
        private readonly ScraperController _scc;
        private ScraperController _scc2;




        static readonly HttpClient client = new HttpClient();
        const string url = "https://localhost:44304/";

        [TestInitialize]
        public void setUp()
        {
            _data = new Mock<IData>();
            _sc = new Mock<ScraperContext>();
            // _scc = new ScraperController(_data.Object, _sc.Object);
            //_scc2 = new ScraperController(_mockIdata.Object, _mockSc.Object);

        }

        

        [TestMethod]
        public void Data_GoogleUrl_Unchanged()
        {

            string originalString = "https://www.google.co.uk/search?num=100&q=land+registry+search";

            
            
            Assert.AreEqual(_datatest.GoogleURL(), originalString);

        }

        [TestMethod]
        public void Data_InfotrackURL_Unchanged()
        {
            string originalString = "www.infotrack.co.uk/services/conveyancing/land-registry-searches/";

            Assert.AreEqual(_datatest.InfotrackURL(), originalString);
        }

        [TestMethod]
        public void Data_GoogleResultSplit_Unchanged()
        {
            string originalString = "h3 class";

            
            Assert.AreEqual(_datatest.GoogleResultSplit(), originalString);

        }

        [TestMethod]
        public void Data_PaidAd_Unchanged()
        {
            string originalString = "aria-level=\"3\"";

            Assert.AreEqual(_datatest.PaidAdSplit(), originalString);

        }

        


    }
}
