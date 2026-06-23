using LibrasInterview.Application.Abstractions.Usuarios;
using LibrasInterview.Domain.Entities;
using LibrasInterview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibrasInterview.Infrastructure.Persistence.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly LibrasInterviewDbContext context;

    public UsuarioRepository(LibrasInterviewDbContext context)
    {
        this.context = context;
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await context.Usuarios
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Usuario>> ListarAsync()
    {
        return await context.Usuarios
            .ToListAsync();
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await context.Usuarios.AddAsync(usuario);
    }

    public Task AtualizarAsync(Usuario usuario)
    {
        context.Usuarios.Update(usuario);
        return Task.CompletedTask;
    }

    public Task RemoverAsync(Usuario usuario)
    {
        context.Usuarios.Remove(usuario);
        return Task.CompletedTask;
    }

    public async Task SalvarAlteracoesAsync()
    {
        await context.SaveChangesAsync();
    }
}