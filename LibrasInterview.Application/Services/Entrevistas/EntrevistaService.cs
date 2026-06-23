using LibrasInterview.Application.Abstractions.Entrevistas;
using LibrasInterview.Application.Abstractions.Usuarios;
using LibrasInterview.Application.Requests.Entrevistas;
using LibrasInterview.Application.Responses.Entrevistas;
using LibrasInterview.Domain.Entities;
using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Services.Entrevistas;

public class EntrevistaService : IEntrevistaService
{
    private readonly IEntrevistaRepository entrevistaRepository;
    private readonly IUsuarioRepository usuarioRepository;

    public EntrevistaService(
        IEntrevistaRepository entrevistaRepository,
        IUsuarioRepository usuarioRepository)
    {
        this.entrevistaRepository = entrevistaRepository;
        this.usuarioRepository = usuarioRepository;
    }

    public async Task<EntrevistaResponse> CriarAsync(EntrevistaRequest request)
    {
        Usuario entrevistador = await usuarioRepository.ObterPorIdAsync(request.EntrevistadorId)
            ?? throw new Exception("Entrevistador não encontrado");

        Usuario candidato = await usuarioRepository.ObterPorIdAsync(request.CandidatoId)
            ?? throw new Exception("Candidato não encontrado");

        Entrevista entrevista = new Entrevista(
            entrevistador,
            candidato,
            request.DataHora);

        if (entrevistador.TipoUsuario != TipoUsuario.Entrevistador)
            throw new Exception("Usuário informado não é um entrevistador");

        if (candidato.TipoUsuario != TipoUsuario.Candidato)
            throw new Exception("Usuário informado não é um candidato");

        await entrevistaRepository.AdicionarAsync(entrevista);
        await entrevistaRepository.SalvarAlteracoesAsync();

        return MapearResponse(entrevista);
    }

    public async Task<EntrevistaResponse?> ObterPorIdAsync(int id)
    {
        Entrevista? entrevista = await entrevistaRepository.ObterPorIdAsync(id);

        if (entrevista is null)
            return null;

        return MapearResponse(entrevista);
    }

    public async Task<IEnumerable<EntrevistaResponse>> ListarAsync()
    {
        IEnumerable<Entrevista> entrevistas = await entrevistaRepository.ListarAsync();

        return entrevistas.Select(MapearResponse);
    }

    public async Task<EntrevistaResponse?> AtualizarAsync(int id, EntrevistaRequest request)
    {
        Entrevista? entrevista = await entrevistaRepository.ObterPorIdAsync(id);

        if (entrevista is null)
            return null;

        Usuario entrevistador = await usuarioRepository.ObterPorIdAsync(request.EntrevistadorId)
            ?? throw new Exception("Entrevistador não encontrado");

        Usuario candidato = await usuarioRepository.ObterPorIdAsync(request.CandidatoId)
            ?? throw new Exception("Candidato não encontrado");

        entrevista.SetEntrevistador(entrevistador);
        entrevista.SetCandidato(candidato);
        entrevista.SetDataHora(request.DataHora);

        await entrevistaRepository.AtualizarAsync(entrevista);
        await entrevistaRepository.SalvarAlteracoesAsync();

        return MapearResponse(entrevista);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        Entrevista? entrevista = await entrevistaRepository.ObterPorIdAsync(id);

        if (entrevista is null)
            return false;

        await entrevistaRepository.RemoverAsync(entrevista);
        await entrevistaRepository.SalvarAlteracoesAsync();

        return true;
    }

    private static EntrevistaResponse MapearResponse(Entrevista entrevista)
    {
        return new EntrevistaResponse
        {
            Id = entrevista.Id,
            EntrevistadorId = entrevista.Entrevistador.Id,
            CandidatoId = entrevista.Candidato.Id,
            DataHora = entrevista.DataHora,
            Status = entrevista.Status
        };
    }
}