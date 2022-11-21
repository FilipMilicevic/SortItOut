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

        
    }
}