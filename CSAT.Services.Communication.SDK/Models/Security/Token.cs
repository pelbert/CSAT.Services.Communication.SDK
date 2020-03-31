using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CSAT.Services.Communication.SDK.Models.Security
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string Value { get; set; }

        [JsonProperty("token_type")]
        public string Type { get; set; }

        [JsonProperty("expires_in")]
        public int Expires { get; set; }
    }
}
