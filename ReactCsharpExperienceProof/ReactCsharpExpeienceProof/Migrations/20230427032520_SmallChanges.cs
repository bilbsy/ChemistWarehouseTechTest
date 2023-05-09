using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactCsharpExperienceProof.Migrations
{
    /// <inheritdoc />
    public partial class SmallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pizzeria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Pizzeria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "PizzaOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalToppings",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Toppings",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "PizzeriaId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzeriaId",
                table: "Orders",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pizzeria_PizzeriaId",
                table: "Orders",
                column: "PizzeriaId",
                principalTable: "Pizzeria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pizzeria_PizzeriaId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PizzeriaId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "AdditionalToppings",
                table: "PizzaOrders");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pizzeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Pizzeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "PizzaOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Toppings",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
