using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GsEnterpriseSolution.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TABLE_GS_SOLUTION_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE_GS_SOLUTION_ENDERECO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TABLE_GS_SOLUTION_LOGIN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE_GS_SOLUTION_LOGIN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<int>(type: "int", nullable: false),
                    Crm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissionais_TABLE_GS_SOLUTION_LOGIN_LoginId",
                        column: x => x.LoginId,
                        principalTable: "TABLE_GS_SOLUTION_LOGIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TABLE_GS_SOLUTION_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE_GS_SOLUTION_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TABLE_GS_SOLUTION_USUARIO_TABLE_GS_SOLUTION_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TABLE_GS_SOLUTION_ENDERECO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TABLE_GS_SOLUTION_USUARIO_TABLE_GS_SOLUTION_LOGIN_LoginId",
                        column: x => x.LoginId,
                        principalTable: "TABLE_GS_SOLUTION_LOGIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TABLE_GS_SOLUTION_CONTATO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE_GS_SOLUTION_CONTATO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TABLE_GS_SOLUTION_CONTATO_TABLE_GS_SOLUTION_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TABLE_GS_SOLUTION_USUARIO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_LoginId",
                table: "Profissionais",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_TABLE_GS_SOLUTION_CONTATO_UsuarioId",
                table: "TABLE_GS_SOLUTION_CONTATO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TABLE_GS_SOLUTION_USUARIO_EnderecoId",
                table: "TABLE_GS_SOLUTION_USUARIO",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TABLE_GS_SOLUTION_USUARIO_LoginId",
                table: "TABLE_GS_SOLUTION_USUARIO",
                column: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "TABLE_GS_SOLUTION_CONTATO");

            migrationBuilder.DropTable(
                name: "TABLE_GS_SOLUTION_USUARIO");

            migrationBuilder.DropTable(
                name: "TABLE_GS_SOLUTION_ENDERECO");

            migrationBuilder.DropTable(
                name: "TABLE_GS_SOLUTION_LOGIN");
        }
    }
}
