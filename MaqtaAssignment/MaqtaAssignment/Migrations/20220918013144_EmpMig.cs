using Microsoft.EntityFrameworkCore.Migrations;

namespace MaqtaAssignment.Migrations
{
    public partial class EmpMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DateOfBrirth = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
