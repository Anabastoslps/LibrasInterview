using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrasInterview.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaFonteTranscricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fonte",
                table: "Transcricoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fonte",
                table: "Transcricoes");
        }
    }
}
