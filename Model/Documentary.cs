using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DocumentaryRestApi.Model;

public class Documentary
{
    [Key]
    [Required]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string Title {get; set;} = string.Empty;
    
    [Required]
    [MaxLength(36)]
    public string DirectorId { get; set; } = string.Empty;
    
    [ForeignKey("DirectorId")]
    public Director? Director { get; set; }
}