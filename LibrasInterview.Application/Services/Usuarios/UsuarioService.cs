using LibrasInterview.Application.Abstractions.Usuarios;
using LibrasInterview.Application.Requests.Usuarios;
using LibrasInterview.Application.Responses.Usuarios;
using LibrasInterview.Domain.Entities;

namespace LibrasInterview.Application.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioResponse> CriarAsync(UsuarioRequest request)
    {
        Usuario usuario = new Usuario(request.Nome, request.Email, request.TipoUsuario);

        await usuarioRepository.AdicionarAsync(usuario);
        await usuarioRepository.SalvarAlteracoesAsync();

        return MapearResponse(usuario);
    }

    public async Task<UsuarioResponse?> ObterPorIdAsync(int id)
    {
        Usuario? usuario = await usuarioRepository.ObterPorIdAsync(id);

        if (usuario is null)
            return null;

        return MapearResponse(usuario);
    }

    public async Task<IEnumerable<UsuarioResponse>> ListarAsync()
    {
        IEnumerable<Usuario> usuarios = await usuarioRepository.ListarAsync();

        return usuarios.Select(MapearResponse);
    }

    public async Task<UsuarioResponse?> AtualizarAsync(int id, UsuarioRequest request)
    {
        Usuario? usuario = await usuarioRepository.ObterPorIdAsync(id);

        if (usuario is null)
            return null;

        usuario.SetNome(request.Nome);
        usuario.SetEmail(request.Email);
        usuario.SetTipoUsuario(request.TipoUsuario);

        await usuarioRepository.AtualizarAsync(usuario);
        await usuarioRepository.SalvarAlteracoesAsync();

        return MapearResponse(usuario);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        Usuario? usuario = await usuarioRepository.ObterPorIdAsync(id);

        if (usuario is null)
            return false;

        await usuarioRepository.RemoverAsync(usuario);
        await usuarioRepository.SalvarAlteracoesAsync();

        return true;
    }

    private static UsuarioResponse MapearResponse(Usuario usuario)
    {
        return new UsuarioResponse
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            TipoUsuario = usuario.TipoUsuario
        };
    }
}