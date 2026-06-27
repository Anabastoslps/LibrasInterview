using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibrasInterview.Infrastructure.Persistence;

public class LibrasInterviewDbContextFactory
    : IDesignTimeDbContextFactory<LibrasInterviewDbContext>
{
    public LibrasInterviewDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibrasInterviewDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=libras_interview;Username=postgres;Password=230511"
        );

        return new LibrasInterviewDbContext(optionsBuilder.Options);
    }
}