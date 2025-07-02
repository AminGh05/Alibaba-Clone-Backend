using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorFixesMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions");

            migrationBuilder.AlterColumn<long>(
                name: "TicketOrderId",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                unique: true,
                filter: "[TicketOrderId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "People");

            migrationBuilder.AlterColumn<long>(
                name: "TicketOrderId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                unique: true);
        }
    }
}
