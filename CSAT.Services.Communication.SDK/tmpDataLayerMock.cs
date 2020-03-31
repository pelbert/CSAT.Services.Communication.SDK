using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using CSAT.Services.Communication.SDK.Interfaces;

namespace  CSAT.Services.Communication.SDK
{
    public class TmpDataLayerMock : IDataLayer
    {

        public async Task<Models.CommTypeListResults> GetCommTypeList(string LapTopBarCode, int filterGroupId, string filterName, int offSet, int pageSize)
        {
            //READ FROM MOCK DATA FILES FOR TESTING FROM SDK TO BYPASS DATA ACCESS. 
            return null;
        }
 

      

    }
}
