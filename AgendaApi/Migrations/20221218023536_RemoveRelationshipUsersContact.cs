using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    public partial class RemoveRelationshipUsersContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "karenbailapiola@gmail.com", "Karen", "Lasot", "Pa$$w0rd", "karenpiola" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 2, "elluismidetotoras@gmail.com", "Luis Gonzalez", "Gonzales", "lamismadesiempre", "luismitoto" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CellPhoneNumber", "ContactsBookId", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 1, 341457896L, null, "Plomero", "Jaimito", null, 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CellPhoneNumber", "ContactsBookId", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 2, 34156978L, null, "Papa", "Pepe", 422568L, 2 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CellPhoneNumber", "ContactsBookId", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 3, 11425789L, null, "Jefa", "Maria", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
