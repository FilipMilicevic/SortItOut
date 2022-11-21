using SortItOut.Core.Interface;
using SortItOut.Models.Response;
using SortItOut.DataAccess;

namespace SortItOut.Core.Service
{
    public class SortItOutService : ISortItOutService
    {
        private readonly ISortItOutDataAccess _dataAccess;

        public SortItOutService(ISortItOutDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


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
