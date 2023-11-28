using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "IssueDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7260), "Devi farlo per forza mi dispiace", true, new DateTime(2023, 11, 30, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7260), "Portare a spasso il cane", new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7260) },
                    { 2, new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7270), "A meno che tu non voglia esplodere..", true, new DateTime(2023, 11, 29, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7270), "Controllare il gas", new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7270) },
                    { 3, new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7270), "Non sei ricco :(", true, new DateTime(2023, 11, 30, 14, 50, 8, 174, DateTimeKind.Utc).AddTicks(7270), "Mettere da parte dei soldi", new DateTime(2023, 11, 28, 10, 40, 8, 174, DateTimeKind.Utc).AddTicks(7270) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
