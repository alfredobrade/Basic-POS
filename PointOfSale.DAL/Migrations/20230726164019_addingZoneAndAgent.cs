using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingZoneAndAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "YakaAgent",
                table: "Users",
                newName: "YakaAgentId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Supliers",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Sales",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Purchases",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Products",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Invoices",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Customers",
                newName: "BusinessUnitId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "CashRegisters",
                newName: "BusinessUnitId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessUnitId",
                table: "SalesPersons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BusinessUnitId",
                table: "SalesPersons");

            migrationBuilder.RenameColumn(
                name: "YakaAgentId",
                table: "Users",
                newName: "YakaAgent");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Supliers",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Sales",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Purchases",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Products",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Invoices",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "Customers",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitId",
                table: "CashRegisters",
                newName: "BusinessId");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "Id");
        }
    }
}
