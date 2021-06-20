using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class IPShopDBContextFactory : IDesignTimeDbContextFactory<IPShopDBContext>
    {
        public IPShopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var ConnectionString = Configuration.GetConnectionString("CamIPStore");
            var optionBuilder = new DbContextOptionsBuilder<IPShopDBContext>();
            optionBuilder.UseSqlServer(ConnectionString);
            return new IPShopDBContext(optionBuilder.Options);
        }
    }
}
