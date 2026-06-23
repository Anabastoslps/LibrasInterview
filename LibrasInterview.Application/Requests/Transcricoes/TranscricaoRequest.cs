using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Application.Requests.Transcricoes;

public class TranscricaoRequest
{
    public int EntrevistaId { get; set; }
    public string Texto { get; set; } = string.Empty;
    public TipoTranscricao Tipo { get; set; }
    public FonteTranscricao Fonte { get; set; }
    public decimal? Confianca { get; set; }
}