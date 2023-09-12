using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlogDetails2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content2",
                table: "BlogDetaills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "BlogDetaills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "BlogDetaills",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content2",
                table: "BlogDetaills");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "BlogDetaills");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "BlogDetaills");
        }
    }
}
