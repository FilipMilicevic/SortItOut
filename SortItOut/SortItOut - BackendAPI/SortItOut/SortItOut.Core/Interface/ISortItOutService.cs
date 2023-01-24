using SortItOut.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortItOut.Core.Interface
{
    public interface ISortItOutService
    {
        Task<ValueResult> GetTrueValue(bool value);

        Task<bool> AuthenticateMe(string username, string password);

        Task<bool> AddUser(string username, string password, byte AccountTypeId);
    }
}
