using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_CodeFirst.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> e)
    {
        e.HasKey(c => c.Id);
        e.Property(c => c.Id)
            .IsRequired();
        e.Property(c => c.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();
        e.Property(c => c.Name)
            .HasMaxLength(150)
            .IsRequired();

        e.ToTable("ComponentTypes");
        
        e.HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );
    }
    
}