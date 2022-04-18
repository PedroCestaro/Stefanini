using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Aggregates;

namespace Stefanini.Data.Mappings
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1").IsRequired();

            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();

            builder.Property(x => x.Uf).HasColumnType("varchar").HasMaxLength(2).IsRequired();

            builder.ToTable("Cities");
        }
    }
}
