using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleTable",
                columns: table => new
                {
                    RegistrationNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeat = table.Column<int>(type: "int", nullable: false),
                    AcAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTable", x => x.RegistrationNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleTable");
        }
    }
}
