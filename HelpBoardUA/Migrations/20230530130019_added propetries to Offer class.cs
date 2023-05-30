using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpBoardUA.Migrations
{
    /// <inheritdoc />
    public partial class addedpropetriestoOfferclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HelpType",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAid",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OfferType",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpType",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "NumberOfAid",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferType",
                table: "Offers");
        }
    }
}
