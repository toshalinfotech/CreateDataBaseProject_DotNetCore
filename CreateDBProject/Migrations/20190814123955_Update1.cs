using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateDataBaseProject_DotNetCore.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "MyTestTable_1",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "MyTestTable_1");
        }
    }
}
