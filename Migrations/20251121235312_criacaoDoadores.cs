using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisDoBem.Migrations
{
    /// <inheritdoc />
    public partial class criacaoDoadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembrosFamilia",
                table: "Donatario");

            migrationBuilder.DropColumn(
                name: "RendaMensal",
                table: "Donatario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Donatario",
                newName: "TipoUsuario");

            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "Donatario",
                newName: "Telefone");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Donatario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Donatario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Doador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doador", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doador");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Donatario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Donatario");

            migrationBuilder.RenameColumn(
                name: "TipoUsuario",
                table: "Donatario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Donatario",
                newName: "Observacoes");

            migrationBuilder.AddColumn<int>(
                name: "MembrosFamilia",
                table: "Donatario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RendaMensal",
                table: "Donatario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
