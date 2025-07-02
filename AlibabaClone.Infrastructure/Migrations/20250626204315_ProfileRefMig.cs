using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfileRefMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Accounts_BuyerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Transportations_TransportationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_People_IdNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Transactions",
                newName: "TicketOrderId");

            migrationBuilder.RenameColumn(
                name: "TransportationId",
                table: "Tickets",
                newName: "TicketOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TransportationId",
                table: "Tickets",
                newName: "IX_Tickets_TicketOrderId");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TransactionTypeId",
                table: "Transactions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "People",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    IBAN = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationId = table.Column<long>(type: "bigint", nullable: false),
                    BuyerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrder_Accounts_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketOrder_Transportations_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SerialNumber",
                table: "Tickets",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CreatorId",
                table: "People",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountId",
                table: "BankAccount",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_BuyerId",
                table: "TicketOrder",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_SerialNumber",
                table: "TicketOrder",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_TransportationId",
                table: "TicketOrder",
                column: "TransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionType_Title",
                table: "TransactionType",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Accounts_CreatorId",
                table: "People",
                column: "CreatorId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets",
                column: "TicketOrderId",
                principalTable: "TicketOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                principalTable: "TicketOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Accounts_CreatorId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "TicketOrder");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SerialNumber",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_People_CreatorId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CanceledAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TicketOrderId",
                table: "Transactions",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "TicketOrderId",
                table: "Tickets",
                newName: "TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketOrderId",
                table: "Tickets",
                newName: "IX_Tickets_TransportationId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BuyerId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TicketId",
                table: "Transactions",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_People_IdNumber",
                table: "People",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Accounts_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Transportations_TransportationId",
                table: "Tickets",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Tickets_TicketId",
                table: "Transactions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
