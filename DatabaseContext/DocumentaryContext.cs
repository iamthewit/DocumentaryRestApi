using DocumentaryRestApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DocumentaryRestApi.DatabaseContext;

public class DocumentaryContext : DbContext
{
    public DocumentaryContext(DbContextOptions<DocumentaryContext> options) : base(options) { }
    
    public DbSet<Documentary> Documentaries { get; set; }
    public DbSet<Director> Directors { get; set; } = null!;
}