using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetContactsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddClientModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Contacts_UserId",
                table: "Passwords");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ClientViewModel",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientViewModel", x => x.Username);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Client_UserId",
                table: "Passwords",
                column: "UserId",
                principalTable: "Client",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Client_UserId",
                table: "Passwords");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientViewModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Contacts_UserId",
                table: "Passwords",
                column: "UserId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
