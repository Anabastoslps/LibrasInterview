using LibrasInterview.Domain.Entities;

namespace LibrasInterview.Application.Abstractions.Entrevistas;

public interface IEntrevistaRepository
{
    Task<Entrevista?> ObterPorIdAsync(int id);
    Task<IEnumerable<Entrevista>> ListarAsync();
    Task AdicionarAsync(Entrevista entidade);
    Task AtualizarAsync(Entrevista entidade);
    Task RemoverAsync(Entrevista entidade);
    Task SalvarAlteracoesAsync();
}