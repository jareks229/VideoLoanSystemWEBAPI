using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoLoanWebAPI.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateAdded",
                table: "Films",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Gendre",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gendre",
                table: "Films");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Films",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
