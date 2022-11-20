using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalBank_LM.Migrations
{
    public partial class InicialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Client = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNo = table.Column<string>(maxLength: 50, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Client);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Number_Account = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Client = table.Column<int>(nullable: false),
                    Saldo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.Number_Account);
                    table.ForeignKey(
                        name: "FK_ContaBancaria_Cliente_Id_Client",
                        column: x => x.Id_Client,
                        principalTable: "Cliente",
                        principalColumn: "Id_Client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id_Transaction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_Account = table.Column<int>(nullable: false),
                    Type_Transaction = table.Column<string>(maxLength: 30, nullable: true),
                    Value_Transaction = table.Column<decimal>(nullable: false),
                    Date_Transaction = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id_Transaction);
                    table.ForeignKey(
                        name: "FK_Transacao_ContaBancaria_Number_Account",
                        column: x => x.Number_Account,
                        principalTable: "ContaBancaria",
                        principalColumn: "Number_Account",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_Id_Client",
                table: "ContaBancaria",
                column: "Id_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_Number_Account",
                table: "Transacao",
                column: "Number_Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
