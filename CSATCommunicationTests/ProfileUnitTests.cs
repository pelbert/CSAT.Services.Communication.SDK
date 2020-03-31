using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Xunit;
using CSAT.Services.Communication.SDK.Client;
using CSAT.Services.Communication.SDK.Models;
using System.Linq;
 
namespace ProfileTests
{



    public class CommunicationUnitTests
    {

        //    public void ThowsArgumentExceptionKitArray()
        //    {
        //        string[] KitNumbers = { "" };

        //        Xunit.Assert.ThrowsAsync<ArgumentException>(() => _csatClient.GetBasicGeneticResult());
        //        string[] KitNumbersNull = null;
        //        Xunit.Assert.ThrowsAsync<ArgumentException>(() => _csatClient.GetBasicGeneticResult(KitNumbersNull));


        //    }



        //    [Fact]
        //    public void ThowsArgumentExceptionKitSingle()
        //    {
        //        string KitNumber = "";

        //        Xunit.Assert.ThrowsAsync<ArgumentException>(() => _csatClient.GetFullGeneticResultSingle(KitNumber));
        //        string  KitNumberNull = null;
        //        Xunit.Assert.ThrowsAsync<ArgumentException>(() => _csatClient.GetFullGeneticResultSingle(KitNumberNull));

        //    }




        //    // *************DO NOT REMOVE ***************************
        //    // COMMENTING OUT WHILE SDK IS MOCKING DATA FOR A LACK OF SERVICE
        //    // BELOW THREE TEST WILL ONLY WORK IF CLIENT MOCKING IS REMOVED. 
        //    // CURRENTLY WE WILL NOT ACTUALLY HIT THE SERVICE CALL BECAUSE WE QUERY 
        //    // A JSON TEXT FILE. 

        //    //[TestMethod]
        //    //[Fact]
        //    //public void BasicEndpointHttpTest()
        //    //{

        //    //    string[] KitNumbers = { "9" };
        //    //    serviceURL = "notavalidaddress";
        //    //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetBasicProfileResult(KitNumbers, serviceURL));

        //    //}
        //    //[TestMethod]
        //    //[Fact]
        //    //public void FullEndpointHttpTest()
        //    //{

        //    //    string[] KitNumbers = { "9" };
        //    //    serviceURL = "notavalidaddress";
        //    //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetFullProfileResult(KitNumbers, serviceURL));

        //    //}
        //    //[TestMethod]
        //    //[Fact]
        //    //public void FullEndpointSingleHttpTest()
        //    //{

        //    //    string KitNumbers = "9";
        //    //    serviceURL = "notavalidaddress";
        //    //    Xunit.Assert.Throws<UriFormatException>(() => _profileClient.GetFullProfileResultSingle(KitNumbers, serviceURL));

        //    //}
        //    // *************END OF SERVICE REQUEST TESTS  ***************************
        //    // *********** UNCOMMENT ABOVE THREE TEST WHEN CLIENT IS NOT FAKING SERVICE *************** 

        //    [Fact]
        //    public  async void  SingleBasicProfileTest()
        //    {

        //        string[] KitNumbers = { "9" };


        //         ReturnBasicGenetics testdata =await _geneticsClient.GetBasicGeneticResult(KitNumbers);

        //       // Xunit.Assert.Equal("Elliott Daniel Greenspan", testdata.Succeded.ElementAt(0).FullName); 

        //    }

        //    [Fact]
        //    public async void SingleNotFoundTest()
        //    {
        //        string[] KitNumbers = { "zzzz" };

        //        ReturnBasicGenetics testdata = await _geneticsClient.GetBasicGeneticResult(KitNumbers);

        //        Xunit.Assert.Equal("zzzz", testdata.NotFound[0]);

        //    }

        //    [Fact]
        //    public async void FullProfileTest()
        //    {
        //        string[] KitNumbers = { "9" };

        //        ReturnGeneticInfoFull testdata = await _geneticsClient.GetFullGeneticResult(KitNumbers);

        //    //    Xunit.Assert.Equal("mtFull Sequence", testdata.Succeded.ElementAt(0).MtdnaTestTaken);

        //    }

        //    [Fact]
        //    public async void SucceddedAndNotFoundCountExpected()
        //    {

        //        string[] KitNumbersfull = { "9", "3", "5", "217725" };
        //        ReturnGeneticInfoFull testdata = await _geneticsClient.GetFullGeneticResult(KitNumbersfull);

        //        Xunit.Assert.Equal(2, testdata.Succeded.Count());
        //        Xunit.Assert.Equal(2, testdata.NotFound.Count());
        //    }

        //    [Fact]

        //    public void PassingTest()
        //    {
        //        Xunit.Assert.Equal(4,4);
        //    }

        //}
    }
}
