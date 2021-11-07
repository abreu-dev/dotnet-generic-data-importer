using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericImporter.Infra.Data.Migrations
{
    public partial class ImportItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportFileLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportItem_Import_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Import",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportItem_ImportId",
                table: "ImportItem",
                column: "ImportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportItem");
        }
    }
}
