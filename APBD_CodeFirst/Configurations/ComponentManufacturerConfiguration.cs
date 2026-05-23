using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_CodeFirst.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> e)
    {
        e.HasKey(c => c.Id);
        e.Property(c => c.Id)
            .IsRequired();
        e.Property(c => c.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();
        e.Property(c => c.FullName)
            .HasMaxLength(300)
            .IsRequired();
        e.Property(c => c.FoundationDate)
            .HasColumnType("date")
            .IsRequired();
            
        e.ToTable("ComponentManufacturers");
        
        e.HasData(
            new ComponentManufacturer
            {
                Id = 1, Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2, Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateOnly(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3, Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateOnly(1994, 1, 1)
            }
        );
    }
    
}