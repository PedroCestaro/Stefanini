using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Aggregates;

namespace Stefanini.Data.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1").IsRequired();

            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(300).IsRequired();

            builder.Property(x => x.Cpf).HasColumnType("varchar").HasMaxLength(11).IsRequired();

            builder.Property(x => x.Age).IsRequired();

            builder.Property(x => x.CityId).IsRequired();

            builder.HasOne(x => x.City)
                   .WithMany(c => c.Persons)
                   .HasForeignKey(x => x.CityId);

            builder.ToTable("Persons");
        }
    }
}
