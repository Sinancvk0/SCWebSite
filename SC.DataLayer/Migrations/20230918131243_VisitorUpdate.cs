using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class VisitorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visitor",
                table: "VisitorCounts");

            migrationBuilder.AddColumn<string>(
                name: "IpAdress",
                table: "VisitorCounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAdress",
                table: "VisitorCounts");

            migrationBuilder.AddColumn<int>(
                name: "Visitor",
                table: "VisitorCounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
