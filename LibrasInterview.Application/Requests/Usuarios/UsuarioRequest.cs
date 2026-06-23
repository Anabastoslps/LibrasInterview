
using LibrasInterview.Domain.Enums;
namespace LibrasInterview.Application.Requests.Usuarios;

public class UsuarioRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public TipoUsuario TipoUsuario { get; set; }
}