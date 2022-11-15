using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalBank_LM.Migrations
{
    public partial class AjusteDeTamanhoMaximo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type_Transaction",
                table: "Transacao",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_Id_Client",
                table: "ContaBancaria",
                column: "Id_Client");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaBancaria_Cliente_Id_Client",
                table: "ContaBancaria",
                column: "Id_Client",
                principalTable: "Cliente",
                principalColumn: "Id_Client",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaBancaria_Cliente_Id_Client",
                table: "ContaBancaria");

            migrationBuilder.DropIndex(
                name: "IX_ContaBancaria_Id_Client",
                table: "ContaBancaria");

            migrationBuilder.AlterColumn<string>(
                name: "Type_Transaction",
                table: "Transacao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
