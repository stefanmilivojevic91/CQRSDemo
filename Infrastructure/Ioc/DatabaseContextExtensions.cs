using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ioc
{
    public static class DatabaseContextExtensions
    {
        public static void MigrateDatabase(this DatabaseContext context)
        {
            context.Database.Migrate();
        }
    }
}
