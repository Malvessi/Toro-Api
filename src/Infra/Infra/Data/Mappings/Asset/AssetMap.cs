using Domain.Model;
using Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings.WeatherForecast
{
    public class AssetMap : EntityTypeConfiguration<Asset>
    {
        public override void Map(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Asset");
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Transactions);
            builder.Property(p => p.Name);
            builder.Property(p => p.Value);
        }
    }
}