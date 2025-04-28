using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsMvcViewerApp.Migrations
{
    /// <inheritdoc />
    public partial class PhotoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Cats");

            migrationBuilder.AddColumn<byte>(
                name: "PhotoPath",
                table: "Cats",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Cats");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Cats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
