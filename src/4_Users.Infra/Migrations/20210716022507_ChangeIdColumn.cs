using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Infra.Migrations
{
    public partial class ChangeIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USER",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "USER",
                newName: "Id");
        }
    }
}
