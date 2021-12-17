using Microsoft.EntityFrameworkCore.Migrations;

namespace JAOAssessment.Data.Migrations
{
    public partial class InitialVehicleCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaintKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
