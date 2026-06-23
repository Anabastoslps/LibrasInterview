using LibrasInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrasInterview.Infrastructure.Persistence;

public class LibrasInterviewDbContext : DbContext
{
    public LibrasInterviewDbContext(DbContextOptions<LibrasInterviewDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Entrevista> Entrevistas => Set<Entrevista>();
    public DbSet<Transcricao> Transcricoes => Set<Transcricao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibrasInterviewDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}