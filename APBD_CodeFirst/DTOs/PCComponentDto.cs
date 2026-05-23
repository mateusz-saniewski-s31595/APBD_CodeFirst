namespace APBD_CodeFirst.DTOs;

public class PCComponentDto
{
    public int Amount { get; set; }
    public ComponentDto Component { get; set; } = null!;
}