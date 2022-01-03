using Microsoft.EntityFrameworkCore.Migrations;

namespace Investment_App.Migrations
{
    public partial class initials1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CurrentValueOfInvestedAmount", "InvestedAmount", "InvestorName" },
                values: new object[] { 1011, 1000, "Tab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CurrentValueOfInvestedAmount", "InvestedAmount", "InvestorName" },
                values: new object[] { 0, 0, null });

            migrationBuilder.InsertData(
                table: "FundDetails",
                columns: new[] { "ID", "CurrentValueOfInvestedAmount", "Description", "FundName", "InvestedAmount", "InvestorName" },
                values: new object[] { 2, 0, "NiftyBank type fund", "NiftyBank Cap Fund", 0, null });
        }
    }
}
