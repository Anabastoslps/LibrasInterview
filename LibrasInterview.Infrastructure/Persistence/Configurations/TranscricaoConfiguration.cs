using LibrasInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrasInterview.Infrastructure.Persistence.Configurations;

public class TranscricaoConfiguration : IEntityTypeConfiguration<Transcricao>
{
    public void Configure(EntityTypeBuilder<Transcricao> builder)
    {
        builder.ToTable("Transcricoes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Texto)
            .IsRequired();

        builder.Property(x => x.Tipo)
            .IsRequired();
            
        builder.Property(x => x.Fonte)
            .IsRequired();

        builder.Property(x => x.Timestamp)
            .IsRequired();

        builder.Property(x => x.Confianca);
    }
}