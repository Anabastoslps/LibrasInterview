using LibrasInterview.Application.Requests.Transcricoes;
using LibrasInterview.Application.Responses.Transcricoes;

namespace LibrasInterview.Application.Abstractions.Transcricoes;

public interface ITranscricaoService
{
    Task<TranscricaoResponse> AdicionarAsync(TranscricaoRequest request);
    Task<IEnumerable<TranscricaoResponse>> ListarPorEntrevistaAsync(int entrevistaId);
}