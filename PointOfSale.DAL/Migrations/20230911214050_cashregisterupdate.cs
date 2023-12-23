using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cashregisterupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashRegisterId",
                table: "Transactions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CashRegisters",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CashRegisterId",
                table: "Transactions",
                column: "CashRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CashRegisters_CashRegisterId",
                table: "Transactions",
                column: "CashRegisterId",
                principalTable: "CashRegisters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CashRegisters_CashRegisterId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CashRegisterId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CashRegisterId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CashRegisters");
        }
    }
}
