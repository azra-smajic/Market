using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Market.Infrastructure.Database
{
    public class DatabaseContextSeedCommon
    {
        public static void CreateFunctions(DatabaseFacade db)
        {
            InjectFunction(db, "0001_fn_markets_get_by_id.sql");
            InjectFunction(db, "0002_fn_markets_get_by_parameters.sql");
        }

        private static void InjectFunction(DatabaseFacade db, string fileName)
        {
            var assembly = typeof(DatabaseContext).Assembly;

            var assemblyName = assembly.FullName[..assembly.FullName.IndexOf(',')];

            // for debug
            //var names = assembly.GetManifestResourceNames();

            using var resource = assembly.GetManifestResourceStream($"{assemblyName}.Functions.{fileName}");
            using var streamReader = new StreamReader(resource);
            var sqlQuery = streamReader.ReadToEnd();
            db.ExecuteSqlRaw(sqlQuery);
        }
    }
}