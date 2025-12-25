using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTiemSach.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeeId_Month",
                table: "Salary",
                columns: new[] { "EmployeeId", "Month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salary_EmployeeId_Month",
                table: "Salary");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Books");
        }
    }
}
