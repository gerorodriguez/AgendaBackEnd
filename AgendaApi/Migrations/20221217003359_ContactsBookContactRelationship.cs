using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    public partial class ContactsBookContactRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactsBookId",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactsBookId",
                table: "Contacts",
                column: "ContactsBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactsBooks_ContactsBookId",
                table: "Contacts",
                column: "ContactsBookId",
                principalTable: "ContactsBooks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactsBooks_ContactsBookId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactsBookId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactsBookId",
                table: "Contacts");
        }
    }
}
