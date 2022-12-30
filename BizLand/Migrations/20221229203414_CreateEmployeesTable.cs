using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BizLand.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Facebook",
                table: "Employees",
                column: "Facebook",
                unique: true,
                filter: "[Facebook] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Instagram",
                table: "Employees",
                column: "Instagram",
                unique: true,
                filter: "[Instagram] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Linkedin",
                table: "Employees",
                column: "Linkedin",
                unique: true,
                filter: "[Linkedin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Twitter",
                table: "Employees",
                column: "Twitter",
                unique: true,
                filter: "[Twitter] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
