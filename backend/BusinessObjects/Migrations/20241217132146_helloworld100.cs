using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class helloworld100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 2,
                column: "cases",
                value: "{\"data\":[{\"input\": \"2 7 11 15 9 # 0 1\", \"output\": \"[0,1]\"}, {\"input\": \"3 2 4 6 # 0 1\", \"output\": \"[0,1]\"}, {\"input\": \"3 3 6 # 0 1\", \"output\": \"[0,1]\"}] }");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Testcases",
                keyColumn: "TestcaseId",
                keyValue: 2,
                column: "cases",
                value: "{\"data\":[{\"input\":[[2,7,11,15],9],\"cla\":\"2 7 11 15 9\",\"output\":[[0,1]]},{\"input\":[[3,2,4],6],\"cla\":\"3 2 4 6\",\"output\":[[0,1]]},{\"input\":[[3,3],6],\"cla\":\"3 3 6\",\"output\":[[0,1]]}]}");
        }
    }
}
