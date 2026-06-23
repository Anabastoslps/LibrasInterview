
using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Domain.Entities;
public class Usuario
{
    public virtual int Id { get; protected set; }
    public virtual string Nome {get; protected set;} = null!;
    public virtual string Email {get; protected set; } = null!;
    public virtual TipoUsuario TipoUsuario { get; protected set; }

    protected Usuario(){}

    public Usuario(string nome, string email, TipoUsuario tipoUsuario)
    {
       
        SetNome(nome);
        SetEmail(email);
        SetTipoUsuario(tipoUsuario);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("Nome é obrigatório");
        if (nome.Trim().Length > 150)
        throw new Exception("Nome deve possuir no máximo 150 caracteres");    

        Nome = nome.Trim();
    }

    public virtual void SetEmail(string email)
{
    if (string.IsNullOrWhiteSpace(email))
        throw new Exception("Email é obrigatório");
    
    if (!email.Contains("@") || email.Length > 254) 
        throw new Exception("Email inválido");
    
    Email = email.Trim().ToLower();
}

     public virtual void SetTipoUsuario(TipoUsuario tipoUsuario)
    {
        if (!Enum.IsDefined(typeof(TipoUsuario), tipoUsuario))
        throw new Exception("Tipo de usuário inválido");

        TipoUsuario = tipoUsuario;
    }
}