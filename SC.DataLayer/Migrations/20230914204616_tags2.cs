using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class tags2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "BlogDetaills",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "BlogDetaills");
        }
    }
}
