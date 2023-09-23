using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TBL");

            migrationBuilder.CreateTable(
                name: "LESSONS",
                schema: "TBL",
                columns: table => new
                {
                    LESSON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LESSON_CODE = table.Column<string>(type: "char(3)", nullable: false),
                    LESSON_NAME = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    CLASS_NUMBER = table.Column<short>(type: "smallint", nullable: false),
                    TEACHER_NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TEACHER_SURNAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LESSONS", x => x.LESSON_ID);
                    table.UniqueConstraint("AK_LESSONS_LESSON_CODE", x => x.LESSON_CODE);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                schema: "TBL",
                columns: table => new
                {
                    STUDENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STUDENT_NUMBER = table.Column<short>(type: "SMALLINT", nullable: false),
                    STUDENT_NAME = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    STUDENT_SURNAME = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    CLASS_NUMBER = table.Column<short>(type: "SMALLINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.STUDENT_ID);
                    table.UniqueConstraint("AK_STUDENTS_STUDENT_NUMBER", x => x.STUDENT_NUMBER);
                });

            migrationBuilder.CreateTable(
                name: "EXAMS",
                schema: "TBL",
                columns: table => new
                {
                    EXAM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LESSON_CODE = table.Column<string>(type: "char(3)", nullable: false),
                    STUDENT_NUMBER = table.Column<short>(type: "smallint", nullable: false),
                    EXAM_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    GRADE = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAMS", x => x.EXAM_ID);
                    table.ForeignKey(
                        name: "FK_EXAMS_LESSONS_LESSON_CODE",
                        column: x => x.LESSON_CODE,
                        principalSchema: "TBL",
                        principalTable: "LESSONS",
                        principalColumn: "LESSON_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAMS_STUDENTS_STUDENT_NUMBER",
                        column: x => x.STUDENT_NUMBER,
                        principalSchema: "TBL",
                        principalTable: "STUDENTS",
                        principalColumn: "STUDENT_NUMBER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXAMS_LESSON_CODE",
                schema: "TBL",
                table: "EXAMS",
                column: "LESSON_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_EXAMS_STUDENT_NUMBER",
                schema: "TBL",
                table: "EXAMS",
                column: "STUDENT_NUMBER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXAMS",
                schema: "TBL");

            migrationBuilder.DropTable(
                name: "LESSONS",
                schema: "TBL");

            migrationBuilder.DropTable(
                name: "STUDENTS",
                schema: "TBL");
        }
    }
}
