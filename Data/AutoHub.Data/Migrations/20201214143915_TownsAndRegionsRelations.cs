using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoHub.Data.Migrations
{
    public partial class TownsAndRegionsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "DealerShips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "DealerShips",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Car",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealerShips_RegionId",
                table: "DealerShips",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerShips_TownId",
                table: "DealerShips",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RegionId",
                table: "Car",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TownId",
                table: "Car",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Regions_RegionId",
                table: "Car",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Towns_TownId",
                table: "Car",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerShips_Regions_RegionId",
                table: "DealerShips",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerShips_Towns_TownId",
                table: "DealerShips",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Regions_RegionId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Towns_TownId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerShips_Regions_RegionId",
                table: "DealerShips");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerShips_Towns_TownId",
                table: "DealerShips");

            migrationBuilder.DropIndex(
                name: "IX_DealerShips_RegionId",
                table: "DealerShips");

            migrationBuilder.DropIndex(
                name: "IX_DealerShips_TownId",
                table: "DealerShips");

            migrationBuilder.DropIndex(
                name: "IX_Car_RegionId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_TownId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "DealerShips");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "DealerShips");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Car");
        }
    }
}
