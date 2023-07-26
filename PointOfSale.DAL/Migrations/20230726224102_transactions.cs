using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_OperationType_OperationTypeId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OperationTypeId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsExpense",
                table: "Transactions",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "BussinesUnitId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Transactions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_OperationType_OperationTypeId",
                table: "Transactions",
                column: "OperationTypeId",
                principalTable: "OperationType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_OperationType_OperationTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperationTypeId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsExpense",
                table: "Transactions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BussinesUnitId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions",
                column: "BusinessUnitId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_OperationType_OperationTypeId",
                table: "Transactions",
                column: "OperationTypeId",
                principalTable: "OperationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
