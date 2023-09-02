using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PointOfSale.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateSystemRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "UsersRoles",
                newName: "InitialDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "UsersRoles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumMonths",
                table: "UsersRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BURoleId",
                table: "UserBusinessUnits",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserBusinessUnits",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessUnitRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinessUnits_RoleId",
                table: "UserBusinessUnits",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBusinessUnits_BusinessUnitRole_RoleId",
                table: "UserBusinessUnits",
                column: "RoleId",
                principalTable: "BusinessUnitRole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBusinessUnits_BusinessUnitRole_RoleId",
                table: "UserBusinessUnits");

            migrationBuilder.DropTable(
                name: "BusinessUnitRole");

            migrationBuilder.DropIndex(
                name: "IX_UserBusinessUnits_RoleId",
                table: "UserBusinessUnits");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "UsersRoles");

            migrationBuilder.DropColumn(
                name: "NumMonths",
                table: "UsersRoles");

            migrationBuilder.DropColumn(
                name: "BURoleId",
                table: "UserBusinessUnits");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserBusinessUnits");

            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "UsersRoles",
                newName: "DateTime");
        }
    }
}
