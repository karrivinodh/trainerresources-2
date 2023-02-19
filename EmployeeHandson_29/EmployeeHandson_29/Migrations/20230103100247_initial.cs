using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeHandson29.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "configuracion");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "configuracion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "configuracion",
                newName: "Employees");
        }
    }
}
