using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class staff_department_rel_tablosu_kaldırıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffAndCourseRelationships_Courses_CourseId",
                table: "StaffAndCourseRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffAndCourseRelationships_Staffs_StaffId",
                table: "StaffAndCourseRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAndCourseRelationships_StaffAndCourseRelationships_StaffCourseId",
                table: "StudentAndCourseRelationships");

            migrationBuilder.DropTable(
                name: "StaffAndDepartmentRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffAndCourseRelationships",
                table: "StaffAndCourseRelationships");

            migrationBuilder.RenameTable(
                name: "StaffAndCourseRelationships",
                newName: "StaffCourseRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_StaffAndCourseRelationships_StaffId",
                table: "StaffCourseRelationship",
                newName: "IX_StaffCourseRelationship_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffAndCourseRelationships_CourseId",
                table: "StaffCourseRelationship",
                newName: "IX_StaffCourseRelationship_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "StaffCourseRelationship",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "StaffCourseRelationship",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffCourseRelationship",
                table: "StaffCourseRelationship",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCourseRelationship_Courses_CourseId",
                table: "StaffCourseRelationship",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCourseRelationship_Staffs_StaffId",
                table: "StaffCourseRelationship",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAndCourseRelationships_StaffCourseRelationship_StaffCourseId",
                table: "StudentAndCourseRelationships",
                column: "StaffCourseId",
                principalTable: "StaffCourseRelationship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCourseRelationship_Courses_CourseId",
                table: "StaffCourseRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCourseRelationship_Staffs_StaffId",
                table: "StaffCourseRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAndCourseRelationships_StaffCourseRelationship_StaffCourseId",
                table: "StudentAndCourseRelationships");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffCourseRelationship",
                table: "StaffCourseRelationship");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "StaffCourseRelationship",
                newName: "StaffAndCourseRelationships");

            migrationBuilder.RenameIndex(
                name: "IX_StaffCourseRelationship_StaffId",
                table: "StaffAndCourseRelationships",
                newName: "IX_StaffAndCourseRelationships_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffCourseRelationship_CourseId",
                table: "StaffAndCourseRelationships",
                newName: "IX_StaffAndCourseRelationships_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "StaffAndCourseRelationships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "StaffAndCourseRelationships",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffAndCourseRelationships",
                table: "StaffAndCourseRelationships",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StaffAndDepartmentRelationships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAndDepartmentRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAndDepartmentRelationships_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffAndDepartmentRelationships_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffAndDepartmentRelationships_DepartmentId",
                table: "StaffAndDepartmentRelationships",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAndDepartmentRelationships_StaffId",
                table: "StaffAndDepartmentRelationships",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAndCourseRelationships_Courses_CourseId",
                table: "StaffAndCourseRelationships",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAndCourseRelationships_Staffs_StaffId",
                table: "StaffAndCourseRelationships",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAndCourseRelationships_StaffAndCourseRelationships_StaffCourseId",
                table: "StudentAndCourseRelationships",
                column: "StaffCourseId",
                principalTable: "StaffAndCourseRelationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
