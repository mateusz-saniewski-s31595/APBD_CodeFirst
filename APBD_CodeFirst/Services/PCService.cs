using APBD_CodeFirst.Data;
using APBD_CodeFirst.DTOs;
using APBD_CodeFirst.Exceptions;
using APBD_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CodeFirst.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _dbContext;
    
    public PCService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<IEnumerable<GetPCDto>> GetAllPCs()
    {
        var PCs = await _dbContext.PCs.Select(p => new GetPCDto()
        {
            Id = p.Id,
            Name = p.Name,
            Weight = p.Weight,
            Warranty = p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock
        }).ToListAsync();

        return PCs;
    }
    
    
    public async Task<GetPCWithComponentsDto> GetPCWithComponents(int id)
    {
        var pc = await _dbContext.PCs
            .Include(p => p.PCComponents)
            .ThenInclude(pcc => pcc.Component)
            .ThenInclude(c => c.ComponentManufacturer)
            .Include(p => p.PCComponents)
            .ThenInclude(pcc => pcc.Component)
            .ThenInclude(c => c.ComponentType)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
            throw new NotFoundException($"PC with id {id} was not found.");

        return new GetPCWithComponentsDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PCComponents.Select(pcc => new PCComponentDto
            {
                Amount = pcc.Amount,
                Component = new ComponentDto
                {
                    Code = pcc.Component.Code,
                    Name = pcc.Component.Name,
                    Description = pcc.Component.Description,
                    Manufacturer = new ComponentManufacturerDto
                    {
                        Id = pcc.Component.ComponentManufacturer.Id,
                        Abbreviation = pcc.Component.ComponentManufacturer.Abbreviation,
                        FullName = pcc.Component.ComponentManufacturer.FullName,
                        FoundationDate = pcc.Component.ComponentManufacturer.FoundationDate
                    },
                    Type = new ComponentTypeDto
                    {
                        Id = pcc.Component.ComponentType.Id,
                        Abbreviation = pcc.Component.ComponentType.Abbreviation,
                        Name = pcc.Component.ComponentType.Name
                    }
                }
            }).ToList()
        };
    }
    

    public async Task<GetPCDto> PostPC(PostPCDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };
        
        _dbContext.PCs.Add(pc);
        
        await _dbContext.SaveChangesAsync();
        
        return new GetPCDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    
    public async Task PutPC(int id, PutPCDto dto)
    {
        var pc = await _dbContext.PCs.FindAsync(id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _dbContext.SaveChangesAsync();
    }

    
    public async Task DeletePC(int Id)
    {
        var PC = await _dbContext.PCs.FindAsync(Id);
        if (PC == null)
        {
            throw new NotFoundException();
        }
        _dbContext.PCs.Remove(PC);
        
        await _dbContext.SaveChangesAsync();
    }
    
}