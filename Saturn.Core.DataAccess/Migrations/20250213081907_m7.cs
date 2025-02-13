using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saturn.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonStudent");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Groups",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Students",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "LessonStudent",
                columns: table => new
                {
                    GroupsLessonId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonStudent", x => new { x.GroupsLessonId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_LessonStudent_Groups_GroupsLessonId",
                        column: x => x.GroupsLessonId,
                        principalTable: "Groups",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LessonStudent_StudentsStudentId",
                table: "LessonStudent",
                column: "StudentsStudentId");
        }
    }
}
