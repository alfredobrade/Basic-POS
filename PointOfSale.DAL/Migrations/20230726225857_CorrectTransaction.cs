using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CorrectTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BusinessUnits_BusinessUnitId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BussinesUnitId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "BussinesUnitId",
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
