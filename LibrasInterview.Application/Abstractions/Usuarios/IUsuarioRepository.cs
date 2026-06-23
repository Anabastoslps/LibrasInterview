using LibrasInterview.Domain.Entities;

namespace LibrasInterview.Application.Abstractions.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorIdAsync(int id);
    Task<IEnumerable<Usuario>> ListarAsync();
    Task AdicionarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
    Task RemoverAsync(Usuario usuario);
    Task SalvarAlteracoesAsync();
}