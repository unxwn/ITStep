using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW2WebApp.Migrations
{
    /// <inheritdoc />
    public partial class OriginalName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "Files");
        }
    }
}
