using LibrasInterview.Application.Abstractions.Usuarios;
using LibrasInterview.Application.Requests.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace LibrasInterview.Api.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        return Ok(await usuarioService.ListarAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var usuario = await usuarioService.ObterPorIdAsync(id);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Inserir(
        [FromBody] UsuarioRequest request)
    {
        return Ok(await usuarioService.CriarAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Editar(
        int id,
        [FromBody] UsuarioRequest request)
    {
        var usuario = await usuarioService.AtualizarAsync(id, request);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        bool removido = await usuarioService.RemoverAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }
}