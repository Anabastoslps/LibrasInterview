namespace LibrasInterview.Application.Requests.Entrevistas;

public class EntrevistaRequest
{
    public int EntrevistadorId { get; set; }
    public int CandidatoId { get; set; }
    public DateTime DataHora { get; set; }
}