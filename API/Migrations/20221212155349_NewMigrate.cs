using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tier3.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubToElectricity",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubToHeating",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubToRent",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubToWater",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubToElectricity",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsSubToHeating",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsSubToRent",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsSubToWater",
                table: "Clients");
        }
    }
}
