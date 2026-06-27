using LibrasInterview.Application.Abstractions.Entrevistas;
using LibrasInterview.Domain.Entities;
using LibrasInterview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrasInterview.Infrastructure.Persistence.Repositories;

public class EntrevistaRepository : IEntrevistaRepository
{
    private readonly LibrasInterviewDbContext context;

    public EntrevistaRepository(LibrasInterviewDbContext context)
    {
        this.context = context;
    }

    public async Task<Entrevista?> ObterPorIdAsync(int id)
    {
        return await context.Entrevistas
            .Include(x => x.Entrevistador)
            .Include(x => x.Candidato)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Entrevista>> ListarAsync()
    {
        return await context.Entrevistas
            .Include(x => x.Entrevistador)
            .Include(x => x.Candidato)
            .OrderBy(x => x.DataHora)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Entrevista entidade)
    {
        await context.Entrevistas.AddAsync(entidade);
    }

    public Task AtualizarAsync(Entrevista entidade)
    {
        context.Entrevistas.Update(entidade);
        return Task.CompletedTask;
    }

    public Task RemoverAsync(Entrevista entidade)
    {
        context.Entrevistas.Remove(entidade);
        return Task.CompletedTask;
    }

    public async Task SalvarAlteracoesAsync()
    {
        await context.SaveChangesAsync();
    }
}