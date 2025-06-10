using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseTracker.Study.Migrations
{
    /// <inheritdoc />
    public partial class Secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "ExerciseShifts",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "ExerciseShifts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExerciseShifts",
                newName: "ShiftId");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "ExerciseShifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
