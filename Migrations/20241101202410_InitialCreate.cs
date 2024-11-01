using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    QtdPaginas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Livro_TB_Autor_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "TB_Autor",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TB_Autor",
                columns: new[] { "Id", "Cpf", "DataNascimento", "Latitude", "Longitude", "Nome" },
                values: new object[] { 1, "12345678900", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 0.0, "J.K. Rowling" });

            migrationBuilder.InsertData(
                table: "TB_Livro",
                columns: new[] { "Id", "Editora", "IdAutor", "Nome", "Preco", "QtdPaginas" },
                values: new object[] { 1, "PedroBala", 1, "Harry Potter", 50.0, 365 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Livro_IdAutor",
                table: "TB_Livro",
                column: "IdAutor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Livro");

            migrationBuilder.DropTable(
                name: "TB_Autor");
        }
    }
}
