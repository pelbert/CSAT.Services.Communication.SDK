using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSAT.Services.Communication.SDK.Models;

namespace CSAT.Services.Communication.SDK.Interfaces
{
    public interface IDataLayer
    {
        //Task<CommTypeListResults> GetCommTypeList(string[] LapTopBarCode, int filterGroupId, string filterName, int offSet, int pageSize);
        Task<CommTypeListResults> GetCommTypeList(string LapTopBarCode, int filterGroupId, string filterName, int offSet, int pageSize);

    }
}
