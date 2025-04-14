using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class MigFakeBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryYear = table.Column<int>(type: "int", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "int", nullable: false),
                    CardLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfoes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CardInfoes",
                columns: new[] { "Id", "Balance", "CVV", "CardLimit", "CardNumber", "CardUserName", "CreatedDate", "DeletedDate", "ExpiryMonth", "ExpiryYear", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, 50000m, "123", 50000m, "1111 1111 1111 1111", "Hakan Akinsu", new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2937), null, 12, 2026, null, 1 },
                    { 2, 75000m, "456", 75000m, "2222 2222 2222 2222", "Test Member", new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2950), null, 6, 2025, null, 1 },
                    { 3, 100000m, "789", 100000m, "3333 3333 3333 3333", "Zeynep Demir", new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2952), null, 9, 2027, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardInfoes");
        }
    }
}
