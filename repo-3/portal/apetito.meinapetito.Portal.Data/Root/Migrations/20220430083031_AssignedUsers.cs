using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apetito.meinapetito.Portal.Data.Root.Migrations
{
    public partial class AssignedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortalUserCustomerNumberEntrySortiments",
                columns: table => new
                {
                    PortalUserCustomerNumbersEntrySortimentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserCustomerNumbersEntryReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserCustomerNumberEntrySortiments", x => x.PortalUserCustomerNumbersEntrySortimentId);
                });

            migrationBuilder.CreateTable(
                name: "PortalUserCustomerNumbers",
                columns: table => new
                {
                    PortalUserCustomerNumbersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserCustomerNumbers", x => x.PortalUserCustomerNumbersId);
                });

            migrationBuilder.CreateTable(
                name: "PortalUsers",
                columns: table => new
                {
                    PortalUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureADB2CUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUsers", x => x.PortalUserId);
                });

            migrationBuilder.CreateTable(
                name: "PortalUserCustomerNumberEntrySortimentsEntries",
                columns: table => new
                {
                    PortalUserCustomerNumbersEntrySortimentEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserCustomerNumbersEntryReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserCustomerNumbersEntrySortimentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortimentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserCustomerNumberEntrySortimentsEntries", x => x.PortalUserCustomerNumbersEntrySortimentEntryId);
                    table.ForeignKey(
                        name: "FK_PortalUserCustomerNumberEntrySortimentsEntries_PortalUserCustomerNumberEntrySortiments_PortalUserCustomerNumbersEntrySortime~",
                        column: x => x.PortalUserCustomerNumbersEntrySortimentId,
                        principalTable: "PortalUserCustomerNumberEntrySortiments",
                        principalColumn: "PortalUserCustomerNumbersEntrySortimentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalUserCustomerNumbersEntries",
                columns: table => new
                {
                    PortalUserCustomerNumbersEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserCustomerNumbersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalUserReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderSystem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalUserCustomerNumbersEntries", x => x.PortalUserCustomerNumbersEntryId);
                    table.ForeignKey(
                        name: "FK_PortalUserCustomerNumbersEntries_PortalUserCustomerNumbers_PortalUserCustomerNumbersId",
                        column: x => x.PortalUserCustomerNumbersId,
                        principalTable: "PortalUserCustomerNumbers",
                        principalColumn: "PortalUserCustomerNumbersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserCustomerNumberEntrySortimentsEntries_PortalUserCustomerNumbersEntrySortimentId",
                table: "PortalUserCustomerNumberEntrySortimentsEntries",
                column: "PortalUserCustomerNumbersEntrySortimentId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserCustomerNumbersEntries_PortalUserCustomerNumbersId",
                table: "PortalUserCustomerNumbersEntries",
                column: "PortalUserCustomerNumbersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortalUserCustomerNumberEntrySortimentsEntries");

            migrationBuilder.DropTable(
                name: "PortalUserCustomerNumbersEntries");

            migrationBuilder.DropTable(
                name: "PortalUsers");

            migrationBuilder.DropTable(
                name: "PortalUserCustomerNumberEntrySortiments");

            migrationBuilder.DropTable(
                name: "PortalUserCustomerNumbers");
        }
    }
}
