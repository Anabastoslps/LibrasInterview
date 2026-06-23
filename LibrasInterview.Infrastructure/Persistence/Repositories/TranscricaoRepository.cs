using LibrasInterview.Application.Abstractions.Transcricoes;
using LibrasInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrasInterview.Infrastructure.Persistence.Repositories;

public class TranscricaoRepository : ITranscricaoRepository
{
    private readonly LibrasInterviewDbContext context;

    public TranscricaoRepository(LibrasInterviewDbContext context)
    {
        this.context = context;
    }

    public async Task<Transcricao?> ObterPorIdAsync(int id)
    {
        return await context.Transcricoes
            .Include(x => x.Entrevista)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Transcricao>> ListarPorEntrevistaAsync(int entrevistaId)
    {
        return await context.Transcricoes
            .Where(x => x.EntrevistaId == entrevistaId)
            .OrderBy(x => x.Timestamp)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Transcricao entidade)
    {
        await context.Transcricoes.AddAsync(entidade);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await context.SaveChangesAsync();
    }
}