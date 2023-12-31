using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class derslere_kredi_eklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffCourseRelationship_Courses_CourseId",
                table: "StaffCourseRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCourseRelationship_Staffs_StaffId",
                table: "StaffCourseRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAndCourseRelationships_StaffCourseRelationship_StaffCourseId",
                table: "StudentAndCourseRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffCourseRelationship",
                table: "StaffCourseRelationship");

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

            migrationBuilder.AddColumn<int>(
                name: "Credit",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffAndCourseRelationships",
                table: "StaffAndCourseRelationships");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Courses");

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
                name: "FK_StudentAndCourseRelationships_StaffCourseRelationship_StaffCourseId",
                table: "StudentAndCourseRelationships",
                column: "StaffCourseId",
                principalTable: "StaffCourseRelationship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
