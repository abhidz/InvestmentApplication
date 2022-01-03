using Microsoft.EntityFrameworkCore.Migrations;

namespace Investment_App.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentValueOfInvestedAmount",
                table: "FundDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvestedAmount",
                table: "FundDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentValueOfInvestedAmount",
                table: "FundDetails");

            migrationBuilder.DropColumn(
                name: "InvestedAmount",
                table: "FundDetails");
        }
    }
}
