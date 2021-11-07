using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericImporter.Infra.Data.Migrations
{
    public partial class NewFieldToImportEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Error",
                table: "ImportItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "ImportItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemsFailedProcessed",
                table: "Import",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsSuccessfullyProcessed",
                table: "Import",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsUnprocessed",
                table: "Import",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "Import",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "ImportItem");

            migrationBuilder.DropColumn(
                name: "Processed",
                table: "ImportItem");

            migrationBuilder.DropColumn(
                name: "ItemsFailedProcessed",
                table: "Import");

            migrationBuilder.DropColumn(
                name: "ItemsSuccessfullyProcessed",
                table: "Import");

            migrationBuilder.DropColumn(
                name: "ItemsUnprocessed",
                table: "Import");

            migrationBuilder.DropColumn(
                name: "Processed",
                table: "Import");
        }
    }
}
