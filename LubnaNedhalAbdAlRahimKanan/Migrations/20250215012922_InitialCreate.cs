using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LubnaNedhalAbdAlRahimKanan.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "RequestStates",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStates", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    VacationTypeCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.VacationTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ReportsTo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    VacationDaysLeft = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    VacationTypeCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVacationDays = table.Column<int>(type: "int", nullable: false),
                    RequestStateId = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DeclinedBy = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Employees_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequests_RequestStates_RequestStateId",
                        column: x => x.RequestStateId,
                        principalTable: "RequestStates",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_EmployeeNumber",
                table: "VacationRequests",
                column: "EmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_RequestStateId",
                table: "VacationRequests",
                column: "RequestStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RequestStates");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
