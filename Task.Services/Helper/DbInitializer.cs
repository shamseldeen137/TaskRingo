using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Services.Helper
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaskDbContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Departments.Any())
                {
                    return; // DB has been seeded
                }

                var sqlFilePath = Path.Combine( "Data", "seed-data.sql");

                var sql = File.ReadAllText(sqlFilePath);

                context.Database.ExecuteSqlRaw(sql);
            }
        }
    }
}
