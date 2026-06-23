using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Responses.Usuarios;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public TipoUsuario TipoUsuario { get; set; }
}