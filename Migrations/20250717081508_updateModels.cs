using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MahalliyMarket.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "postal_code",
                table: "users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "postal_code",
                table: "users",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
