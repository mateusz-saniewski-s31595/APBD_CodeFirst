using APBD_CodeFirst.DTOs;

namespace APBD_CodeFirst.Services;

public interface IPCService
{
    Task<IEnumerable<GetPCDto>> GetAllPCs();
    Task<GetPCWithComponentsDto> GetPCWithComponents(int id);
    Task<GetPCDto> PostPC(PostPCDto dto);
    Task PutPC(int id, PutPCDto dto);
    Task DeletePC(int id);
}