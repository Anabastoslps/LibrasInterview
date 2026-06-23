using LibrasInterview.Application.Abstractions.Entrevistas;
using LibrasInterview.Application.Abstractions.Transcricoes;
using LibrasInterview.Application.Requests.Transcricoes;
using LibrasInterview.Application.Responses.Transcricoes;
using LibrasInterview.Domain.Entities;
using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Services.Transcricoes;

public class TranscricaoService : ITranscricaoService
{
    private readonly IEntrevistaRepository entrevistaRepository;
    private readonly ITranscricaoRepository transcricaoRepository;

    public TranscricaoService(
        IEntrevistaRepository entrevistaRepository,
        ITranscricaoRepository transcricaoRepository)
    {
        this.entrevistaRepository = entrevistaRepository;
        this.transcricaoRepository = transcricaoRepository;
    }

    public async Task<TranscricaoResponse> AdicionarAsync(TranscricaoRequest request)
    {
        Entrevista entrevista = await entrevistaRepository.ObterPorIdAsync(request.EntrevistaId)
            ?? throw new Exception("Entrevista não encontrada");

        Transcricao transcricao = new Transcricao(
            entrevista,
            request.Texto,
            request.Tipo,
            request.Fonte,
            DateTime.UtcNow,
            request.Confianca);

        entrevista.AddTranscricao(transcricao);

        await transcricaoRepository.AdicionarAsync(transcricao);
        await transcricaoRepository.SalvarAlteracoesAsync();

        return MapearResponse(transcricao);
    }

    public async Task<IEnumerable<TranscricaoResponse>> ListarPorEntrevistaAsync(int entrevistaId)
    {
        IEnumerable<Transcricao> transcricoes =
            await transcricaoRepository.ListarPorEntrevistaAsync(entrevistaId);

        return transcricoes.Select(MapearResponse);
    }

    private static TranscricaoResponse MapearResponse(Transcricao transcricao)
    {
        return new TranscricaoResponse
        {
            Id = transcricao.Id,
            EntrevistaId = transcricao.EntrevistaId,
            Texto = transcricao.Texto,
            Tipo = transcricao.Tipo,
            Fonte = transcricao.Fonte,
            Timestamp = transcricao.Timestamp,
            Confianca = transcricao.Confianca
        };
    }
}