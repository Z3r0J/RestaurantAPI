using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 386, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 386, DateTimeKind.Utc).AddTicks(888));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 386, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 386, DateTimeKind.Utc).AddTicks(896));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 387, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 387, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 387, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 387, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 26, 22, 30, 4, 387, DateTimeKind.Utc).AddTicks(4320));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(1769));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(202));
        }
    }
}
