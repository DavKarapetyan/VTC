using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "GalleryImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImages_NewsId",
                table: "GalleryImages",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryImages_News_NewsId",
                table: "GalleryImages",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryImages_News_NewsId",
                table: "GalleryImages");

            migrationBuilder.DropIndex(
                name: "IX_GalleryImages_NewsId",
                table: "GalleryImages");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "GalleryImages");
        }
    }
}
