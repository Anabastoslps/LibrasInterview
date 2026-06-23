using LibrasInterview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrasInterview.Infrastructure.Persistence.Configurations;

public class EntrevistaConfiguration : IEntityTypeConfiguration<Entrevista>
{
    public void Configure(EntityTypeBuilder<Entrevista> builder)
    {
        builder.ToTable("Entrevistas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataHora)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.Entrevistador)
            .WithMany()
            .HasForeignKey("EntrevistadorId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Candidato)
            .WithMany()
            .HasForeignKey("CandidatoId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Transcricoes)
            .WithOne(x => x.Entrevista)
            .HasForeignKey(x => x.EntrevistaId);
    }
}