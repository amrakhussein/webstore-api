using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebStore.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimePropInCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 61.12m, 3, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 3, 76.1m, 2, 3 });

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
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 98.1m, 2, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 51.55m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CartId", "Price", "ProductId" },
                values: new object[] { 3, 48.81m, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CartId", "Price" },
                values: new object[] { 3, 73.5m });

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
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 63.28m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 81.87m, 3, 1 });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 24.81m, 1, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 38.96m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 63.29m, 2, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 31.12m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 33.79m, 3, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CartId", "Price", "ProductId" },
                values: new object[] { 2, 91.3m, 2 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CartId", "Price" },
                values: new object[] { 1, 42.64m });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 68.24m, 2, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 33.33m, 1, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CartId", "Price", "ProductId", "Quantity" },
                values: new object[] { 2, 54.91m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 77.23m, 3, 3 });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "ProductId", "Quantity" },
                values: new object[] { 76.61m, 2, 3 });
        }
    }
}
