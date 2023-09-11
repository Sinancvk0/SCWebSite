using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AboutSkılls3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Skılls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skılls_AboutId",
                table: "Skılls",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skılls_Abouts_AboutId",
                table: "Skılls",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skılls_Abouts_AboutId",
                table: "Skılls");

            migrationBuilder.DropIndex(
                name: "IX_Skılls_AboutId",
                table: "Skılls");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Skılls");
        }
    }
}
