using Microsoft.EntityFrameworkCore.Migrations;

namespace INS_FInal.Migrations
{
    public partial class depAdmin_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepAdmin",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepAdmin",
                table: "Departments");
        }
    }
}
