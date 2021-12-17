using Microsoft.EntityFrameworkCore.Migrations;

namespace Investment_App.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FundDetails",
                columns: new[] { "ID", "Description", "FundName" },
                values: new object[] { 1, "Nifty type fund", "Nifty Cap Fund" });

            migrationBuilder.InsertData(
                table: "FundDetails",
                columns: new[] { "ID", "Description", "FundName" },
                values: new object[] { 2, "NiftyBank type fund", "NiftyBank Cap Fund" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FundDetails",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
