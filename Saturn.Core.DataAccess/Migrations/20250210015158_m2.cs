using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saturn.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Groups",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Groups",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "Groups",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "Groups",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
