using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Xunit;
using FTDNA.Services.GeneticInfo.SDK.Client;
using FTDNA.Services.GeneticInfo.SDK.Models;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestExecutor; 

 namespace testclientconsole
{
  
    [TestClass]
    public class ProfileUnitTests
    {
        IProfileClient userRepository = Substitute.For<IProfileClient>();
        private readonly ProfileClient _profileClient;

        private readonly IProfileClient __profileClientInterface;
        public string serviceURL = "http://localhost:53970/";

        public ProfileUnitTests()
        {
            __profileClientInterface = Substitute.For<IProfileClient>();


            _profileClient = new ProfileClient();
        }
        [TestMethod]
        [Fact]
        public void ThowsArgumentExceptionKitArray()
        {
            string[] KitNumbers = { "" };
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetBasicProfileResult(KitNumbers, serviceURL));
            string[] KitNumbersNull = null;
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetBasicProfileResult(KitNumbersNull, serviceURL));

        }


        [TestMethod]
        [Fact]
        public void ThowsArgumentExceptionKitSingle()
        {
            string KitNumber = "";
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetFullProfileResultSingle(KitNumber, serviceURL));
            string KitNumberNull = null;
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetFullProfileResultSingle(KitNumberNull, serviceURL));

        }
        [TestMethod]
        [Fact]
        public void ThowsArgumentExceptionMissingURLKitArray()
        {
            string[] KitNumbers = { "9" };
            serviceURL = "";
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetBasicProfileResult(KitNumbers, serviceURL));
            string serviceURL2 = null;
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetBasicProfileResult(KitNumbers, serviceURL2));

        }
        [TestMethod]
        [Fact]
        public void ThowsArgumentExceptionMissingURLSingleKit()
        {
            string KitNumber = "9";
            serviceURL = "";
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetFullProfileResultSingle(KitNumber, serviceURL));
            string serviceURL2 = null;
            Xunit.Assert.Throws<ArgumentException>(() => _profileClient.GetFullProfileResultSingle(KitNumber, serviceURL2));

        }



        // *************DO NOT REMOVE ***************************
        // COMMENTING OUT WHILE SDK IS MOCKING DATA FOR A LACK OF SERVICE
        // BELOW THREE TEST WILL ONLY WORK IF CLIENT MOCKING IS REMOVED. 
        // CURRENTLY WE WILL NOT ACTUALLY HIT THE SERVICE CALL BECAUSE WE QUERY 
        // A JSON TEXT FILE. 

        //[TestMethod]
        //[Fact]
        //public void BasicEndpointHttpTest()
        //{

        //    string[] KitNumbers = { "9" };
        //    serviceURL = "notavalidaddress";
        //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetBasicProfileResult(KitNumbers, serviceURL));

        //}
        //[TestMethod]
        //[Fact]
        //public void FullEndpointHttpTest()
        //{

        //    string[] KitNumbers = { "9" };
        //    serviceURL = "notavalidaddress";
        //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetFullProfileResult(KitNumbers, serviceURL));

        //}
        //[TestMethod]
        //[Fact]
        //public void FullEndpointSingleHttpTest()
        //{

        //    string KitNumbers = "9";
        //    serviceURL = "notavalidaddress";
        //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetFullProfileResultSingle(KitNumbers, serviceURL));

        //}
        // *************END OF SERVICE REQUEST TESTS  ***************************
        // *********** UNCOMMENT ABOVE THREE TEST WHEN CLIENT IS NOT FAKING SERVICE *************** 
        [TestMethod]
        [Fact]
        public void SingleBasicProfileTest()
        {

            string[] KitNumbers = { "9" };

            ReturnBasicProfile testdata = _profileClient.GetBasicProfileResult(KitNumbers, serviceURL);
            Xunit.Assert.Equal("Elliott Daniel Greenspan", testdata.Succeded.ElementAt(0).FullName);

        }
        [TestMethod]
        public void SingleNotFoundTest()
        {
            string[] KitNumbers = { "zzzz" };
            ReturnBasicProfile testdata = _profileClient.GetBasicProfileResult(KitNumbers, serviceURL);
            Xunit.Assert.Equal("zzzz", testdata.NotFound[0]);

        }
        [TestMethod]
        public void FullProfileTest()
        {
            string[] KitNumbers = { "9" };
            ReturnFullProfile testdata = _profileClient.GetFullProfileResult(KitNumbers, serviceURL);
            Xunit.Assert.Equal("mtFull Sequence", testdata.Succeded.ElementAt(0).MtdnaTestTaken);

        }
        [TestMethod]
        public void SucceddedAndNotFoundCountExpected()
        {
            string[] KitNumbersfull = { "9", "3", "5", "217725" };
            ReturnFullProfile testdata = _profileClient.GetFullProfileResult(KitNumbersfull, serviceURL);
            Xunit.Assert.Equal(2, testdata.Succeded.Count());
            Xunit.Assert.Equal(2, testdata.NotFound.Count());
        }

        [Fact]
        [TestMethod]
        public void PassingTest()
        {
            Xunit.Assert.Equal(4, 4);
        }

    }

}
