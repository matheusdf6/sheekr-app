using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sheekr.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Congregacoes",
                columns: table => new
                {
                    CongregacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCongregacao_NomeLocal = table.Column<string>(nullable: true),
                    NomeCongregacao_Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregacoes", x => x.CongregacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Licoes",
                columns: table => new
                {
                    LicaoId = table.Column<int>(nullable: false),
                    TituloLicao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licoes", x => x.LicaoId);
                });

            migrationBuilder.CreateTable(
                name: "Publicadores",
                columns: table => new
                {
                    PublicadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sexo = table.Column<int>(nullable: false),
                    Privilegio = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    Telefone = table.Column<string>(maxLength: 11, nullable: true),
                    PrimeiroNome = table.Column<string>(nullable: false),
                    UltimoNome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicadores", x => x.PublicadorId);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    TemaId = table.Column<int>(nullable: false),
                    TituloTema = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.TemaId);
                });

            migrationBuilder.CreateTable(
                name: "Territorios",
                columns: table => new
                {
                    TerritorioId = table.Column<int>(nullable: false),
                    Local = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    UrlImagem = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territorios", x => x.TerritorioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Role = table.Column<int>(nullable: false),
                    HashedPassword = table.Column<byte[]>(nullable: false),
                    Salt = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Oradores_Fora",
                columns: table => new
                {
                    OradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CongregacaoId = table.Column<int>(nullable: false),
                    PrimeiroNome = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    UltimoNome = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "varchar", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    EscolhaContato = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oradores_Fora", x => x.OradorId);
                    table.ForeignKey(
                        name: "FK_OradorFora_Congregacao",
                        column: x => x.CongregacaoId,
                        principalTable: "Congregacoes",
                        principalColumn: "CongregacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicadorId = table.Column<int>(nullable: false),
                    FazLeitura = table.Column<bool>(type: "bit", nullable: false),
                    FazDemonstracao = table.Column<bool>(type: "bit", nullable: false),
                    FazDiscurso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Aluno_Publicador",
                        column: x => x.PublicadorId,
                        principalTable: "Publicadores",
                        principalColumn: "PublicadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dirigentes",
                columns: table => new
                {
                    DirigenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirigentes", x => x.DirigenteId);
                    table.ForeignKey(
                        name: "FK_Dirigente_Publicador",
                        column: x => x.PublicadorId,
                        principalTable: "Publicadores",
                        principalColumn: "PublicadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oradores_Locais",
                columns: table => new
                {
                    OradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CongregacaoId = table.Column<int>(nullable: false),
                    PublicadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oradores_Locais", x => x.OradorId);
                    table.ForeignKey(
                        name: "FK_OradorLocal_Congregacao",
                        column: x => x.CongregacaoId,
                        principalTable: "Congregacoes",
                        principalColumn: "CongregacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OradorLocal_Publicador",
                        column: x => x.PublicadorId,
                        principalTable: "Publicadores",
                        principalColumn: "PublicadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discursos_Fora",
                columns: table => new
                {
                    DiscursoLocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OradorForaId = table.Column<int>(nullable: false),
                    TemaId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discursos_Fora", x => x.DiscursoLocalId);
                    table.ForeignKey(
                        name: "FK_DiscursoFora_OradorFora",
                        column: x => x.OradorForaId,
                        principalTable: "Oradores_Fora",
                        principalColumn: "OradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscursoFora_Tema",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "TemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Designacoes",
                columns: table => new
                {
                    DesignacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoPrincipalId = table.Column<int>(nullable: false),
                    AlunoAjudanteId = table.Column<int>(nullable: true),
                    LicaoId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    Local = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designacoes", x => x.DesignacaoId);
                    table.ForeignKey(
                        name: "FK_Designacoes_Aluno_AlunoAjudante",
                        column: x => x.AlunoAjudanteId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Designacoes_Aluno_AlunoPrincipal",
                        column: x => x.AlunoPrincipalId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Designacao_Licao",
                        column: x => x.LicaoId,
                        principalTable: "Licoes",
                        principalColumn: "LicaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    SaidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirigenteId = table.Column<int>(nullable: false),
                    TerritorioId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.SaidaId);
                    table.ForeignKey(
                        name: "FK_Saida_Dirigente",
                        column: x => x.DirigenteId,
                        principalTable: "Dirigentes",
                        principalColumn: "DirigenteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saida_Territorio",
                        column: x => x.TerritorioId,
                        principalTable: "Territorios",
                        principalColumn: "TerritorioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discursos_Locais",
                columns: table => new
                {
                    DiscursoLocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OradorId = table.Column<int>(nullable: false),
                    TemaId = table.Column<int>(nullable: false),
                    CongregacaoId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discursos_Locais", x => x.DiscursoLocalId);
                    table.ForeignKey(
                        name: "FK_DiscursoLocal_Congregacao",
                        column: x => x.CongregacaoId,
                        principalTable: "Congregacoes",
                        principalColumn: "CongregacaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscursoLocal_OradorLocal",
                        column: x => x.OradorId,
                        principalTable: "Oradores_Locais",
                        principalColumn: "OradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscursoLocal_Tema",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "TemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PublicadorId",
                table: "Alunos",
                column: "PublicadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designacoes_AlunoAjudanteId",
                table: "Designacoes",
                column: "AlunoAjudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Designacoes_AlunoPrincipalId",
                table: "Designacoes",
                column: "AlunoPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Designacoes_LicaoId",
                table: "Designacoes",
                column: "LicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dirigentes_PublicadorId",
                table: "Dirigentes",
                column: "PublicadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discursos_Fora_OradorForaId",
                table: "Discursos_Fora",
                column: "OradorForaId");

            migrationBuilder.CreateIndex(
                name: "IX_Discursos_Fora_TemaId",
                table: "Discursos_Fora",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Discursos_Locais_CongregacaoId",
                table: "Discursos_Locais",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Discursos_Locais_OradorId",
                table: "Discursos_Locais",
                column: "OradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Discursos_Locais_TemaId",
                table: "Discursos_Locais",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oradores_Fora_CongregacaoId",
                table: "Oradores_Fora",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oradores_Locais_CongregacaoId",
                table: "Oradores_Locais",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oradores_Locais_PublicadorId",
                table: "Oradores_Locais",
                column: "PublicadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_DirigenteId",
                table: "Saidas",
                column: "DirigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_TerritorioId",
                table: "Saidas",
                column: "TerritorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designacoes");

            migrationBuilder.DropTable(
                name: "Discursos_Fora");

            migrationBuilder.DropTable(
                name: "Discursos_Locais");

            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Licoes");

            migrationBuilder.DropTable(
                name: "Oradores_Fora");

            migrationBuilder.DropTable(
                name: "Oradores_Locais");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Dirigentes");

            migrationBuilder.DropTable(
                name: "Territorios");

            migrationBuilder.DropTable(
                name: "Congregacoes");

            migrationBuilder.DropTable(
                name: "Publicadores");
        }
    }
}
