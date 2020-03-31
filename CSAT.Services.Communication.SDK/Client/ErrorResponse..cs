using System.Collections.Generic;
using System.Runtime.Serialization;
using CSAT.Services.Communication.SDK;
using Newtonsoft.Json;

namespace CSAT.Services.Communication.SDK.Client
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "error")]
        public Error Error { get; set; }

        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
