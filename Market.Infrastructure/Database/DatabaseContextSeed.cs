using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database
{
    public static class DatabaseContextSeedDevelopment
    {
        public static void Initialize(DatabaseContext ctx)
        {
            if (ctx.Database.GetAppliedMigrations()?.Count() == 0)
                ctx.Database.Migrate();

            // ## Stored procedures, views, functions
            // ------------------------------------------------------------------------------------------------------------------------

            DatabaseContextSeedCommon.CreateFunctions(ctx.Database);
        }
    }
}