using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class staffId_studentıd_no_olarak_degisti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "StudentNo");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Staffs",
                newName: "StaffNo");

            migrationBuilder.AlterColumn<int>(
                name: "MidtermGrade",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Finals",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNo",
                table: "Students",
                column: "StudentNo",
                unique: true,
                filter: "[StudentNo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentNo",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentNo",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StaffNo",
                table: "Staffs",
                newName: "StaffId");

            migrationBuilder.AlterColumn<int>(
                name: "MidtermGrade",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Finals",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");
        }
    }
}
