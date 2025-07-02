using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLEI.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorectionDesProprietes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripction",
                table: "Logements",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "NomVille",
                table: "Villes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Logements",
                newName: "Descripction");

            migrationBuilder.AlterColumn<int>(
                name: "NomVille",
                table: "Villes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
