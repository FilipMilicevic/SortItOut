using SortItOut.Models.Response;

namespace SortItOut.DataAccess
{
    public interface ISortItOutDataAccess
    {
        Task<ValueResult> GetTrueValue(bool value);
    }
}