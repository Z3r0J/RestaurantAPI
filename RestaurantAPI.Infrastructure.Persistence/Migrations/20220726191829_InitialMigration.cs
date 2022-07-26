using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RestaurantAPI");

            migrationBuilder.CreateTable(
                name: "Dish_Category",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Status",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Dish_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Dish_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaximumPeople = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Table_Status_TableStatusId",
                        column: x => x.TableStatusId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Table_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dish_Ingredient",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Ingredient_Dish_DishId",
                        column: x => x.DishId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_Ingredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Order_Status_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Order_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Table_TableId",
                        column: x => x.TableId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Dish",
                schema: "RestaurantAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Dish_Dish_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Dish_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "RestaurantAPI",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "RestaurantAPI",
                table: "Dish_Category",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(5766), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Entry Dish" },
                    { 2, new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7422), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Main Dish" },
                    { 3, new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7433), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dessert" },
                    { 4, new DateTime(2022, 7, 26, 19, 18, 28, 263, DateTimeKind.Utc).AddTicks(7438), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beverage" }
                });

            migrationBuilder.InsertData(
                schema: "RestaurantAPI",
                table: "Order_Status",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(1758), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In Process" },
                    { 2, new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(1769), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Completed" }
                });

            migrationBuilder.InsertData(
                schema: "RestaurantAPI",
                table: "Table_Status",
                columns: new[] { "Id", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(181), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available" },
                    { 2, new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(198), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In Process to service" },
                    { 3, new DateTime(2022, 7, 26, 19, 18, 28, 266, DateTimeKind.Utc).AddTicks(202), "EF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Serviced" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CategoryId",
                schema: "RestaurantAPI",
                table: "Dish",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Ingredient_DishId",
                schema: "RestaurantAPI",
                table: "Dish_Ingredient",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Ingredient_IngredientId",
                schema: "RestaurantAPI",
                table: "Dish_Ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                schema: "RestaurantAPI",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                schema: "RestaurantAPI",
                table: "Order",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Dish_OrderId",
                schema: "RestaurantAPI",
                table: "Order_Dish",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableStatusId",
                schema: "RestaurantAPI",
                table: "Table",
                column: "TableStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish_Ingredient",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Order_Dish",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Dish",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Dish_Category",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Order_Status",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Table",
                schema: "RestaurantAPI");

            migrationBuilder.DropTable(
                name: "Table_Status",
                schema: "RestaurantAPI");
        }
    }
}
