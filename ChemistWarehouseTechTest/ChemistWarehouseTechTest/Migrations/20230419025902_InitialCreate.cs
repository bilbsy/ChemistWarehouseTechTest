using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChemistWarehouseTechTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzeria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzeria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PizzeriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Toppings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Pizzeria_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzeria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzeria",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("7190e6de-9842-4e27-9f37-70128c27739f"), "Preston", "Preston Pizzeria" },
                    { new Guid("9f701bdc-aaf1-441c-9ff5-0497de88da1e"), "Southbank", "Southbank Pizzeria" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Name", "PizzeriaId", "Price", "Toppings" },
                values: new object[,]
                {
                    { new Guid("031652a7-7d4b-4382-b3f0-8015706367ee"), "Capricciosa", new Guid("7190e6de-9842-4e27-9f37-70128c27739f"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("205a2b3a-c312-439a-8156-75748e0903c3"), "Margherita", new Guid("7190e6de-9842-4e27-9f37-70128c27739f"), 22, "Cheese,Spinach,Ricotta,Cherry Tomatoes" },
                    { new Guid("3aaeb1cc-9a4c-424b-83ef-b0fbf53259ab"), "Vegetarian", new Guid("9f701bdc-aaf1-441c-9ff5-0497de88da1e"), 17, "Cheese,Mushrooms,Capiscum,Onion,Olives" },
                    { new Guid("ecdfcbac-c119-4b75-b8c5-592dd3f205c2"), "Capricciosa", new Guid("9f701bdc-aaf1-441c-9ff5-0497de88da1e"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("f14c11be-8891-4d76-8e5d-8862765603d5"), "Mexicana", new Guid("7190e6de-9842-4e27-9f37-70128c27739f"), 18, "Cheese,Salami,Capiscum,Chilli" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PizzeriaId",
                table: "Pizza",
                column: "PizzeriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Pizzeria");
        }
    }
}
