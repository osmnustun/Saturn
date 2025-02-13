using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Saturn.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Groups",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Students",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "StudentsLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsLessons_Groups_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Groups",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsLessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsLessons_LessonId",
                table: "StudentsLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsLessons_StudentId",
                table: "StudentsLessons",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsLessons");

            migrationBuilder.AddColumn<string>(
                name: "Groups",
                table: "Students",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Students",
                table: "Groups",
                type: "longtext",
                nullable: true);
        }
    }
}
