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
            InjectFunction(db, "0003_fn_users_get_by_username.sql");
            InjectFunction(db, "0004_fn_person_get_by_username.sql");
            InjectFunction(db, "0005_fn_userroles_get_by_username.sql");
            InjectFunction(db, "0006_fn_productcategories_get_by_id.sql");
            InjectFunction(db, "0007_fn_productcategories_get_by_parameters.sql");
            InjectFunction(db, "0008_fn_products_get_by_id.sql");
            InjectFunction(db, "0009_fn_productimages_get_by_productid.sql");
            InjectFunction(db, "0010_fn_products_get_by_parameters.sql");
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