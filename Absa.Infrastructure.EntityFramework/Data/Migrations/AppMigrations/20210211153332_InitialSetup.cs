using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Absa.Infrastructure.EntityFramework.Data.Migrations.AppMigrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Absa");

            migrationBuilder.CreateTable(
                name: "Phonebooks",
                schema: "Absa",
                columns: table => new
                {
                    PhonebookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.PhonebookId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                schema: "Absa",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonebookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Entries_Phonebooks_PhonebookId",
                        column: x => x.PhonebookId,
                        principalSchema: "Absa",
                        principalTable: "Phonebooks",
                        principalColumn: "PhonebookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PhonebookId",
                schema: "Absa",
                table: "Entries",
                column: "PhonebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries",
                schema: "Absa");

            migrationBuilder.DropTable(
                name: "Phonebooks",
                schema: "Absa");
        }
    }
}
