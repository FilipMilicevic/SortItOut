using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SortItOut.DataAccess.Csc.Models;
using SortItOut.Models.Response;

namespace SortItOut.DataAccess.Csc
{
    public class SortItOutDataAccess : ISortItOutDataAccess
    {
        private readonly SortItOutContext _cscDb;


        public SortItOutDataAccess(IConfiguration configuration)
        {
            DbContextOptionsBuilder<SortItOutContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SIT-DB"]);

            _cscDb = new SortItOutContext(optionsBuilder.Options);
        }

        public async Task<ValueResult?> GetTrueValue(bool value)
        {
            return new ValueResult{ IsSuccess = true, Description = "tekst"};
        }

        public async Task<bool> AuthenticateMe(string name, string surname, string password)
        {
            return await _cscDb.Account.AnyAsync( g => g.PasswordHash == password && g.Name == name && g.Surname == surname)
                ;
        }

        public async Task<bool> AddNewUser(string surname, string name , string password, byte AccountTypeId)
        {
            var user = new Account()
            {
                Surname = surname,
                Name = name,
                PasswordHash = password,
                AccountTypeId = AccountTypeId
            };


            try
            {
                _cscDb.Account.Add(user);
                await _cscDb.SaveChangesAsync();


                return true;
            }
            catch (Exception)
            { 
                throw;
            }
            
        }
    }
}