using SortItOut.Core.Interface;
using SortItOut.DataAccess;
using SortItOut.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SortItOut.Core.Service
{
    public class SortItOutService : ISortItOutService
    {
        //private readonly ISortItOutDataAccess _dataAccess;

        //public SortItOutService(ISortItOutService dataAccess)
        //{
        //    _dataAccess = dataAccess;
        //}


        public async Task<ValueResult> GetTrueValue(bool value)
        {
            if (value == true)
            {
                var result = new ValueResult()
                {
                    IsSuccess = true,
                    Description = "It is true"
                };
                return result;
            }
            else
            {
                var result = new ValueResult()
                {
                    IsSuccess = false,
                    Description = "It is false"
                };
                return result;
            }
        }
    }
}
