using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CSAT.Services.Communication.SDK;

namespace CSAT.Services.Communication.SDK.Client
{
    public class BaseClient : IBaseClient
    {
        private string baseUrl;

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0."</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        public BaseClient(
            string baseUrl,
             //IAuthenticationProvider authenticationProvider,
             string token,
             string LapTopBarcodeID,
             IHttpProvider httpProvider = null)
        {
            this.BaseUrl = baseUrl;
            this.Token = token;
            this._LapTopBarcodeID = LapTopBarcodeID; 
            this.HttpProvider = httpProvider ?? new HttpProvider(new Serializer());
        }
        public  string Token { get; set; }
        public string _LapTopBarcodeID { get; set; }
        public CSAT.Services.Communication.SDK.Models.QueryContext Context { get; set; }
        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating requests.
        /// </summary>
        //public IAuthenticationProvider AuthenticationProvider { get; set; }

        /// <summary>
        /// Gets or sets the base URL for requests of the client.
        /// </summary>
        public string BaseUrl
        {
            get { return this.baseUrl; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.InvalidRequest,
                            Message = ErrorConstants.Messages.BaseUrlMissing,
                        });
                }

                this.baseUrl = value.TrimEnd('/');
            }
        }
        protected virtual AuthorizationHeader BuildAuthorizationHeader(string token)
        {
            var header = AuthorizationHeader.Create("Authorization", $"Bearer {token}");
            return header;
        }
        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; private set; }
    }
}