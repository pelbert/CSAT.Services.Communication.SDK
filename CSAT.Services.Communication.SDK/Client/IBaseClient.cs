using System;
using System.Collections.Generic;
using System.Text;

namespace CSAT.Services.Communication.SDK.Client
{
    public interface IBaseClient
    {
        ///// <summary>
        ///// Gets the <see cref="IAuthenticationProvider"/> for authenticating HTTP requests.
        ///// </summary>
        //IAuthenticationProvider AuthenticationProvider { get; }

        /// <summary>
        /// Gets the base URL for requests of the client.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        IHttpProvider HttpProvider { get; }
    }
}
