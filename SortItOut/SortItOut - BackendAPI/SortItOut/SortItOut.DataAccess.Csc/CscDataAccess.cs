using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortItOut.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;

namespace SortItOut.DataAccess.Csc
{
    public class CscDataAccess : ISortItOutDataAccess
    {
        private readonly ITS_CSCContext _cscDb;


		public CscDataAccess(IConfiguration configuration)
		{
			DbContextOptionsBuilder<ITS_CSCContext> optionsBuilder = new();
			optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SIT-DB"]);

			_cscDb = new ITS_CSCContext(optionsBuilder.Options);
		}

		public async Task<ValueResult> GetTrueValue(bool value);
    }
}
