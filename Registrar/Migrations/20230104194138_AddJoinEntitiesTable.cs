using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registrar.Migrations
{
    public partial class AddJoinEntitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "JoinEntities");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentId",
                table: "JoinEntities",
                newName: "IX_JoinEntities_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_CourseId",
                table: "JoinEntities",
                newName: "IX_JoinEntities_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinEntities",
                table: "JoinEntities",
                column: "CourseStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinEntities_Courses_CourseId",
                table: "JoinEntities",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinEntities_Students_StudentId",
                table: "JoinEntities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinEntities_Courses_CourseId",
                table: "JoinEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinEntities_Students_StudentId",
                table: "JoinEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinEntities",
                table: "JoinEntities");

            migrationBuilder.RenameTable(
                name: "JoinEntities",
                newName: "CourseStudent");

            migrationBuilder.RenameIndex(
                name: "IX_JoinEntities_StudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinEntities_CourseId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                column: "CourseStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CourseId",
                table: "CourseStudent",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
