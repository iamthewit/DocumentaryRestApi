using DocumentaryRestApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DocumentaryRestApi.DatabaseContext;

public class DocumentaryContext : DbContext
{
    public DbSet<Documentary> Documentaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Filename=./documentaries.db");
        }
    }
}