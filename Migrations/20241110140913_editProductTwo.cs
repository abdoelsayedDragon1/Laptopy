using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laptopy.Migrations
{
    /// <inheritdoc />
    public partial class editProductTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNewArrival",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecialProducts",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrendingLaptops",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewArrival",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IsSpecialProducts",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IsTrendingLaptops",
                table: "products");
        }
    }
}
