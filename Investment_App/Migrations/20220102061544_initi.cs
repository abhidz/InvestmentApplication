using Microsoft.EntityFrameworkCore.Migrations;

namespace Investment_App.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvestorName",
                table: "FundDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestorName",
                table: "FundDetails");
        }
    }
}
