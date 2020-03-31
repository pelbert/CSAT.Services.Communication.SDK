using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using CSAT.Services.Communication.SDK.Models;
using CSAT.Services.Communication.SDK.Models.Security;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CSAT.Services.Communication.SDK.Interfaces;
using CSAT.Services.Communication.SDK;

namespace CSAT.Services.Communication.SDK.Client
{

    public class CommunicationManagerClient : BaseClient, IDataLayer
    {
        private static string _apiRoute = "api/v1";
        private static string _apiCommunicationMessages = "api/v1/CSAT/CommunicationsMessages";
        private TmpDataLayerMock _dataLayerMock = new TmpDataLayerMock();
        private string baseUrl;

        private Token AuthToken { get; set; }


        public CommunicationManagerClient(
            string baseUrl,
            string token,
            string LapTopBarcodeID, 
            IHttpProvider httpProvider = null)
            : base(baseUrl, token, LapTopBarcodeID, httpProvider)
        {
            _LapTopBarcodeID = LapTopBarcodeID;
            this.HttpProvider = httpProvider ?? new HttpProvider(new Serializer());
            
        }
        private string Token { get; set; }
        /// <summary>
        /// Gets the <see cref="QueryContext"/> for authenticating requests.
        /// </summary>
        public QueryContext Context { get; set; }

        /// <summary>
        /// Gets or sets the base URL for requests of the client.
        /// </summary>
     

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; private set; }


       

        // END TEMPORARY FOR TESTING WHILE HARDCODED MOCK
        //public CommunicationManagerClient(string url, Token token)
        //{
        //    this.baseUrl = url;
        //    this.AuthToken = token; 
        //}
        public void CheckForExpectedParameterErrors(string LapTopBarCode, string BaseUrl)
        {
            if (LapTopBarCode == null)
            {
                throw new ArgumentException("LapTopBarCode Is Null");
            }
            if (LapTopBarCode == "")
            {
                throw new ArgumentException("LapTopBarCode Is Empty");
            }
            if (BaseUrl == null || BaseUrl == "")
            {
                throw new ArgumentException("Bad Service URL ");
            }
        }
        public void CheckForExpectedParameterErrors(string[] LapTopBarCodes, string BaseUrl)
        {
            if (LapTopBarCodes == null )
            {
                throw new ArgumentException("LapTopBarCodes Is Null");
            }
            if (LapTopBarCodes.Length==1 && LapTopBarCodes[0]=="")
            {
                throw new ArgumentException("LapTopBarCodes Is Empty");
            }
            if (BaseUrl == null || BaseUrl =="")
            {
                throw new ArgumentException("Bad Service URL ");
            }
        }

      
        //string filterTest, string filterName, int offset, int pageSize
        public async Task<CommTypeListResults> GetCommTypeList(string LapTopBarCodeID, int filterGroupId,  string filterName, int offset, int pagesize)
        {
            //Temp Fake Mock for SDK  ---------- DO NOT REMOVE
            CommTypeListResults retvalfffaked;
            retvalfffaked = await _dataLayerMock.GetCommTypeList(LapTopBarCodeID, filterGroupId, filterName, offset, pagesize);
            
            //END TEM FACE DATA

            //Full with string[] in result body 
            var headers = new Dictionary<string, string>();
            //headers.Add(tokenHeader.Type, tokenHeader.Token);
            headers.Add("LapTopBarcodeID", this._LapTopBarcodeID);
            headers.Add("filterGroupId", filterGroupId.ToString());
            headers.Add("filterName", filterName);
            string uri = string.Format("{0}/{1}/{2}/{3}/{4}", BaseUrl, _apiCommunicationMessages,  offset, pagesize,1);
            using (var client = new HttpClient())
            {
                try
                {
                    var ffList = new HttpRequestMessage
                    {
                        RequestUri = new Uri(uri),
                        Method = HttpMethod.Get
                    };

                    foreach (var header in headers ?? new Dictionary<string, string>())
                    {
                       // ffList.Headers.Add(header.Key, header.Value);
                    }// change as necessary
                    var ffListReturn = await client.SendAsync(ffList);
                    ffListReturn.EnsureSuccessStatusCode();
                    var responseBodyAsText = ffListReturn.Content.ReadAsStringAsync();
                    var retval = JsonConvert.DeserializeObject<CommTypeListResults>(ffListReturn.Content.ReadAsStringAsync().Result);
                    return retval;
                }
                catch (Exception e)
                {
                    throw new UriFormatException();
                }
            }

        }
        
     
    }
    }
