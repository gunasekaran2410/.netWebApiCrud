using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerSale.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "college",
                columns: table => new
                {
                    CollegeId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_college", x => x.CollegeId);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Type = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Term = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    ChairId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    ContactPhone = table.Column<string>(type: "Varchar(150)", nullable: false),
                    ContactEmail = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Day = table.Column<string>(type: "Varchar(150)", nullable: false),
                    StartTime = table.Column<string>(type: "Varchar(150)", nullable: false),
                    EndTime = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    LastName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Firstname = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Contact = table.Column<string>(type: "Varchar(150)", nullable: false),
                    CollegeId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_student_college_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "college",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instructor",
                columns: table => new
                {
                    InstructorId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    CollegeId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    LastName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    FirstName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Rank = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Type = table.Column<string>(type: "Varchar(150)", nullable: false),
                    DepartmentId = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructor", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_instructor_college_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "college",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_instructor_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionModel",
                columns: table => new
                {
                    SectionId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "Varchar(150)", nullable: false),
                    CourseId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    ScheduleId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    InstructorId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Room = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionModel", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_SectionModel_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionModel_instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionModel_schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    StudentId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    SectionId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    DateAttended = table.Column<DateTime>(type: "datetime", nullable: false),
                    Hours = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_attendance_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_attendance_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "enrollment",
                columns: table => new
                {
                    EnrollmentId = table.Column<string>(type: "Varchar(150)", nullable: false, defaultValueSql: "NEWID()"),
                    AcademicYear = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Term = table.Column<string>(type: "Varchar(150)", nullable: false),
                    DateEnrolled = table.Column<string>(type: "Varchar(150)", nullable: false),
                    StudentId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    SectionId = table.Column<string>(type: "Varchar(150)", nullable: false),
                    MidtermGrade = table.Column<string>(type: "Varchar(150)", nullable: false),
                    FinalGrade = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollment", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_enrollment_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrollment_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendance_SectionId",
                table: "attendance",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_StudentId",
                table: "attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_SectionId",
                table: "enrollment",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_StudentId",
                table: "enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_CollegeId",
                table: "instructor",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_DepartmentId",
                table: "instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionModel_CourseId",
                table: "SectionModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionModel_InstructorId",
                table: "SectionModel",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionModel_ScheduleId",
                table: "SectionModel",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_student_CollegeId",
                table: "student",
                column: "CollegeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendance");

            migrationBuilder.DropTable(
                name: "enrollment");

            migrationBuilder.DropTable(
                name: "SectionModel");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "instructor");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "college");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
