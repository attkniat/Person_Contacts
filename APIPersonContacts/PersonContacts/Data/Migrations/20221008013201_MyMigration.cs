using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonContacts.Data.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PersonEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PersonPhone = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 1, "DavidSmith1@gmail.com", "David Smith 01", "1234567890" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 2, "DavidSmith2@gmail.com", "David Smith 02", "2234567890" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 3, "DavidSmith3@gmail.com", "David Smith 03", "3234567890" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 4, "DavidSmith4@gmail.com", "David Smith 04", "4234567890" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 5, "DavidSmith5@gmail.com", "David Smith 05", "5234567890" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
