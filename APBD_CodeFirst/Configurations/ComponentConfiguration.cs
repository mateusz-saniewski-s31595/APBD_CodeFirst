using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_CodeFirst.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> e)
    {
        e.HasKey(c => c.Code);
        e.Property(c => c.Code)
            .HasColumnType("char(10)")
            .IsRequired();
        e.Property(c => c.Name)
            .HasMaxLength(300)
            .IsRequired();
        e.Property(c => c.Description)
            .HasColumnType("nvarchar(max)")
            .IsRequired();
        e.Property(c => c.ComponentManufacturersId)
            .IsRequired();
        e.Property(c => c.ComponentTypesId)
            .IsRequired();
            
        e.HasOne(c =>c.ComponentManufacturer)
            .WithMany(c => c.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Cascade);
        e.HasOne(c => c.ComponentType)
            .WithMany(c => c.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Cascade);
            
        e.ToTable("Components");
        
        e.HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "8-core gaming processor",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080 Super",
                Description = "High-end gaming graphics card",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance DDR5 16GB",
                Description = "DDR5 RAM module 16GB",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        );
    }
    
}