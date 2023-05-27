using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpBoardUA.Migrations
{
    /// <inheritdoc />
    public partial class patronymicpropinClientcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Clients",
                newName: "Patronymic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Clients",
                newName: "SurName");
        }
    }
}
