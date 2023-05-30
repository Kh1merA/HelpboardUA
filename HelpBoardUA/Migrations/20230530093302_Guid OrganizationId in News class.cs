using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpBoardUA.Migrations
{
    /// <inheritdoc />
    public partial class GuidOrganizationIdinNewsclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_OrganizationId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_OrganizationId",
                table: "News");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "News",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrganizationId",
                table: "News",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_News_OrganizationId",
                table: "News",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_OrganizationId",
                table: "News",
                column: "OrganizationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
