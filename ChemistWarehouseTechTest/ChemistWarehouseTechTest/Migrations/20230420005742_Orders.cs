using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChemistWarehouseTechTest.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("031652a7-7d4b-4382-b3f0-8015706367ee"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("205a2b3a-c312-439a-8156-75748e0903c3"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("3aaeb1cc-9a4c-424b-83ef-b0fbf53259ab"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("ecdfcbac-c119-4b75-b8c5-592dd3f205c2"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("f14c11be-8891-4d76-8e5d-8862765603d5"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("7190e6de-9842-4e27-9f37-70128c27739f"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("9f701bdc-aaf1-441c-9ff5-0497de88da1e"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PizzaOrders_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzeria",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2a20c202-8d8c-46ba-b504-9d00d0202c4f"), "Preston", "Preston Pizzeria" },
                    { new Guid("3216793e-35d5-4b7f-a304-fa2eb2b9ee7d"), "Southbank", "Southbank Pizzeria" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Name", "PizzeriaId", "Price", "Toppings" },
                values: new object[,]
                {
                    { new Guid("0da72bd5-eb42-406c-91b4-6a46f1f566af"), "Capricciosa", new Guid("2a20c202-8d8c-46ba-b504-9d00d0202c4f"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("57e9a4b8-a6b3-413f-a9e2-cad4ddd031d8"), "Mexicana", new Guid("2a20c202-8d8c-46ba-b504-9d00d0202c4f"), 18, "Cheese,Salami,Capiscum,Chilli" },
                    { new Guid("b4c4fe0a-7768-45ba-b61d-ea4f83a29d9c"), "Margherita", new Guid("2a20c202-8d8c-46ba-b504-9d00d0202c4f"), 22, "Cheese,Spinach,Ricotta,Cherry Tomatoes" },
                    { new Guid("ef9abe16-6fcd-42b2-9e72-53b1fcdc245c"), "Capricciosa", new Guid("3216793e-35d5-4b7f-a304-fa2eb2b9ee7d"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("f5d075bb-d804-4a8a-ba3e-2efa276589fd"), "Vegetarian", new Guid("3216793e-35d5-4b7f-a304-fa2eb2b9ee7d"), 17, "Cheese,Mushrooms,Capiscum,Onion,Olives" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_OrderId",
                table: "PizzaOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_PizzaId",
                table: "PizzaOrders",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("0da72bd5-eb42-406c-91b4-6a46f1f566af"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("57e9a4b8-a6b3-413f-a9e2-cad4ddd031d8"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("b4c4fe0a-7768-45ba-b61d-ea4f83a29d9c"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("ef9abe16-6fcd-42b2-9e72-53b1fcdc245c"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("f5d075bb-d804-4a8a-ba3e-2efa276589fd"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("2a20c202-8d8c-46ba-b504-9d00d0202c4f"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("3216793e-35d5-4b7f-a304-fa2eb2b9ee7d"));

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
        }
    }
}
