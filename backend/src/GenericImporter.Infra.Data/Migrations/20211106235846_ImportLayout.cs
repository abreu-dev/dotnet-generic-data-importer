using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericImporter.Infra.Data.Migrations
{
    public partial class ImportLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Xpto",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ImportLayout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Separator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportLayoutEntity = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportLayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportLayoutColumn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportLayoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportLayoutColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportLayoutColumn_ImportLayout_ImportLayoutId",
                        column: x => x.ImportLayoutId,
                        principalTable: "ImportLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportLayoutColumn_ImportLayoutId",
                table: "ImportLayoutColumn",
                column: "ImportLayoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportLayoutColumn");

            migrationBuilder.DropTable(
                name: "ImportLayout");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Xpto",
                newName: "Nome");
        }
    }
}
