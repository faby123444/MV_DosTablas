using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MV_DosTablas.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MV_Burger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    WithCheese = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MV_Burger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MV_Promo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<int>(type: "int", nullable: false),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MV_Promo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MV_Promo_MV_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "MV_Burger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MV_Promo_BurgerId",
                table: "MV_Promo",
                column: "BurgerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MV_Promo");

            migrationBuilder.DropTable(
                name: "MV_Burger");
        }
    }
}
