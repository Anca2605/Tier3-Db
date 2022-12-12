using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tier3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    dob = table.Column<string>(type: "TEXT", nullable: false),
                    phonenumber = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    billid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clientid = table.Column<int>(type: "INTEGER", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false),
                    provider = table.Column<string>(type: "TEXT", nullable: false),
                    priceperitem = table.Column<double>(type: "REAL", nullable: false),
                    billingdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    duedate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    paidstatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    billid1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.billid);
                    table.ForeignKey(
                        name: "FK_Bill_Bill_billid1",
                        column: x => x.billid1,
                        principalTable: "Bill",
                        principalColumn: "billid");
                    table.ForeignKey(
                        name: "FK_Bill_Clients_clientid",
                        column: x => x.clientid,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_billid1",
                table: "Bill",
                column: "billid1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_clientid",
                table: "Bill",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
