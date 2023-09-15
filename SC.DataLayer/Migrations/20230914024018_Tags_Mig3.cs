using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Tags_Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogDetaillsId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogDetaillsId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "BlogDetaillsTag",
                columns: table => new
                {
                    BlogDetaillsId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetaillsTag", x => new { x.BlogDetaillsId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogDetaillsTag_BlogDetaills_BlogDetaillsId",
                        column: x => x.BlogDetaillsId,
                        principalTable: "BlogDetaills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogDetaillsTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetaillsTag_TagId",
                table: "BlogDetaillsTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogDetaillsTag");

            migrationBuilder.AddColumn<int>(
                name: "BlogDetaillsId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogDetaillsId",
                table: "Tags",
                column: "BlogDetaillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogDetaills_BlogDetaillsId",
                table: "Tags",
                column: "BlogDetaillsId",
                principalTable: "BlogDetaills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
