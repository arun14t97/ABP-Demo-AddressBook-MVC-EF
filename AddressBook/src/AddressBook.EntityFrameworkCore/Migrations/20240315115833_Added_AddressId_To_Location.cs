using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Migrations
{
    /// <inheritdoc />
    public partial class Added_AddressId_To_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "AppLocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppLocations_AddressId",
                table: "AppLocations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLocations_AppAddressF_AddressId",
                table: "AppLocations",
                column: "AddressId",
                principalTable: "AppAddressF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLocations_AppAddressF_AddressId",
                table: "AppLocations");

            migrationBuilder.DropIndex(
                name: "IX_AppLocations_AddressId",
                table: "AppLocations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AppLocations");
        }
    }
}
