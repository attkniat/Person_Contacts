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
                values: new object[] { 1, "Email: 1", "Esse nome: 1", "0000000000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 2, "Email: 2", "Esse nome: 2", "0000000000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 3, "Email: 3", "Esse nome: 3", "0000000000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 4, "Email: 4", "Esse nome: 4", "0000000000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "PersonEmail", "PersonName", "PersonPhone" },
                values: new object[] { 5, "Email: 5", "Esse nome: 5", "0000000000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
