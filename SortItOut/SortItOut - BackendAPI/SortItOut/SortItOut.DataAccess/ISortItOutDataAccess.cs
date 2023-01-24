using SortItOut.Models.Response;

namespace SortItOut.DataAccess
{
    public interface ISortItOutDataAccess
    {
        Task<ValueResult> GetTrueValue(bool value);

        Task<bool> AuthenticateMe(string name, string surname, string password);

        Task<bool> AddNewUser(string surname, string name, string password, byte AccountTypeId);

    }
}