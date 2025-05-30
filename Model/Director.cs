using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocumentaryRestApi.Model;

public class Director
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [JsonIgnore]
    public ICollection<Documentary> Documentaries { get; set; } = new List<Documentary>();
}