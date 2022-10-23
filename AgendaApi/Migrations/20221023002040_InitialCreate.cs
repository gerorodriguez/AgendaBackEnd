using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                { 
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CellPhoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    TelephoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "CellPhoneNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 1, 341457896L, "Plomero", "Jaimito", null, 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CellPhoneNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 2, 34156978L, "Papa", "Pepe", 422568L, 2 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CellPhoneNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 3, 11425789L, "Jefa", "Maria", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
