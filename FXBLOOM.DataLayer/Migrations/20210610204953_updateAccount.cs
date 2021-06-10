using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FXBLOOM.DataLayer.Migrations
{
    public partial class updateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ClosedBids",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomesticAcct_AccountNumber",
                table: "Customers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomesticAcct_BankName",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignAcct_AccountNumber",
                table: "Customers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignAcct_BankName",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedBids",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DomesticAcct_AccountNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DomesticAcct_BankName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ForeignAcct_AccountNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ForeignAcct_BankName",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
