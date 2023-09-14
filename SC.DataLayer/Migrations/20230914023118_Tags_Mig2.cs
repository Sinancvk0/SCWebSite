using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Tags_Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogDetailsId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "BlogDetaillsId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags",
                column: "BlogDetaillsId",
                principalTable: "BlogDetaills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "BlogDetaillsId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogDetailsId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags",
                column: "BlogDetaillsId",
                principalTable: "BlogDetaills",
                principalColumn: "Id");
        }
    }
}
