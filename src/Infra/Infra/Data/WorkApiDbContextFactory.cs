using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data
{
    public class WorkApiDbContextFactory : IDesignTimeDbContextFactory<WorkApiDbContext>
    {
        public WorkApiDbContextFactory()
        {

        }

        public WorkApiDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WorkApiDbContext>();
            return new WorkApiDbContext(optionBuilder.Options);
        }
    }
}