using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Infrastructure.Persistence.Migrations
{
    public partial class UpdateNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Dish_Dish_OrderId",
                schema: "RestaurantAPI",
                table: "Order_Dish");

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 82, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 82, DateTimeKind.Utc).AddTicks(2717));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 82, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 82, DateTimeKind.Utc).AddTicks(2724));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 83, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 83, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 83, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 83, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 7, 27, 20, 17, 23, 83, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.CreateIndex(
                name: "IX_Order_Dish_DishId",
                schema: "RestaurantAPI",
                table: "Order_Dish",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Dish_Dish_DishId",
                schema: "RestaurantAPI",
                table: "Order_Dish",
                column: "DishId",
                principalSchema: "RestaurantAPI",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Dish_Dish_DishId",
                schema: "RestaurantAPI",
                table: "Order_Dish");

            migrationBuilder.DropIndex(
                name: "IX_Order_Dish_DishId",
                schema: "RestaurantAPI",
                table: "Order_Dish");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Dish_Dish_OrderId",
                schema: "RestaurantAPI",
                table: "Order_Dish",
                column: "OrderId",
                principalSchema: "RestaurantAPI",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
