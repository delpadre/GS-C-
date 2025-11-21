using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSync.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalidadeTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TendenciaMercados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TendenciaMercados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadeProfissionais",
                columns: table => new
                {
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadeProfissionais", x => new { x.ProfissionalId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_HabilidadeProfissionais_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadeProfissionais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecomendacaoCarreiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecomendacaoCarreiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecomendacaoCarreiras_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadeVagas",
                columns: table => new
                {
                    VagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadeVagas", x => new { x.VagaId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_HabilidadeVagas_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadeVagas_Vagas_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CNPJ",
                table: "Empresas",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadeProfissionais_HabilidadeId",
                table: "HabilidadeProfissionais",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadeVagas_HabilidadeId",
                table: "HabilidadeVagas",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_Email",
                table: "Profissionais",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecomendacaoCarreiras_ProfissionalId",
                table: "RecomendacaoCarreiras",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EmpresaId",
                table: "Vagas",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabilidadeProfissionais");

            migrationBuilder.DropTable(
                name: "HabilidadeVagas");

            migrationBuilder.DropTable(
                name: "RecomendacaoCarreiras");

            migrationBuilder.DropTable(
                name: "TendenciaMercados");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
