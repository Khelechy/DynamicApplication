using DynamicApplication.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Core.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfigurationSection configuration)
        {
            var databaseName = configuration["DatabaseName"];
            var connectionString = configuration["ConnectionString"];

            services.AddDbContext<AppDbContext>(options =>
            options.UseCosmos(
                connectionString,
                databaseName
            ));
        }
    }
}
