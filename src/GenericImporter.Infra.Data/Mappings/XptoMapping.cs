using GenericImporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericImporter.Infra.Data.Mappings
{
    public class XptoMapping : IEntityTypeConfiguration<Xpto>
    {
        public void Configure(EntityTypeBuilder<Xpto> builder)
        {
            builder.ToTable("Xpto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .IsRequired();
        }
    }
}
