using System;
using System.Collections.Generic;
using System.Text;

namespace CSAT.Services.Communication.SDK.Client
{
    public class AuthorizationHeader
    {
        public AuthorizationHeader(string type, string token)
        {
            this.Type = type;
            this.Token = token;
        }

        public string Type { get; }
        public string Token { get; }

        public static AuthorizationHeader Create(string type, string token)
        {
            var obj = new AuthorizationHeader(type, token);
            return obj;
        }
    }
}
