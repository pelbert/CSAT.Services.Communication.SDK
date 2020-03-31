using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CSAT.Services.Communication.SDK.Models
{
    public class QueryContext
    {
        /// <summary>
        /// This represents the laptop entering on receiving into the system
        /// </summary>
        [DataMember]
        public string[] LapTopBarCodes { get; set; }
        [DataMember]
        public string LapTopBarCode { get; set; }

    }
}
