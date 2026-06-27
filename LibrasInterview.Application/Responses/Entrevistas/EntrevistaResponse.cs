using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Responses.Entrevistas;

public class EntrevistaResponse
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int EntrevistadorId { get; set; }
    public string EntrevistadorNome { get; set; } = string.Empty;
    public int CandidatoId { get; set; }
    public string CandidatoNome { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public StatusEntrevista Status { get; set; }
}