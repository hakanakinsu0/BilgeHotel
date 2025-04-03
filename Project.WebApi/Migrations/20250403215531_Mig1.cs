using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 4, 0, 55, 31, 434, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 4, 0, 55, 31, 434, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 4, 0, 55, 31, 434, DateTimeKind.Local).AddTicks(3257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 21, 48, 42, 647, DateTimeKind.Local).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 21, 48, 42, 647, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "CardInfoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 21, 48, 42, 647, DateTimeKind.Local).AddTicks(7420));
        }
    }
}
