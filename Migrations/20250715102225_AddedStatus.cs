using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MahalliyMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "status_id", "status_name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Confirmed" },
                    { 3, "Processing" },
                    { 4, "Completed" },
                    { 5, "Failed" },
                    { 6, "Cancelled" },
                    { 7, "Refunded" },
                    { 8, "Approved" },
                    { 9, "Delivered" },
                    { 10, "OutForDelivery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "status_id",
                keyValue: 10);
        }
    }
}
