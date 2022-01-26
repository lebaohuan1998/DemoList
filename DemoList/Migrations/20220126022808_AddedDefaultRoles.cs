using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoList.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fbf6a2d-9959-42d2-932b-fd6a78c509f0", "465f3585-3701-46cb-ab75-ffb58dac5f7b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c289290d-bfa5-4708-b958-4668e608bbbd", "e3554a88-78e7-4030-bb65-60f6e9b02f8c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fbf6a2d-9959-42d2-932b-fd6a78c509f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c289290d-bfa5-4708-b958-4668e608bbbd");
        }
    }
}
