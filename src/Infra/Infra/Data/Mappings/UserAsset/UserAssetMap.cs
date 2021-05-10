using Domain.Model;
using Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings.WeatherForecast
{
    public class UserAssetMap : EntityTypeConfiguration<UserAsset>
    {
        public override void Map(EntityTypeBuilder<UserAsset> builder)
        {
            builder.ToTable("UserAsset");
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.IdUser);
            builder.Property(p => p.IdAsset);
            builder.Property(p => p.Quantity);

            builder.HasOne(u => u.User)
                .WithMany(p => p.UserAssets);

            builder.HasOne(a => a.Asset)
                .WithMany(p => p.UserAsset);
        }
    }
}