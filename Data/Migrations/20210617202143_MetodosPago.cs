using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fan_07.Data.Migrations
{
    public partial class MetodosPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetodosPago_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetodosPago_UsuarioId",
                table: "MetodosPago",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetodosPago");
        }
    }
}
