using Microsoft.EntityFrameworkCore.Migrations;

namespace FXBLOOM.DataLayer.Migrations
{
    public partial class UpdateSubscriptionTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlySubscribed",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrentlySubscribed",
                table: "Subscriptions");
        }
    }
}
