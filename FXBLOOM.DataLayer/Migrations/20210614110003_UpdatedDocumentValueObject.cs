using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FXBLOOM.DataLayer.Migrations
{
    public partial class UpdatedDocumentValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameColumn(
                name: "AmountNeededId",
                table: "Listing",
                newName: "AmountNeeded_CurrencyType");

            migrationBuilder.RenameColumn(
                name: "AmountAvailableId",
                table: "Listing",
                newName: "AmountAvailable_CurrencyType");

            migrationBuilder.RenameColumn(
                name: "AmountId",
                table: "Bid",
                newName: "Amount_CurrencyType");

            migrationBuilder.AlterColumn<string>(
                name: "Statename",
                table: "State",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountAvailable_Amount",
                table: "Listing",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountNeeded_Amount",
                table: "Listing",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateLoggedIn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount_Amount",
                table: "Bid",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Countries_CountryId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AmountAvailable_Amount",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "AmountNeeded_Amount",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "LastDateLoggedIn",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Amount_Amount",
                table: "Bid");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "AmountNeeded_CurrencyType",
                table: "Listing",
                newName: "AmountNeededId");

            migrationBuilder.RenameColumn(
                name: "AmountAvailable_CurrencyType",
                table: "Listing",
                newName: "AmountAvailableId");

            migrationBuilder.RenameColumn(
                name: "Amount_CurrencyType",
                table: "Bid",
                newName: "AmountId");

            migrationBuilder.AlterColumn<string>(
                name: "Statename",
                table: "State",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryId");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listing_AmountAvailableId",
                table: "Listing",
                column: "AmountAvailableId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_AmountNeededId",
                table: "Listing",
                column: "AmountNeededId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_AmountId",
                table: "Bid",
                column: "AmountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Currency_AmountId",
                table: "Bid",
                column: "AmountId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Currency_AmountAvailableId",
                table: "Listing",
                column: "AmountAvailableId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Currency_AmountNeededId",
                table: "Listing",
                column: "AmountNeededId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
