using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globus.DAL.Migrations
{
    public partial class otp_entity_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "OneTimePasswords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "OneTimePasswords");
        }
    }
}
