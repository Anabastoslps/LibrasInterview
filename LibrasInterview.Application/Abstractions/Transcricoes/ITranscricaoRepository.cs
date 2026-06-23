using LibrasInterview.Domain.Entities;

namespace LibrasInterview.Application.Abstractions.Transcricoes;

public interface ITranscricaoRepository
{
    Task<Transcricao?> ObterPorIdAsync(int id);
    Task<IEnumerable<Transcricao>> ListarPorEntrevistaAsync(int entrevistaId);
    Task AdicionarAsync(Transcricao entidade);
    Task SalvarAlteracoesAsync();
}