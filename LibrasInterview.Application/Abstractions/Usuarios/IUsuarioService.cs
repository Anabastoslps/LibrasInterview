using LibrasInterview.Application.Requests.Usuarios;
using LibrasInterview.Application.Responses.Usuarios;

namespace LibrasInterview.Application.Abstractions.Usuarios;

public interface IUsuarioService
{
    Task<UsuarioResponse> CriarAsync(UsuarioRequest request);
    Task<UsuarioResponse?> ObterPorIdAsync(int id);
    Task<IEnumerable<UsuarioResponse>> ListarAsync();
    Task<UsuarioResponse?> AtualizarAsync(int id, UsuarioRequest request);
    Task<bool> RemoverAsync(int id);
}