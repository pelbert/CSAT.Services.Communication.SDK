using System;
using System.Collections.Generic;
using System.Text;

namespace CSAT.Services.Communication.SDK.Models
{
    public class CommTypeListResults
    {
        public int totalMatches { get; set; }
        public IEnumerable<CommTypeList> Matches { get; set; }
    }
}
