using LibrasInterview.Domain.Enums;

namespace LibrasInterview.Domain.Entities
{
    public class Transcricao
    {
        public virtual int Id { get; protected set; }
        public virtual int EntrevistaId { get; protected set; }
        public virtual Entrevista Entrevista { get; protected set; } = null!;
        public virtual string Texto { get; protected set; } = null!;
        public virtual TipoTranscricao Tipo { get; protected set; } 
        public virtual FonteTranscricao Fonte { get; protected set; }
        public virtual DateTime Timestamp { get; protected set; }
        public virtual decimal? Confianca { get; protected set; }
       

        protected Transcricao() { }

        public Transcricao(Entrevista entrevista, string texto, TipoTranscricao tipo, FonteTranscricao fonte, DateTime timestamp, decimal? confianca = null)
        {

            SetEntrevista(entrevista);
            SetTexto(texto);
            SetTipo(tipo);
            SetFonte(fonte);
            SetTimestamp(timestamp);
            SetConfianca(confianca);
            
        }
        public virtual void SetEntrevista(Entrevista entrevista)
        {
            if (entrevista is null)
                throw new Exception("Entrevista é obrigatória");

            Entrevista = entrevista;
            EntrevistaId = entrevista.Id;
        }

        public virtual void SetTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new Exception("Texto da transcrição é obrigatório");

            Texto = texto.Trim();
        }

        public virtual void SetTipo(TipoTranscricao tipo)
        {
            if (!Enum.IsDefined(typeof(TipoTranscricao), tipo))
        throw new Exception("Tipo de transcrição inválido");

            Tipo = tipo;
        }
        public virtual void SetFonte(FonteTranscricao fonte)
        {
            if (!Enum.IsDefined(typeof(FonteTranscricao), fonte))
                throw new Exception("Fonte da transcrição inválida");

            Fonte = fonte;
        }

        public virtual void SetTimestamp(DateTime timestamp)
        {
            Timestamp = timestamp == default ? DateTime.UtcNow : timestamp;
        }

        public virtual void SetConfianca(decimal? confianca)
        {
            Confianca = confianca;
        }

    }
}