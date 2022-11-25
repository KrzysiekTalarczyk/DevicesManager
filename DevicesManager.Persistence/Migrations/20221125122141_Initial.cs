using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevicesManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostName = table.Column<string>(type: "TEXT", nullable: false),
                    OperationSystem = table.Column<string>(type: "TEXT", nullable: false),
                    RAMAmountMB = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    ConnectionId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
