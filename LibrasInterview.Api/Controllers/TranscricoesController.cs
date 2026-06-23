using LibrasInterview.Application.Abstractions.Transcricoes;
using LibrasInterview.Application.Requests.Transcricoes;
using Microsoft.AspNetCore.Mvc;

namespace LibrasInterview.Api.Controllers;

[ApiController]
[Route("api/transcricoes")]
public class TranscricoesController : ControllerBase
{
    private readonly ITranscricaoService transcricaoService;

    public TranscricoesController(ITranscricaoService transcricaoService)
    {
        this.transcricaoService = transcricaoService;
    }

    [HttpGet("entrevista/{entrevistaId}")]
    public async Task<IActionResult> ListarPorEntrevista(int entrevistaId)
    {
        var transcricoes = await transcricaoService.ListarPorEntrevistaAsync(entrevistaId);

        return Ok(transcricoes);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] TranscricaoRequest request)
    {
        var transcricao = await transcricaoService.AdicionarAsync(request);

        return Ok(transcricao);
    }
}