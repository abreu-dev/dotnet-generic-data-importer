using GenericImporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericImporter.Infra.Data.Mappings
{
    public class ImportLayoutMapping : IEntityTypeConfiguration<ImportLayout>
    {
        public void Configure(EntityTypeBuilder<ImportLayout> builder)
        {
            builder.ToTable("ImportLayout");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Separator)
                .HasColumnName("Separator")
                .IsRequired();

            builder.Property(x => x.ImportLayoutEntity)
                .HasColumnName("ImportLayoutEntity")
                .IsRequired();

            builder.HasMany(x => x.ImportLayoutColumns)
                .WithOne(x => x.ImportLayout)
                .IsRequired();
        }
    }
}
