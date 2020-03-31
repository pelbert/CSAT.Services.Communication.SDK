using System;
using CSAT.Services.Communication.SDK.Client;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using CSAT.Services.Communication.SDK.Models;
using System.Threading.Tasks;

namespace testclientconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            CreateNewClient().Wait();
        }
        private static CommunicationManagerClient CreateBaseClient(string url, string token, string LapTopBarcodeID)
        {
            return new CommunicationManagerClient(url, token, LapTopBarcodeID);
        }


        private async static Task CreateNewClient()
        {


            Console.WriteLine("Please enter the base URI of the CSAT Communication service to test (http://localhost:32769/):");
            var url = Console.ReadLine();
            url = string.IsNullOrEmpty(url) ? "http://localhost:32769" : url;
            Console.WriteLine("Please enter LaptopScanID (8uyuiweyri8sdf):");
            var LaptopScanID = Console.ReadLine();
            LaptopScanID = string.IsNullOrEmpty(LaptopScanID) ? "8uyuiweyri8sdf" : LaptopScanID;
            Console.WriteLine("Please Test Filter (Null):");
            var filterTest = Console.ReadLine();
            filterTest = string.IsNullOrEmpty(filterTest) ? null : filterTest;
            Console.WriteLine("Please Name Filter (Null):");
            var filterName = Console.ReadLine();
            filterName = string.IsNullOrEmpty(filterName) ? null : filterName;
            Console.WriteLine("Please Name Filter(Relationship) GroupID (0):");
            var filterGroupId = Console.ReadLine();
            filterGroupId = string.IsNullOrEmpty(filterGroupId) ? "0" : filterGroupId;
            Console.WriteLine("Please offset (0):");
            var offset = Console.ReadLine();
            offset = string.IsNullOrEmpty(offset) ? "0" : offset;
            Console.WriteLine("Please page size (0):");
            var pagesize = Console.ReadLine();
            pagesize = string.IsNullOrEmpty(pagesize) ? "0" : pagesize;
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.XbPfbIHMI6arZ3Y922BhjWgQzWXcXNrz0ogtVhfEd2o";

            //ProfileClient ProfileClient = new ProfileClient(url, new QueryContext { KitNumber = "9" });
            CommunicationManagerClient comClient = new CommunicationManagerClient(url, token, LaptopScanID);
            
            var exitloop = false;
            do
            {
                Console.WriteLine("Which Method do you want to run:");
                Console.WriteLine(" 0 = List communication stage");
                Console.WriteLine(" q = Quit ");
                var key = Console.ReadLine();
                switch (key)
                {
                    case "0":
                        //  GetBasic();
                        string LapTopScanID = "sd4345stgg";

                        //fake data to test
                        var callResults = await comClient.GetCommTypeList(LapTopScanID, 1,filterName,2,2);


                        var basicJson = JsonConvert.SerializeObject(callResults);
                        Console.WriteLine("Return Count: " + callResults.totalMatches) ;
                        Console.WriteLine("Return Type: " + callResults.GetType());
                        Console.WriteLine("Return Matches: " + callResults.Matches);
                        Console.WriteLine("JSON: ");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(basicJson);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("END JSON: ");

                        break;
                   
                    case "r":
                        CreateNewClient();
                        break;
                    case "q":
                        exitloop = true;
                        break;
                }
            } while (!exitloop);

        }




    }
}


