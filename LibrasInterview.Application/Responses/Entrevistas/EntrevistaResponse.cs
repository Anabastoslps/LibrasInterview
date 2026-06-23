using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Responses.Entrevistas;

public class EntrevistaResponse
{
    public int Id { get; set; }
    public int EntrevistadorId { get; set; }
    public int CandidatoId { get; set; }
    public DateTime DataHora { get; set; }
    public StatusEntrevista Status { get; set; }
}