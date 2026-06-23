using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Responses.Transcricoes;

public class TranscricaoResponse
{
    public int Id { get; set; }
    public int EntrevistaId { get; set; }
    public string Texto { get; set; } = string.Empty;
    public TipoTranscricao Tipo { get; set; }
    public FonteTranscricao Fonte { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal? Confianca { get; set; }
}
