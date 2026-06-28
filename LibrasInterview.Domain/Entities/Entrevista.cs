using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Domain.Entities;

public class Entrevista
{
    public virtual int Id { get; protected set; }
    public virtual int EntrevistadorId { get; protected set; }

    public virtual Usuario Entrevistador { get; protected set; } = null!;
    public virtual int CandidatoId { get; protected set; }

    public virtual Usuario Candidato { get; protected set; } = null!;

    public virtual DateTime DataHora { get; protected set; }
    public virtual string Titulo { get; protected set; } = string.Empty;
    public virtual string Descricao { get; protected set; } = string.Empty;

    public virtual StatusEntrevista Status { get; protected set; }
    public virtual IList<Transcricao> Transcricoes { get; protected set; }
    = new List<Transcricao>();

    protected Entrevista()
    {
        Status = StatusEntrevista.Agendada;
    }

    public Entrevista(
        string titulo,
        string descricao,
        Usuario entrevistador,
        Usuario candidato,
        DateTime dataHora
    )
    {
        SetTitulo(titulo);
        SetDescricao(descricao);
        SetEntrevistador(entrevistador);
        SetCandidato(candidato);
        ValidarParticipantes();
        SetDataHora(dataHora);
        SetStatusAgendada();

    }
    public virtual void SetTitulo(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new Exception("Título da entrevista é obrigatório");

        Titulo = titulo.Trim();
    }

    public virtual void SetDescricao(string descricao)
    {
        Descricao = descricao?.Trim() ?? string.Empty;
    }

    public virtual void SetEntrevistador(Usuario entrevistador)
    {
        if (entrevistador is null)
            throw new Exception("Entrevistador é obrigatório");

        Entrevistador = entrevistador;
        EntrevistadorId = entrevistador.Id;
    }

    public virtual void SetCandidato(Usuario candidato)
    {
        if (candidato is null)
            throw new Exception("Candidato é obrigatório");

        Candidato = candidato;
        CandidatoId = candidato.Id;
    }

    public virtual void ValidarParticipantes()
    {
        if (Entrevistador is not null && Candidato is not null && Entrevistador.Id == Candidato.Id)
            throw new Exception("Entrevistador e candidato devem ser pessoas diferentes");
    }

    public virtual void SetDataHora(DateTime dataHora)
    {
        if (dataHora < DateTime.Now)
            throw new Exception("Data da entrevista deve ser no futuro");

        DataHora = dataHora;
    }
    public virtual void SetStatusAgendada()
    {
        Status = StatusEntrevista.Agendada;
    }

    public virtual void AddTranscricao(Transcricao transcricao)
    {
        if (transcricao is null)
            throw new Exception("Transcrição é obrigatória");

        Transcricoes.Add(transcricao);
    }
}