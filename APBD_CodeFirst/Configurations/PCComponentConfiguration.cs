using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_CodeFirst.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> e)
    {
        e.HasKey(p => new { p.PCId, p.ComponentCode });
        e.Property(p => p.PCId)
            .IsRequired();
        e.Property(p => p.ComponentCode)
            .HasColumnType("char(10)")
            .IsRequired();
        e.Property(p => p.Amount)
            .IsRequired();
            
        e.HasOne(p => p.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(p => p.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        e.HasOne(p => p.Component)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(p => p.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);

        e.ToTable("PCComponents");
        
        e.HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM0000001", Amount = 2 },
            new PCComponent { PCId = 2, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM0000001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "GPU0000001", Amount = 2 }
        );
    }
    
}