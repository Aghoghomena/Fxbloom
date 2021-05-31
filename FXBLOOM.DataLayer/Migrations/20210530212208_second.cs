using Microsoft.EntityFrameworkCore.Migrations;

namespace FXBLOOM.DataLayer.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_StateId",
                table: "Customers",
                column: "StateId",
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_State_StateId",
                table: "Customers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_State_StateId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_StateId",
                table: "Customers");
        }
    }
}
