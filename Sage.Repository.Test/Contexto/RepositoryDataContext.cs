using Microsoft.EntityFrameworkCore;
using Sage.Repository.Context;

namespace Sage.Repository.Test.Contexto
{
    public class RepositoryDataContext
    {
        public static SageContext InstanceContext()
        {
            DbContextOptions<SageContext> options;

            var builder = new DbContextOptionsBuilder<SageContext>();
            builder.UseInMemoryDatabase("InMemoryEmployeeTest");

            options = builder.Options;

            SageContext SageDataContex = new SageContext(options);

            SageDataContex.Database.EnsureDeleted();
            SageDataContex.Database.EnsureCreated();

            return SageDataContex;
        }
    }
}
