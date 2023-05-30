using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpBoardUA.Migrations
{
    /// <inheritdoc />
    public partial class stiringOrgIdforOfferclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationId",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Offers");
        }
    }
}
