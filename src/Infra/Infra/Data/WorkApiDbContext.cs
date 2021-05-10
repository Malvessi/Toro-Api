using Domain.Model;
using Infra.Data.Extensions;
using Infra.Data.Mappings.WeatherForecast;
using Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data
{
    public class WorkApiDbContext : DbContext
    {
        public WorkApiDbContext()
        {

        }

        public WorkApiDbContext(DbContextOptions<WorkApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new UserMap());
            modelBuilder.AddConfiguration(new UserAssetMap());
            modelBuilder.AddConfiguration(new AssetMap());
        }
    }
}
