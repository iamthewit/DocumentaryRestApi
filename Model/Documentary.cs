using System.ComponentModel.DataAnnotations;

namespace DocumentaryRestApi.Model;

public class Documentary(string id, string title, string director)
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = id;
    
    [MaxLength(200)]
    public string Title {get; set;} = title;
    
    [MaxLength(200)]
    public string Director { get; set; } = director;
}