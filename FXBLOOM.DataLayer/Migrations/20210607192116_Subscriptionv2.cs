using Microsoft.EntityFrameworkCore.Migrations;

namespace FXBLOOM.DataLayer.Migrations
{
    public partial class Subscriptionv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "emailSent",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailSent",
                table: "Subscriptions");
        }
    }
}
