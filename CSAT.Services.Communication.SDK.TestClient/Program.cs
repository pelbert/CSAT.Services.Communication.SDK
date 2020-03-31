using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTDNA.Services.GeneticInfo.SDK;
using FTDNA.Services.GeneticInfo.SDK.Models;
//using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json;
using FTDNA.Services.GeneticInfo.SDK.Client;


namespace FTDNA.Services.GeneticInfo.SDK.TestClient
{
    class Program
    {

        // public static ProfileClient ProfileClient { get; set; }

         static void  Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
             CreateNewClient().Wait();
        }
        private static GeneticInfoClient CreateBaseClient(string url, string token, string ownerKit)
        {
            return new GeneticInfoClient(url, token, ownerKit);
        }
      

        private async static Task CreateNewClient()
        {
           

            Console.WriteLine("Please enter the base URI of the Family Tree Services site you would like to test (http://localhost:61115/):");
            var url = Console.ReadLine();
            url = string.IsNullOrEmpty(url) ? "http://localhost:61115" : url;
            Console.WriteLine("Please enter owner kit (9):");
            var ownerKit = Console.ReadLine();
            ownerKit = string.IsNullOrEmpty(ownerKit) ? "9" : ownerKit;
            Console.WriteLine("Please Test Filter (Null):");
            var filterTest = Console.ReadLine();
            filterTest = string.IsNullOrEmpty(filterTest) ? null : filterTest;
            Console.WriteLine("Please Name Filter (Null):");
            var filterName = Console.ReadLine();
            filterName = string.IsNullOrEmpty(filterName) ? null : filterName;
            Console.WriteLine("Please Name Filter(Relationship) GroupID (0):");
            var filterGroupId = Console.ReadLine();
            filterGroupId = string.IsNullOrEmpty(filterGroupId) ? "0" : filterGroupId;
            Console.WriteLine("Please enter relationship(NO LONGER USED) (Close):");
            var relationship = Console.ReadLine();
            relationship = string.IsNullOrEmpty(relationship) ? "Close" : relationship;
            Console.WriteLine("Please offset (0):");
            var offset = Console.ReadLine();
            offset  = string.IsNullOrEmpty(offset) ? "0" : offset;
            Console.WriteLine("Please page size (0):");
            var pagesize = Console.ReadLine();
            pagesize = string.IsNullOrEmpty(pagesize) ? "0" : pagesize;
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.XbPfbIHMI6arZ3Y922BhjWgQzWXcXNrz0ogtVhfEd2o";

            //ProfileClient ProfileClient = new ProfileClient(url, new QueryContext { KitNumber = "9" });
            GeneticInfoClient GeneticsClient = new GeneticInfoClient(url, token, ownerKit);

            var exitloop = false;
            do
            {
                Console.WriteLine("Which type of user would you like to run as:");
                Console.WriteLine(" 0 = Basic");
                Console.WriteLine(" 1 = Full Single Kit in Querystring");
                Console.WriteLine(" 2 = full String[] in body ");
                Console.WriteLine(" 3 = Ydna Match List ");
                Console.WriteLine(" 4 = MTDNA Match List ");
                Console.WriteLine(" 5 = FF Match List ");
                Console.WriteLine(" q = Quit ");
                var key = Console.ReadLine();
                switch (key)
                {  
                    case "0":
                            //  GetBasic();
                            string[] KitNumbers = { "843","BINGO" };
                        //var profileClient1 = new Client.ProfileClient();
                    
                            var basicResults = await GeneticsClient.GetBasicGeneticResult(KitNumbers);
                       

                            var basicJson = JsonConvert.SerializeObject(basicResults);
                            Console.WriteLine("Return Count: " + basicResults.Succeded.Count());
                            Console.WriteLine("Return Count: " + basicResults.NotFound.Count());
                            Console.WriteLine("Return Type: " + basicResults.GetType());
                            Console.WriteLine("JSON: ");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine(basicJson);
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("END JSON: ");
                      
                        break;
                    case "1":
                            //  GetFull with single querystring parameter
                            string KitNumber = "843";
                            //var profileClientFullSingle = new Client.ProfileClient();

                            var results = await GeneticsClient.GetFullGeneticResultSingle(KitNumber);

                            var jsonResults = JsonConvert.SerializeObject(results);
                            Console.WriteLine("Return Count Found: " + results.Succeded.Count());
                            Console.WriteLine("Return Count Not Found: " + results.NotFound.Count());
                            Console.WriteLine("Return Type: " + results.GetType());
                            Console.WriteLine("JSON: ");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine(jsonResults);
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("END JSON: ");
                            break;

                        case "2":
                        // GetFull with string array in body
                      //   string[] KitNumbersFull = {"10", "1071", "117354", "123", "123056", "128", "128777", "153785", "172519", "173700", "175133", "175759", "181082", "1820", "186684", "187621", "187697", "188517", "192589", "192590", "192591", "192592", "192593", "192594", "19282", "194823", "19736", "19886", "199610", "201712", "201716", "204063", "205586", "210446", "210813", "216215", "217725", "221741", "225812", "235497", "23996", "265404", "265406", "28768", "29659", "29736", "299807", "305610", "314967", "324323", "324910", "324912", "324914", "325428", "326690", "326870", "331535", "331558", "338", "348635", "353476", "355008", "355010", "362057", "362085", "362090", "362091", "362510", "362859", "363424", "370793", "370807", "370810", "374598", "388021", "388022", "388472", "388657", "398396", "4065", "418905", "422028", "430225", "436494", "439310", "442108", "465726", "4686", "471588", "474369", "489613", "49617", "49999", "503299", "519885", "522128", "528109", "547702", "549167", "569341", "61286", "645146", "645153", "645170", "6656", "729275", "735198", "76210", "843", "9", "9141", "9201", "94615", "B150079", "B1711", "B2849", "B40950", "B7003", "N114427", "N13911", "N21510", "N23339", "N89021","349854","N107435"};

                        //  string[] KitNumbersFull = { "49617","843", "108897", "113888", "100016", "100121", "128777", "269348", "9" ,"10"};
                        string[] KitNumbersFull = { "49617", "843", "108897", "113888", "100016" };
                        // var profileClientFull = new Client.ProfileClient();

                        var databack  = await GeneticsClient.GetFullGeneticResult(KitNumbersFull);

                            var retval = JsonConvert.SerializeObject(databack);
                           
                            Console.WriteLine("Return Count Success: " + databack.Succeded.Count());
                            Console.WriteLine("Return Count Not Found: " + databack.NotFound.Count());
                            Console.WriteLine("Return Type: " + databack.GetType());
                            Console.WriteLine("JSON: ");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine(retval);
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("END JSON: ");
                            break;
                    case "3":


                        var ydnaList = await GeneticsClient.GetYdnaMatchList(ownerKit, filterTest, filterName, Int32.Parse(offset), Int32.Parse(pagesize));

                        var returnYdnaList = JsonConvert.SerializeObject(ydnaList);

                        Console.WriteLine("Return YDNA List Count: " + ydnaList.totalMatches);
                        
                        Console.WriteLine("Return Type: " + ydnaList.GetType());
                        Console.WriteLine("JSON: ");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(returnYdnaList);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("END JSON: ");
                        break;
                    case "4":

                        
                        var mtdnaList = await GeneticsClient.GetMtdnaMatchList(ownerKit,filterTest,filterName,Int32.Parse(offset), Int32.Parse(pagesize));

                        var returnMtdnaList = JsonConvert.SerializeObject(mtdnaList);

                        Console.WriteLine("Return YDNA List Count: " + mtdnaList.totalMatches);

                        Console.WriteLine("Return Type: " + mtdnaList.GetType());
                        Console.WriteLine("JSON: ");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(returnMtdnaList);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("END JSON: ");
                        break;
                    case "5":


                        var ffList = await GeneticsClient.GetFFMatchList(ownerKit, Int32.Parse(filterGroupId.ToString()),  filterName, Int32.Parse(offset), Int32.Parse(pagesize));

                        var returnFFList = JsonConvert.SerializeObject(ffList);

                        Console.WriteLine("Return YDNA List Count: " + ffList.totalMatches);

                        Console.WriteLine("Return Type: " + ffList.GetType());
                        Console.WriteLine("JSON: ");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(returnFFList);
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
    

