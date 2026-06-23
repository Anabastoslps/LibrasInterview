using LibrasInterview.Application.Abstractions.Entrevistas;
using LibrasInterview.Application.Requests.Entrevistas;
using Microsoft.AspNetCore.Mvc;

namespace LibrasInterview.Api.Controllers;

[ApiController]
[Route("api/entrevistas")]
public class EntrevistasController : ControllerBase
{
    private readonly IEntrevistaService entrevistaService;

    public EntrevistasController(IEntrevistaService entrevistaService)
    {
        this.entrevistaService = entrevistaService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        return Ok(await entrevistaService.ListarAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var entrevista = await entrevistaService.ObterPorIdAsync(id);

        if (entrevista is null)
            return NotFound();

        return Ok(entrevista);
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] EntrevistaRequest request)
    {
        var entrevista = await entrevistaService.CriarAsync(request);

        return Ok(entrevista);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Editar(
        int id,
        [FromBody] EntrevistaRequest request)
    {
        var entrevista = await entrevistaService.AtualizarAsync(id, request);

        if (entrevista is null)
            return NotFound();

        return Ok(entrevista);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        bool removido = await entrevistaService.RemoverAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }
}