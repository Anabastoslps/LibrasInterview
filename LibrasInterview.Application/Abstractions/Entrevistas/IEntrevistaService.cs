using LibrasInterview.Application.Requests.Entrevistas;
using LibrasInterview.Application.Responses.Entrevistas;

namespace LibrasInterview.Application.Abstractions.Entrevistas;

public interface IEntrevistaService
{
    Task<EntrevistaResponse> CriarAsync(EntrevistaRequest request);
    Task<EntrevistaResponse?> ObterPorIdAsync(int id);
    Task<IEnumerable<EntrevistaResponse>> ListarAsync();
    Task<EntrevistaResponse?> AtualizarAsync(int id, EntrevistaRequest request);
    Task<bool> RemoverAsync(int id);
}