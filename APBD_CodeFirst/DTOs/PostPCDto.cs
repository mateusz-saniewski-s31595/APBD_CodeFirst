using System.ComponentModel.DataAnnotations;

namespace APBD_CodeFirst.DTOs;

public class PostPCDto
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public float Weight { get; set; }
    [Required]
    public int Warranty { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public int Stock { get; set; }
}