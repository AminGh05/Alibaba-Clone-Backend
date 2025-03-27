using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixLocationMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Locations_LocationId",
                table: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Transportations_LocationId",
                table: "Transportations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Transportations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Transportations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_LocationId",
                table: "Transportations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Locations_LocationId",
                table: "Transportations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
