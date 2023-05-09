using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactCsharpExperienceProof.Migrations
{
    /// <inheritdoc />
    public partial class RecurringModelIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("3f37b269-e113-4bd0-8041-439dedac1006"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("69d799ff-708b-417b-b780-d9425b135258"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("69df27ba-5cc8-4ab1-a31f-a69201c16cc3"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("80c05c7f-5503-4f32-8818-c574cd9ca679"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("c6acfc08-5055-40c2-a462-d86200b69893"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("7072458c-275b-4e4d-abcd-d440550616a7"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("9bdfd915-80f8-4bac-8b7f-ddabda896983"));

            migrationBuilder.InsertData(
                table: "Pizzeria",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("604040dc-3932-465a-b34f-5e04b866720f"), "Southbank", "Southbank Pizzeria" },
                    { new Guid("a611203d-9c43-41d6-b26a-83605217c3ce"), "Preston", "Preston Pizzeria" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Name", "PizzeriaId", "Price", "Toppings" },
                values: new object[,]
                {
                    { new Guid("0cb9b12f-e0d9-4640-a333-9f8c78f37e37"), "Capricciosa", new Guid("604040dc-3932-465a-b34f-5e04b866720f"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("1bb899e0-132f-4c8a-b7b0-b0dcf6ff21d0"), "Margherita", new Guid("a611203d-9c43-41d6-b26a-83605217c3ce"), 22, "Cheese,Spinach,Ricotta,Cherry Tomatoes" },
                    { new Guid("4af5a4a9-4c2a-4e2a-b70e-7b1cd6d22a99"), "Capricciosa", new Guid("a611203d-9c43-41d6-b26a-83605217c3ce"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("f08ebe1d-2d55-4028-8fcb-385617de135a"), "Vegetarian", new Guid("604040dc-3932-465a-b34f-5e04b866720f"), 17, "Cheese,Mushrooms,Capiscum,Onion,Olives" },
                    { new Guid("f88adde4-5378-4521-ab59-34c54598ce2b"), "Mexicana", new Guid("a611203d-9c43-41d6-b26a-83605217c3ce"), 18, "Cheese,Salami,Capiscum,Chilli" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("0cb9b12f-e0d9-4640-a333-9f8c78f37e37"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("1bb899e0-132f-4c8a-b7b0-b0dcf6ff21d0"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("4af5a4a9-4c2a-4e2a-b70e-7b1cd6d22a99"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("f08ebe1d-2d55-4028-8fcb-385617de135a"));

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: new Guid("f88adde4-5378-4521-ab59-34c54598ce2b"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("604040dc-3932-465a-b34f-5e04b866720f"));

            migrationBuilder.DeleteData(
                table: "Pizzeria",
                keyColumn: "Id",
                keyValue: new Guid("a611203d-9c43-41d6-b26a-83605217c3ce"));

            migrationBuilder.InsertData(
                table: "Pizzeria",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("7072458c-275b-4e4d-abcd-d440550616a7"), "Southbank", "Southbank Pizzeria" },
                    { new Guid("9bdfd915-80f8-4bac-8b7f-ddabda896983"), "Preston", "Preston Pizzeria" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Name", "PizzeriaId", "Price", "Toppings" },
                values: new object[,]
                {
                    { new Guid("3f37b269-e113-4bd0-8041-439dedac1006"), "Vegetarian", new Guid("7072458c-275b-4e4d-abcd-d440550616a7"), 17, "Cheese,Mushrooms,Capiscum,Onion,Olives" },
                    { new Guid("69d799ff-708b-417b-b780-d9425b135258"), "Capricciosa", new Guid("9bdfd915-80f8-4bac-8b7f-ddabda896983"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("69df27ba-5cc8-4ab1-a31f-a69201c16cc3"), "Mexicana", new Guid("9bdfd915-80f8-4bac-8b7f-ddabda896983"), 18, "Cheese,Salami,Capiscum,Chilli" },
                    { new Guid("80c05c7f-5503-4f32-8818-c574cd9ca679"), "Capricciosa", new Guid("7072458c-275b-4e4d-abcd-d440550616a7"), 20, "Cheese,Ham,Mushrooms,Olives" },
                    { new Guid("c6acfc08-5055-40c2-a462-d86200b69893"), "Margherita", new Guid("9bdfd915-80f8-4bac-8b7f-ddabda896983"), 22, "Cheese,Spinach,Ricotta,Cherry Tomatoes" }
                });
        }
    }
}
