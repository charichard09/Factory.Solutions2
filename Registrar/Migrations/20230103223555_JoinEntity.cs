using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registrar.Migrations
{
    public partial class JoinEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Students",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CourseStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => x.CourseStudentId);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentId",
                table: "CourseStudent",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId1",
                table: "Students",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId1",
                table: "Courses",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseId1",
                table: "Courses",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentId");
        }
    }
}
