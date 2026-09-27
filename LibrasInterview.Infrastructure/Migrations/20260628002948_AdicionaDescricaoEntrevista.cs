using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrasInterview.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaDescricaoEntrevista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Entrevistas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Entrevistas");
        }
    }
}
