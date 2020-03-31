using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTDNA.Services.GeneticInfo.SDK.TestClient.Models
{
    public class ProfileFull
    {
        public string Kitnum { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string profileImageUrl { get; set; }
        public string sex { get; set; }
        public string[] surnames { get; set; }
        public string paternalAncestor { get; set; }
        public string maternalAncestor { get; set; }
        public string External_Story { get; set; }
        public int ydnaTestTaken { get; set; }
        public string mtdnaTestTaken { get; set; }
        public string familyFinderTestTaken { get; set; }
    }
}
