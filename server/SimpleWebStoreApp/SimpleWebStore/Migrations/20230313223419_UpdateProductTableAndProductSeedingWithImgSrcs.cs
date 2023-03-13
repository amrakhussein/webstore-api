using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTableAndProductSeedingWithImgSrcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CartId", "Price", "Quantity" },
                values: new object[] { 2, 22.65m, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 37.1m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 27.34m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 70.13m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 12.88m, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 98.5m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 65.38m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 23.24m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 74.31m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 91.86m, 1, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CartId", "Price", "ProductId" },
                values: new object[] { 1, 82.98m, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "ProductId" },
                values: new object[] { 65.46m, 1 });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 22, 34, 19, 50, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 22, 34, 19, 50, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 22, 34, 19, 50, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageSrc" },
                values: new object[] { " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1099&q=80" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageSrc" },
                values: new object[] { " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "https://images.unsplash.com/photo-1546868871-7041f2a55e12?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=764&q=80" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageSrc" },
                values: new object[] { " simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "https://plus.unsplash.com/premium_photo-1675431443185-9d40521c8d5c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=751&q=80" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CartId", "Price", "Quantity" },
                values: new object[] { 3, 61.12m, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 76.1m, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 71.25m, 1, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 98.1m, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 51.55m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 48.81m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 73.5m, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 58.95m, 1, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 45.35m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 59.57m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CartId", "Price", "ProductId" },
                values: new object[] { 2, 63.28m, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "ProductId" },
                values: new object[] { 81.87m, 3 });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Some random description");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Some random description");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Some random description");
        }
    }
}
