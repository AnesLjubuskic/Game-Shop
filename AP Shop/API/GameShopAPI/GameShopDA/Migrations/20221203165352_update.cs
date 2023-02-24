using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShopDA.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtAtDate",
                table: "UserGame");

            migrationBuilder.DropColumn(
                name: "BoughtAtPrice",
                table: "UserGame");

            migrationBuilder.AlterColumn<double>(
                name: "ShippingPrice",
                table: "UserGame",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ShippingPrice",
                table: "UserGame",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BoughtAtDate",
                table: "UserGame",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "BoughtAtPrice",
                table: "UserGame",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
