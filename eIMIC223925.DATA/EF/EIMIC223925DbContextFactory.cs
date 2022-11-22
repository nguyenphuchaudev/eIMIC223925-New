using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eIMIC223925.DATA.EF
{
    public class EIMIC223925DbContextFactory : IDesignTimeDbContextFactory<EIMIC223925DbContext>
    {
        public EIMIC223925DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eIMIC223925Db");
            var optionsBuilder = new DbContextOptionsBuilder<EIMIC223925DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EIMIC223925DbContext(optionsBuilder.Options);
        }
    }
}
