using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_CodeFirst.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> e)
    {
        e.HasKey(p => p.Id);
        e.Property(p => p.Id)
            .IsRequired();
        e.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();
        e.Property(p => p.Weight)
            .HasColumnType("float(5)")
            .IsRequired();
        e.Property(p => p.Warranty)
            .IsRequired();
        e.Property(p => p.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();
        e.Property(p => p.Stock)
            .IsRequired();
            
        e.ToTable("PCs");
        
        e.HasData(
            new PC
            {
                Id = 1, Name = "Gaming Beast X", Weight = 12.5f,
                Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5
            },
            new PC
            {
                Id = 2, Name = "Office Mini Pro", Weight = 4.2f,
                Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12
            },
            new PC
            {
                Id = 3, Name = "Workstation Ultra", Weight = 18.0f,
                Warranty = 48, CreatedAt = new DateTime(2026, 3, 1, 8, 0, 0), Stock = 3
            }
        );
    }
    
}