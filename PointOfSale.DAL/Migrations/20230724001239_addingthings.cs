using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingthings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PayMethods_PayMethodId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_SalesPersons_SalesPersonId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SalesPersons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sales",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SalesPersonId",
                table: "Sales",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PayMethodId",
                table: "Sales",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsSaleCompleted",
                table: "Sales",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "SaleProducts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSaleCompleted",
                table: "SaleProducts",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SaleProducts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SaleProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPersons_UserId",
                table: "SalesPersons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PayMethods_PayMethodId",
                table: "Sales",
                column: "PayMethodId",
                principalTable: "PayMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_SalesPersons_SalesPersonId",
                table: "Sales",
                column: "SalesPersonId",
                principalTable: "SalesPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPersons_Users_UserId",
                table: "SalesPersons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PayMethods_PayMethodId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_SalesPersons_SalesPersonId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPersons_Users_UserId",
                table: "SalesPersons");

            migrationBuilder.DropIndex(
                name: "IX_SalesPersons_UserId",
                table: "SalesPersons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SalesPersons");

            migrationBuilder.DropColumn(
                name: "IsSaleCompleted",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "IsSaleCompleted",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SaleProducts");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sales",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesPersonId",
                table: "Sales",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PayMethodId",
                table: "Sales",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PayMethods_PayMethodId",
                table: "Sales",
                column: "PayMethodId",
                principalTable: "PayMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_SalesPersons_SalesPersonId",
                table: "Sales",
                column: "SalesPersonId",
                principalTable: "SalesPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
