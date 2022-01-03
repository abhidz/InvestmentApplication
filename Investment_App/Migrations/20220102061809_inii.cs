using Microsoft.EntityFrameworkCore.Migrations;

namespace Investment_App.Migrations
{
    public partial class inii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvestorName",
                table: "FundDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "InvestorName",
                value: null);

            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 2,
                column: "InvestorName",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InvestorName",
                table: "FundDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "InvestorName",
                value: 0);

            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 2,
                column: "InvestorName",
                value: 0);
        }
    }
}
