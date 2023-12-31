using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class notlandirma_sistemi_kaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finals",
                table: "StudentAndCourseRelationships");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentAndCourseRelationships");

            migrationBuilder.DropColumn(
                name: "MidtermGrade",
                table: "StudentAndCourseRelationships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Finals",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "StudentAndCourseRelationships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MidtermGrade",
                table: "StudentAndCourseRelationships",
                type: "int",
                nullable: true);
        }
    }
}
