using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saturn.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BilsemNo",
                table: "Students",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BilsemNo",
                table: "Students");
        }
    }
}
