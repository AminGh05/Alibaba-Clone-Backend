using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlibabaClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDbSetsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Accounts_AccountId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Accounts_BuyerId",
                table: "TicketOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Transportations_TransportationId",
                table: "TicketOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrder_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrder_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionType_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TicketOrder",
                newName: "TicketOrders");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionType_Title",
                table: "TransactionTypes",
                newName: "IX_TransactionTypes_Title");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_TransportationId",
                table: "TicketOrders",
                newName: "IX_TicketOrders_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_SerialNumber",
                table: "TicketOrders",
                newName: "IX_TicketOrders_SerialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_BuyerId",
                table: "TicketOrders",
                newName: "IX_TicketOrders_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_AccountId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Accounts_AccountId",
                table: "BankAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Accounts_BuyerId",
                table: "TicketOrders",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Transportations_TransportationId",
                table: "TicketOrders",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketOrders_TicketOrderId",
                table: "Tickets",
                column: "TicketOrderId",
                principalTable: "TicketOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TicketOrders_TicketOrderId",
                table: "Transactions",
                column: "TicketOrderId",
                principalTable: "TicketOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Accounts_AccountId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Accounts_BuyerId",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Transportations_TransportationId",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketOrders_TicketOrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TicketOrders_TicketOrderId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TicketOrders",
                newName: "TicketOrder");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "BankAccount");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionTypes_Title",
                table: "TransactionType",
                newName: "IX_TransactionType_Title");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_TransportationId",
                table: "TicketOrder",
                newName: "IX_TicketOrder_TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_SerialNumber",
                table: "TicketOrder",
                newName: "IX_TicketOrder_SerialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_BuyerId",
                table: "TicketOrder",
                newName: "IX_TicketOrder_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_AccountId",
                table: "BankAccount",
                newName: "IX_BankAccount_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Accounts_AccountId",
                table: "BankAccount",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Accounts_BuyerId",
                table: "TicketOrder",
                column: "BuyerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Transportations_TransportationId",
                table: "TicketOrder",
                column: "TransportationId",
                principalTable: "Transportations",
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
    }
}
