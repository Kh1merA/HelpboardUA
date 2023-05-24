using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpBoardUA.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _VPO_Status = table.Column<bool>(type: "bit", nullable: false),
                    _birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _registrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _subTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _publicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _organizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Organizations__organizationId",
                        column: x => x._organizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _finishDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _organizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Organizations__organizationId",
                        column: x => x._organizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayForRecieve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayForRecieve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayForRecieve_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferClient_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferClient_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayForRecieve_OfferId",
                table: "DayForRecieve",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_News__organizationId",
                table: "News",
                column: "_organizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferClient_ClientId",
                table: "OfferClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferClient_OfferId",
                table: "OfferClient",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers__organizationId",
                table: "Offers",
                column: "_organizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayForRecieve");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OfferClient");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
