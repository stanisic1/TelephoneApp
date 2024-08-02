using Microsoft.EntityFrameworkCore.Migrations;

namespace TelephoneApp.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableAmount", "Model", "OperatingSystem", "Price", "ProducerId" },
                values: new object[] { 17, "11", "iOS", 71290.35m, 2 });

            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableAmount", "Model", "OperatingSystem", "Price", "ProducerId" },
                values: new object[] { 4, "Reno10 Pro", "Android", 68264.74m, 3 });

            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableAmount", "Model", "Price", "ProducerId" },
                values: new object[] { 5, "12 Lite", 44999.56m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableAmount", "Model", "OperatingSystem", "Price", "ProducerId" },
                values: new object[] { 12, "A94", "Android", 31125.42m, 3 });

            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableAmount", "Model", "OperatingSystem", "Price", "ProducerId" },
                values: new object[] { 17, "11", "iOS", 71290.35m, 2 });

            migrationBuilder.UpdateData(
                table: "Telephones",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableAmount", "Model", "Price", "ProducerId" },
                values: new object[] { 4, "Reno10 Pro", 68264.74m, 3 });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "AvailableAmount", "Model", "OperatingSystem", "Price", "ProducerId" },
                values: new object[] { 6, 5, "12 Lite", "Android", 44999.56m, 1 });
        }
    }
}
