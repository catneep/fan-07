using Microsoft.EntityFrameworkCore.Migrations;

namespace fan_07.Data.Migrations
{
    public partial class migracion1a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Distribuidores",
                newName: "URL");

            migrationBuilder.AddColumn<string>(
                name: "NombrePaqueteria",
                table: "Distribuidores",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreResponsable",
                table: "Distribuidores",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Distribuidores",
                type: "TEXT",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombrePaqueteria",
                table: "Distribuidores");

            migrationBuilder.DropColumn(
                name: "NombreResponsable",
                table: "Distribuidores");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Distribuidores");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Distribuidores",
                newName: "Nombre");
        }
    }
}
