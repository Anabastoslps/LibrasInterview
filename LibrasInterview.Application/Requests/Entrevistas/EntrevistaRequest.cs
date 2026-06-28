namespace LibrasInterview.Application.Requests.Entrevistas;

public class EntrevistaRequest
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int EntrevistadorId { get; set; }
    public int CandidatoId { get; set; }
    public DateTimeOffset DataHora { get; set; }
}