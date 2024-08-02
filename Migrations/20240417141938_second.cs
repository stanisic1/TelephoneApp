using Microsoft.EntityFrameworkCore.Migrations;

namespace TelephoneApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telephons_Producers_ProducerId",
                table: "Telephons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telephons",
                table: "Telephons");

            migrationBuilder.RenameTable(
                name: "Telephons",
                newName: "Telephones");

            migrationBuilder.RenameIndex(
                name: "IX_Telephons_ProducerId",
                table: "Telephones",
                newName: "IX_Telephones_ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telephones",
                table: "Telephones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telephones_Producers_ProducerId",
                table: "Telephones",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telephones_Producers_ProducerId",
                table: "Telephones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telephones",
                table: "Telephones");

            migrationBuilder.RenameTable(
                name: "Telephones",
                newName: "Telephons");

            migrationBuilder.RenameIndex(
                name: "IX_Telephones_ProducerId",
                table: "Telephons",
                newName: "IX_Telephons_ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telephons",
                table: "Telephons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telephons_Producers_ProducerId",
                table: "Telephons",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
