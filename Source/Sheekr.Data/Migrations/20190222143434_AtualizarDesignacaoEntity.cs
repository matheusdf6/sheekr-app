using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheekr.Data.Migrations
{
    public partial class AtualizarDesignacaoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlunoAjudanteId",
                table: "Designacoes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlunoAjudanteId",
                table: "Designacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
